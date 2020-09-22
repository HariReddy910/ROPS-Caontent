using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class EmployeeRegistration
    {
        public int EmpId { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfJoining { get; set; }
        public String Photo { get; set; }
        public string Active { get; set; }

    }
}