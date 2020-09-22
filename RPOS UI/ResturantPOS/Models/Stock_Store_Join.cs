using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantPOS.Models
{
    public class Stock_Store
    {
        public int St_ID { get; set; }
        public string Remarks { get; set; }
        public DateTime Date { get; set; }
        
    }
    public class Stock_Store_myjoin
    {
        public int SSJ_ID { get; set; }
        public int StockID { get; set; }
        public string Dish { get; set; }
        public int Qty { get; set; }

    }
}