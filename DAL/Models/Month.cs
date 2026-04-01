using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Month
{
    public int MonthId { get; set; }

    public string Month1 { get; set; } = null!;

    public virtual ICollection<Statistic> Statistics { get; set; } = new List<Statistic>();
}
