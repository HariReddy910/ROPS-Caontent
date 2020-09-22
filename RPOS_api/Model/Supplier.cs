using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Supplier :Purchase
    {
        public int ID { get; set; }
        public string SupplierID { get; set; }
        public virtual  string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public override  string Remarks { get; set; }
        public string TIN { get; set; }
        public string STNo { get; set; }
        public string CST { get; set; }
        public string PAN { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public string OpeningBalanceType { get; set; }
    }
}
