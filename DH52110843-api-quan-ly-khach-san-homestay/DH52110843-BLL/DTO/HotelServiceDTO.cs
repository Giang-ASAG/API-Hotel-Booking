using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class HotelServiceDTO
    {
        public int ServiceId { get; set; }

        public int? HotelId { get; set; }

        public string ServiceName { get; set; } = null!;

        public string? ServiceInfo { get; set; }
    }
}
