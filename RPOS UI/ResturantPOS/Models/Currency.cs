using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal Rate { get; set; }
    }
}