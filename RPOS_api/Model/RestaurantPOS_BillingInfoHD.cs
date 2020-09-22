using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class RestaurantPOS_BillingInfoHD
    {
        public int Id { get; set; }
        public string BillNo { get; set; }
        public System.DateTime BillDate { get; set; }
        public string Operator { get; set; }
        public decimal SubTotal { get; set; }
        public decimal HDDiscountPer { get; set; }
        public decimal HomeDeliveryCharges { get; set; }
        public decimal GrandTotal { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public int Employee_ID { get; set; }
        public string PaymentMode { get; set; }
        public string BillNote { get; set; }
        public string DiscountReason { get; set; }
        public string Member_ID { get; set; }
    }
}
