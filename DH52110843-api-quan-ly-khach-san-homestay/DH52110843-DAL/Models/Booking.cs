using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public double TotalAmount { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Bookingroom> Bookingrooms { get; set; } = new List<Bookingroom>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }
}
