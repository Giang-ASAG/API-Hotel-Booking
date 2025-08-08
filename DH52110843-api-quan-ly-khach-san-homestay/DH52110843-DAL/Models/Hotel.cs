using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public int? UserId { get; set; }

    public string HotelName { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Description { get; set; }

    public double? XCoordinate { get; set; }

    public double? YCoordinate { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal? Star { get; set; }

    public virtual ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();

    public virtual ICollection<HotelService> HotelServices { get; set; } = new List<HotelService>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();

    public virtual User? User { get; set; }
}
