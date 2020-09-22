using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Active { get; set; }
    }
}