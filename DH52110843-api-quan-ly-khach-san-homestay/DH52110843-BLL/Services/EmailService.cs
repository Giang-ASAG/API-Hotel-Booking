using DH52110843_BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient(_config["EmailSettings:SmtpHost"])
            {
                Port = int.Parse(_config["EmailSettings:SmtpPort"]),
                Credentials = new NetworkCredential(
                    _config["EmailSettings:Username"],
                    _config["EmailSettings:Password"]
                ),
                EnableSsl = true

            };
            var mailMessage = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                From = new MailAddress(_config["EmailSettings:From"], _config["EmailSettings:DisplayName"])
            };
            mailMessage.To.Add(toEmail);
            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendEmailWithAttachment(string toEmail, string subject, string body, byte[] fileBytes, string fileName)
        {
            var smtpClient = new SmtpClient(_config["EmailSettings:SmtpHost"])
            {
                Port = int.Parse(_config["EmailSettings:SmtpPort"]),
                Credentials = new NetworkCredential(
                    _config["EmailSettings:Username"],
                    _config["EmailSettings:Password"]
                ),
                EnableSsl = true
            };
            var mailMessage = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                From = new MailAddress(_config["EmailSettings:From"], _config["EmailSettings:DisplayName"])
            };

            mailMessage.To.Add(toEmail);

            // Đính kèm ảnh (ví dụ CCCD hoặc GPKD)
            if (fileBytes != null && fileBytes.Length > 0)
            {
                using var stream = new MemoryStream(fileBytes);
                var attachment = new Attachment(stream, fileName); // ví dụ "cccd.png"
                mailMessage.Attachments.Add(attachment);

                await smtpClient.SendMailAsync(mailMessage);

                // ✨ Cần dispose thủ công MailMessage vì Attachment sẽ giữ stream
                mailMessage.Dispose();
            }
            else
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
        }

    }
}
