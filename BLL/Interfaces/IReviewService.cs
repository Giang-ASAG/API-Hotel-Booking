using DH52110843_BLL.DTO;
using DH52110843_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> getAllAsync();
        Task<IEnumerable<ReviewDTO>> getAllbyHotelIdAsync(int id);
        Task addAsync(ReviewDTO review);
        Task deleteAsync(int id);
    }
}
