using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class BookingDTO
    {
        public int BookingId { get; set; }

        public int? UserId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public double TotalAmount { get; set; }

        public int? Status { get; set; }
    }
    public class BookingMVVMDTO
    {
        public int BookingId { get; set; }

        public int? UserId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public double TotalAmount { get; set; }

        public int? Status { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId {  get; set; }
    }
}
