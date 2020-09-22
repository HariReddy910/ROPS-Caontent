using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class TempRestaurantPOS_OrderInfoKOT
    {
        public int Id { get; set; }
        public string TicketNo { get; set; }
        public System.DateTime BillDate { get; set; }
        public decimal GrandTotal { get; set; }
        public string TableNo { get; set; }
        public string GroupName { get; set; }
        public string Operator { get; set; }
        public string TicketNote { get; set; }

        
    }
}
