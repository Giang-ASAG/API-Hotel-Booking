using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_DAL.Models
{
    public class OtpStore
    {
        public string Code { get; set; }
        public DateTime Time {  get; set; }
    }

    public static class OtpMemoryStore
    {
        public static ConcurrentDictionary<String, OtpStore> MemoryStore = new ConcurrentDictionary<string, OtpStore>();
    }
}
