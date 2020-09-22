using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Dish
    {
        public string DishName { get; set; }
        public string Category { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public int BackColor { get; set; }
        public string Kitchen { get; set; }
    }
}
