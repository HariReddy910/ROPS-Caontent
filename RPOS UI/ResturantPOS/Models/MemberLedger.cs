using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class MemberLedger
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LedgerNo { get; set; }
        public string Label { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int MemberID { get; set; }
    }
}