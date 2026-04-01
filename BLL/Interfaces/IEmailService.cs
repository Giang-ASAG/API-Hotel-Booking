using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
        Task SendEmailWithAttachment(string toEmail, string subject, string body, byte[] fileBytes, string fileName);
    }
}
