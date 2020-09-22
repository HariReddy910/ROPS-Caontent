using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class Registration
    {
        public string UserID { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Active { get; set; }
    }
}