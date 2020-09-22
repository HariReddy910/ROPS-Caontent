using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.ModelWarehouse
{
    public class RestaurantPOS_BillingInfoKOT
    {
        public int Id { get; set; }
        public string BillNo { get; set; }
        public System.DateTime BillDate { get; set; }
        public decimal KOTDiscountPer { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Cash { get; set; }
        public decimal Change { get; set; }
        public string Operator { get; set; }
        public string PaymentMode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string CurrencyCode { get; set; }
        public string DiscountReason { get; set; }
        public string Member_ID { get; set; }
    }
}
