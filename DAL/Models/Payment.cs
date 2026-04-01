using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? BookingId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Note { get; set; }

    public double TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual Booking? Booking { get; set; }
}
