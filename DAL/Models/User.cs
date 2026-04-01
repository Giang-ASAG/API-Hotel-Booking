using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public int? UserRoleId { get; set; }

    public DateTime? CreationDate { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual UserRole? UserRole { get; set; }
}
