using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class HotelImagesStorage
{
    public int ImageId { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();
}
