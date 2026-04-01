using DH52110843_DAL.Data;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly HethonghotelContext db;
        public PaymentRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task addAsync(Payment payment)
        {
            await db.AddAsync(payment);
            await db.SaveChangesAsync();
        }

        public Task<Payment> findPaymentbyBookingIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> findPaymentbyIdAsync(int id)
        {
            var pay =await db.Payments.FindAsync(id);
            if(pay==null) throw new KeyNotFoundException($"Payment = null");
            else
            {
                return pay;
            }
        }

        public async Task<IEnumerable<Payment>> getAllPaymentAsync()
        {
            return await db.Payments.ToListAsync();
        }

        public async Task deleteAsync(int id)
        {
            var pay = await db.Payments.FindAsync(id);
            if (pay == null) throw new KeyNotFoundException($"Payment = null");
            db.Payments.Remove(pay);
            await db.SaveChangesAsync();

        }

        public async Task<int[]> GetPaymentSumByMonth()
        {
            var currentYear = DateTime.Now.Year;

            var monthlySums = await db.Payments
                .Where(p => p.PaymentDate.Value.Year == currentYear)
                .GroupBy(p => p.PaymentDate.Value.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Total = g.Sum(p => (int)p.TotalAmount)
                })
                .ToListAsync();

            // Tạo mảng kết quả 12 tháng
            int[] result = new int[12];

            foreach (var item in monthlySums)
            {
                result[item.Month - 1] = item.Total;
            }

            return result;
        }

        public async Task<int[]> GetPaymentSumByUserId(int id)
        {
            var currentYear = DateTime.Now.Year;

            var monthlyRevenue = await db.Payments
                .Where(p => p.PaymentDate.Value.Year == currentYear &&
                            p.Booking.Bookingrooms.Any(br =>
                                br.Room.RoomType.Hotel.UserId == id))
                .GroupBy(p => p.PaymentDate.Value.Month)
                .Select(g => new { Month = g.Key, Total = g.Sum(x => x.TotalAmount) })
                .ToListAsync();

            // Tạo mảng 12 tháng, gán doanh thu tương ứng
            int[] result = new int[12];
            foreach (var item in monthlyRevenue)
            {
                result[item.Month - 1] =(int) item.Total;
            }

            return result;
        }
        public async Task<int[]> GetPaymentSumByHotelId(int id)
        {
            var currentYear = DateTime.Now.Year;

            var monthlyRevenue = await db.Payments
                .Where(p => p.PaymentDate.HasValue &&
                            p.PaymentDate.Value.Year == currentYear &&
                            p.Booking.Bookingrooms.Any(br =>
                                br.Room.RoomType.HotelId == id))
                .GroupBy(p => p.PaymentDate.Value.Month)
                .Select(g => new { Month = g.Key, Total = g.Sum(x => x.TotalAmount) })
                .ToListAsync();

            int[] result = new int[12];
            foreach (var item in monthlyRevenue)
            {
                result[item.Month - 1] = (int)item.Total; // Ép kiểu từ double sang int
            }

            return result;
        }

    }
}
