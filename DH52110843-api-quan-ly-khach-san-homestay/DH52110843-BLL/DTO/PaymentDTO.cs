using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.DTO
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }

        public int? BookingId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string? Note { get; set; }

        public double TotalAmount { get; set; }

        public string? PaymentMethod { get; set; }
    }
}
