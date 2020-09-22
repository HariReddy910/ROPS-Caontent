using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Voucher_OtherDetailsn : Voucher
    {
        public int VD_ID { get; set; }
        public string VoucherID { get; set; }
        public string  Particulars { get; set; }
        public decimal Amount { get; set; }
        public string  Note { get; set; }
        
    }
}
