using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Recipe
    {
        public int R_ID { get; set; }
        public string RecipeName { get; set; }
        public string Dish { get; set; }
        public decimal FixedCost { get; set; }
        public string Description { get; set; }
    }
}
