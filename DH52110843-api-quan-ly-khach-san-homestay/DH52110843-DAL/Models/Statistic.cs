using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class Statistic
{
    public int StatisticId { get; set; }

    public int? PaymentId { get; set; }

    public int? MonthId { get; set; }

    public virtual Month? Month { get; set; }

    public virtual Payment? Payment { get; set; }
}
