using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class RoomDTO
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = null!;

        public bool? Status { get; set; }

        public int RoomTypeId { get; set; }
        public bool? Active { get; set; }
    }
}
