using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Temp_Stock:Product
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string Warehouse { get; set; }
        public decimal Qty { get; set; }
        public string HasExpiryDate { get; set; }
        public string ExpiryDate { get; set; }
    }
}
