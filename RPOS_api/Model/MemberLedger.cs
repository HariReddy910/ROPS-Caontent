using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class MemberLedger:Member
    {
        public int Id { get; set; }
        public  DateTime Date { get; set; }
        public string LedgerNo { get; set; }
        public string Label { get; set; }
        public decimal Debit { get; set; }
        public  decimal Credit { get; set; }
        public override int MemberID { get; set; }

    }
}
