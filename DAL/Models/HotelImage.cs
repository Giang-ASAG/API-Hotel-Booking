using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class HotelImage
{
    public int HotelImageId { get; set; }

    public int? HotelId { get; set; }

    public int? ImageId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual HotelImagesStorage? Image { get; set; }
}
