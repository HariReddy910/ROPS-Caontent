using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal Rate { get; set; }
    }
}
