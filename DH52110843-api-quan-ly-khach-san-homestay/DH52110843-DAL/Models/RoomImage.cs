using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class RoomImage
{
    public int RoomImageId { get; set; }

    public int? RoomTypeId { get; set; }

    public int? ImageId { get; set; }

    public virtual RoomImagesStorage? Image { get; set; }

    public virtual RoomType? RoomType { get; set; }
}
