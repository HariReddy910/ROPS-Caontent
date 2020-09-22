using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Recipe_Join
    {
        public int RJ_ID { get; set; }
        public int RecipeID { get; set; }
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
