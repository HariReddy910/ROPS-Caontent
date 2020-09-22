using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class RestaurantPOS_OrderedProductBillKOT
    {
        public int OP_ID { get; set; }
        public int BillID { get; set; }
        public string Dish { get; set; }
        public decimal Rate { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal VATPer { get; set; }
        public decimal VATAmount { get; set; }
        public decimal STPer { get; set; }
        public decimal STAmount { get; set; }
        public decimal SCPer { get; set; }
        public decimal SCAmount { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string TableNo { get; set; }
    }
}
