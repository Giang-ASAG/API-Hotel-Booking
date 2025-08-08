using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class BookingRoomDTO
    {
        public int BkroomsId { get; set; }

        public int BookingId { get; set; }

        public int RoomId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
