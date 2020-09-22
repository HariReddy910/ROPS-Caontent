using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class PurchaseDaybook
    {

                
        public string InvoiceNo { get; set; }
        public virtual DateTime Date { get; set; } 
        public decimal SubTotal { get; set; } 
        public decimal Discount { get; set; }
        public decimal PreviousDue { get; set; }
        public decimal FreightCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal Total { get; set; }  
        public decimal GrandTotal { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal PaymentDue { get; set; }
    }
}
