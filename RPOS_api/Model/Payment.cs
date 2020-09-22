using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Payment
    {
        public int T_ID { get; set; }
        public string TransactionID { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMode { get; set; }
        public int SupplierID { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string PaymentModeDetails { get; set; } 

    }
}
