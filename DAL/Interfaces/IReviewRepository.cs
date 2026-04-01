using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> getAllAsync();
        Task<IEnumerable<Review>> getAllbyHotelIdAsync(int id);
        Task addAsync(Review review);
        Task deleteAsync(int id);


    }
}
