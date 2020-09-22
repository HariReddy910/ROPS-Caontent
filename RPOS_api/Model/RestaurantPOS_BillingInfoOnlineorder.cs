using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class RestaurantPOS_BillingInfoOnlineorder
    {
        public int Id { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TADiscountPer { get; set; }
        public decimal ParcelCharges { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Cash { get; set; }
        public decimal Change { get; set; }
        public string Operator { get; set; }
        public string PaymentMode { get; set; }
        public string BillNote { get; set; }
        public decimal ExchangeRate { get; set; }
        public string CurrencyCode { get; set; }
        public string DiscountReason { get; set; }
        public string Member_ID { get; set; }
    }
}
