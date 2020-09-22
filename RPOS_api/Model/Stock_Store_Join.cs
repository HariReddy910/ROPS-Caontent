using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Stock_Store_Join
    {
        public int SSJ_ID { get; set; }
        public int StockID { get; set; }
        public string Dish { get; set; }
        public int Qty { get; set; }
    }
}
