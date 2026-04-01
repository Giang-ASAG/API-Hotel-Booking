using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? HotelId { get; set; }

    public int? UserId { get; set; }

    public string? Description { get; set; }

    public int StarRating { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual User? User { get; set; }
}
