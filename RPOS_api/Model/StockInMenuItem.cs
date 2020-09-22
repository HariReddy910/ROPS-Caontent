using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class StockInMenuItem
    {
        public string Dish { get; set; }
        public string CategoryName { get; set; }
        public Decimal Qty { get; set; }
    }
}
