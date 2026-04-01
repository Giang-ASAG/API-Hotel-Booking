using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class UserDocumentDTO
    {
        public string CccdNumber { get; set; } = null!;

        public string? TaxCode { get; set; }

        public byte[]? ImageBase64 { get; set; }

        public string? BankAccountNumber { get; set; }

        public string? BankName { get; set; }

        public DateTime CreatedAt { get; set; }
        public int IdDocument { get; set; }
        public int Active { get; set; }
        public int UserId { get; set; }

    }
}
