using AutoMapper;
using DH52110843_BLL.Config;
using DH52110843_BLL.DTO;
using DH52110843_BLL.DTO.VNPay;
using DH52110843_BLL.Interfaces;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task addAsync(PaymentDTO payment)
        {
            var p = _mapper.Map<Payment>(payment);
            await _paymentRepository.addAsync(p);
        }

        public async Task deleteAsync(int id)
        {
            await _paymentRepository.deleteAsync(id);
        }

        public Task<PaymentDTO> findPaymentbyBookingIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentDTO> findPaymentbyIdAsync(int id)
        {
            var p = await _paymentRepository.findPaymentbyIdAsync(id);
            return _mapper.Map<PaymentDTO>(p);
        }

        public async Task<IEnumerable<PaymentDTO>> getAllPaymentAsync()
        {
            var list =await _paymentRepository.getAllPaymentAsync();
            return _mapper.Map<IEnumerable<PaymentDTO>>(list);
        }

        public string CreatePaymentUrl(VNPayResquest request, string ipAddress)
        {
            var vnp_Amount = (request.Amount * 100).ToString();
            var datePart = DateTime.Now.ToString("MMdd");

            // Tạo 5 chữ số ngẫu nhiên
            var random = new Random();
            var randomPart = random.Next(10000, 99999);
            var vnp_TxnRef = datePart+randomPart;
            var vnp_OrderInfo = $"Thanh toan don hang {vnp_TxnRef}";
            var vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss");

            var inputData = new SortedDictionary<string, string>
            {
                { "vnp_Version", VnPayConfig.Version },
                { "vnp_Command", VnPayConfig.Command },
                { "vnp_TmnCode", VnPayConfig.TmnCode },
                { "vnp_Amount", vnp_Amount },
                { "vnp_CurrCode", VnPayConfig.CurrCode },
                { "vnp_TxnRef", vnp_TxnRef },
                { "vnp_OrderInfo", vnp_OrderInfo },
                { "vnp_OrderType", VnPayConfig.OrderType },
                { "vnp_Locale", VnPayConfig.Locale },
                { "vnp_ReturnUrl", VnPayConfig.ReturnUrl },
                { "vnp_IpAddr", ipAddress },
                { "vnp_CreateDate", vnp_CreateDate }
            };

            var rawData = BuildQueryString(inputData);
            var vnp_SecureHash = HmacSHA512(VnPayConfig.HashSecret, rawData);
            inputData.Add("vnp_SecureHash", vnp_SecureHash);

            return VnPayConfig.Url + "?" + BuildQueryString(inputData);
        }
        private string BuildQueryString(SortedDictionary<string, string> data)
        {
            var sb = new StringBuilder();
            foreach (var kv in data)
            {
                sb.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
            }
            return sb.ToString().TrimEnd('&');
        }

        private string HmacSHA512(string key, string data)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            using var hmac = new HMACSHA512(keyBytes);
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public string GenerateReturnHtml(string responseCode, string transactionNo, string txnRef, string bankCode, string amount, string orderInfo, string paydate)
        {
            var isSuccess = responseCode == "00";
            DateTime dateTime = DateTime.ParseExact(paydate.Substring(0, 8), "yyyyMMdd", null);

            // Định dạng lại thành yyyy-MM-dd
            return $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8'>
                    <title>Kết quả thanh toán</title>
                    <style>
                        body {{ font-family: Arial; text-align: center; margin-top: 40px; }}
                        .status {{ color: {(isSuccess ? "green" : "red")}; font-size: 20px; }}
                        table {{ margin: 20px auto; border-collapse: collapse; }}
                        td {{ padding: 8px 12px; border: 1px solid #ccc; }}
                    </style>
                </head>
                <body>
                    <h2 class='status'>{(isSuccess ? "Thanh toán thành công" : "Thanh toán thất bại")}</h2>
                    <table>
                        <tr><td><strong>Mã giao dịch:</strong></td><td>{transactionNo}</td></tr>
                        <tr><td><strong>Mã đơn hàng:</strong></td><td>{txnRef}</td></tr>
                        <tr><td><strong>Ngày thanh toán:</strong></td><td>{dateTime}</td></tr>
                        <tr><td><strong>Ngân hàng:</strong></td><td>{bankCode}</td></tr>
                        <tr><td><strong>Số tiền:</strong></td><td>{(int.Parse(amount) / 100):N0} VND</td></tr>
                        <tr><td><strong>Ghi chú:</strong></td><td>{WebUtility.HtmlEncode(orderInfo)}</td></tr>
                        <tr><td><strong>Trạng thái:</strong></td><td>{responseCode} ({(isSuccess ? "Thành công" : "Thất bại")})</td></tr>
                    </table>
                    <p>Đang quay lại ứng dụng...</p>
                </body>
                </html>";
        }

        public async Task<int[]> GetPaymentSumByMonth()
        {
            return await _paymentRepository.GetPaymentSumByMonth();
        }

        public async Task<int[]> GetPaymentSumByUserId(int id)
        {
            return await _paymentRepository.GetPaymentSumByUserId(id);
        }

        public async Task<int[]> GetPaymentSumByHotelId(int id)
        {
            return await _paymentRepository.GetPaymentSumByHotelId(id);
        }
    }
}
