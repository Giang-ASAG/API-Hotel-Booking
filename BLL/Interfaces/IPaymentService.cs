using DH52110843_BLL.DTO;
using DH52110843_BLL.DTO.VNPay;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDTO>> getAllPaymentAsync();
        Task addAsync(PaymentDTO payment);
        Task deleteAsync(int id);
        Task<int[]> GetPaymentSumByMonth();
        Task<PaymentDTO> findPaymentbyIdAsync(int id);
        Task<PaymentDTO> findPaymentbyBookingIdAsync(int id);
        public string CreatePaymentUrl(VNPayResquest request, string ipAddress);
        public string GenerateReturnHtml(string responseCode, string transactionNo, string txnRef, string bankCode, string amount, string orderInfo, string paydate);


        Task<int[]> GetPaymentSumByUserId(int id);

        Task<int[]> GetPaymentSumByHotelId(int id);
    }
}
