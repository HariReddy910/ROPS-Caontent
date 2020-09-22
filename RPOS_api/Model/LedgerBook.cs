using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class LedgerBook
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Name { get; set; }
        public string LedgerNo { get; set; }
        public string Label { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string PartyID { get; set; }
    }
}
