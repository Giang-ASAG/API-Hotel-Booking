using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class RoomService
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public int? RoomTypeId { get; set; }

    public virtual RoomType? RoomType { get; set; }
}
