using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Models
{
    public class JwtClass
    {
        public string Secret { get; set; }
        public int Lifespan { get; set; }
    }
}
