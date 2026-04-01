using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class HotelService
{
    public int ServiceId { get; set; }

    public int? HotelId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? ServiceInfo { get; set; }

    public virtual Hotel? Hotel { get; set; }
}
