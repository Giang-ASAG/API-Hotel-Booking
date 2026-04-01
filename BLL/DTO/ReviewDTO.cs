using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }

        public int? HotelId { get; set; }

        public int UserId { get; set; }
        public int StarRating { get; set; }
        public string? Description { get; set; }
        public string Username { get; set; }
    }
}
