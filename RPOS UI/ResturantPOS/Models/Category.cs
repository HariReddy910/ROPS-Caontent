using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class Category
    {
        public int Cat_ID { get; set; }
        public string CategoryName { get; set; }
        public decimal ST { get; set; }
        public decimal VAT { get; set; }
        public decimal SC { get; set; }
        public String BkColor { get; set; }
    }
}