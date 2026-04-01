using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class RoomImagesStorage
{
    public int ImageId { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();
}
