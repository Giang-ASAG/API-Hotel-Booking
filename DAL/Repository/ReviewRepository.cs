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
    public class ReviewRepository : IReviewRepository
    {
        private readonly HethonghotelContext db;
        public ReviewRepository(HethonghotelContext db)
        {
            this.db = db;
        }
        public async Task addAsync(Review review)
        {
            await db.Reviews.AddAsync(review);
            await db.SaveChangesAsync();
        }

        public async Task deleteAsync(int id)
        {
            var rv = await db.Reviews.FindAsync(id);
            if (rv == null) throw new KeyNotFoundException("Review = null");
            db.Reviews.Remove(rv);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> getAllAsync()
        {
            return await db.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> getAllbyHotelIdAsync(int id)
        {
            return await db.Reviews.Where(x=>x.HotelId==id).ToListAsync();
        }
    }
}
