using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
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
        public string  Photo { get; set; }
        public string Active { get; set; }
    }
}
