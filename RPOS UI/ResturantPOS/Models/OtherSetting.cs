using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class OtherSetting
    {
        public int ID { get; set; }
        public decimal ParcelCharges { get; set; }
        public decimal HomeDeliveryCharges { get; set; }
        public string CashDrawer { get; set; }
        public decimal VAT { get; set; }
        public decimal ServiceTax { get; set; }
        public decimal ServiceCharges { get; set; }
        public string TA { get; set; }
        public string HD { get; set; }
        public string EB { get; set; }
        public string KG { get; set; }
    }
}
