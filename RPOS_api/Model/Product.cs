using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Product
    {
        public int PID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public virtual  decimal Price { get; set; }
        public int ReorderPoint { get; set; }

    }
}
