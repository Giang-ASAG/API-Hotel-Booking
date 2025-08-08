using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH52110843_BLL.Config
{
    public class VnPayConfig
    {
        public const string TmnCode = "APPZFC7N";
        public const string HashSecret = "YONPSVXYSUNSPVKIUOOOWXASIHLLYIFS";
        public const string Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
        public const string ReturnUrl = "http://192.168.1.9:5000/api/Payment/payment-return";
        public const string Version = "2.1.0";
        public const string Command = "pay";
        public const string CurrCode = "VND";
        public const string OrderType = "other";
        public const string Locale = "vn";
    }
}
