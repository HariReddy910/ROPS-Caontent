using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class Product_OpeningStock
    {
        public int PS_ID { get; set; }
        public int ProductID { get; set; }
        public string Warehouse { get; set; }
        public decimal Qty { get; set; }
        public string HasExpiryDate { get; set; }
        public string ExpiryDate { get; set; }
    }
}