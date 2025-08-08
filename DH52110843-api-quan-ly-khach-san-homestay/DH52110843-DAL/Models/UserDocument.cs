using System;
using System.Collections.Generic;

namespace DH52110843_DAL.Models;

public partial class UserDocument
{
    public string CccdNumber { get; set; } = null!;

    public string? TaxCode { get; set; }

    public byte[]? ImageBase64 { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? BankName { get; set; }

    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }

    public int IdDocument { get; set; }

    public int Active { get; set; } //0=gui 1=tuchoi 2=duyệt
}
