using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class RoomTypeDTO
    {
        public int RoomTypeId { get; set; }

        public string TypeName { get; set; } = null!;

        public string? RoomInfo { get; set; }

        public double Price { get; set; }

        public int Capacity { get; set; }

        public int HotelId { get; set; }
    }
    public class RoomTypeCountDTO
    {
        public int RoomTypeId { get; set; }

        public string TypeName { get; set; } = null!;

        public string? RoomInfo { get; set; }

        public double Price { get; set; }

        public int Capacity { get; set; }

        public int? HotelId { get; set; }
        public int Count {  get; set; }
        public List<string> imgPath { get; set; }
    }
}
