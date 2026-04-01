using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public bool? Status { get; set; }

    public int? RoomTypeId { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Bookingroom> Bookingrooms { get; set; } = new List<Bookingroom>();

    public virtual RoomType? RoomType { get; set; }
}
