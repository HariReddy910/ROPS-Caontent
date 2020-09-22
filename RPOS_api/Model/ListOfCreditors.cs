using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class ListOfCreditors
    {
        public string SupplierID { get; set; }
        public virtual string Name { get; set; } 
        public string City { get; set; } 
        public string ContactNo { get; set; }
        public decimal Credit { get; set; }
    }
}
