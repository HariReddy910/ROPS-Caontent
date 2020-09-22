using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class StockTransfer_Join
    {
        public int STJ_ID { get; set; }
        public int StockTransferID { get; set; }
        public string Warehouse { get; set; }
        public int ProductID { get; set; }
        public string ExpiryDate { get; set; }
        public decimal Qty { get; set; }

    }
}