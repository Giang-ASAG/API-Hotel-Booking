using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Bookingroom
{
    public int BkroomsId { get; set; }

    public int BookingId { get; set; }

    public int RoomId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
