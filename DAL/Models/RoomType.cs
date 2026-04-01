using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? RoomInfo { get; set; }

    public double Price { get; set; }

    public int Capacity { get; set; }

    public int? HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();

    public virtual ICollection<RoomService> RoomServices { get; set; } = new List<RoomService>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
