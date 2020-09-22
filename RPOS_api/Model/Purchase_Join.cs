using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Purchase_Join :Product
    {
        public int SP_ID { get; set; }
        public string InvoiceNo { get; set; }
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public decimal Qty { get; set; }
        public override  decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public string Warehouse { get; set; }
        public string HasExpirydate { get; set; }
        public string ExpiryDate { get; set; }
    }
}
