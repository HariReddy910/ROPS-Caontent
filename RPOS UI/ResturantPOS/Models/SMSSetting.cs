using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class SMSSetting
    {
        public int Id { get; set; }
        public string APIURL { get; set; }
        public string IsDefault { get; set; }
        public string IsEnabled { get; set; }
    }
}