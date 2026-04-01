using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class HotelDTO
    {
        public int HotelId { get; set; }

        public int? UserId { get; set; }

        public string HotelName { get; set; } = null!;

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public decimal? Star { get; set; }

        public string? Description { get; set; }

        public double? XCoordinate { get; set; }

        public double? YCoordinate { get; set; }
        public bool? Status { get; set; }
        public List<string> ImagePaths { get; set; } = new();
    }
}
