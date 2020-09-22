using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Voucher
    {
        public int ID { get; set; }
        public string VoucherNo { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public string  Details { get; set; }
        public string PaymentMode { get; set; }
        public Double GrandTotal { get; set; }
        
    }
}
