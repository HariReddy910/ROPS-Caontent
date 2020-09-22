using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantPOS.Models
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