using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> getAllPaymentAsync();
        Task addAsync(Payment payment);
        Task deleteAsync(int id);

        Task<Payment> findPaymentbyIdAsync(int id);
        Task<Payment> findPaymentbyBookingIdAsync(int id);

        Task<int[]> GetPaymentSumByMonth();
        Task<int[]> GetPaymentSumByUserId(int id);

        Task<int[]> GetPaymentSumByHotelId(int id);

    }
}
