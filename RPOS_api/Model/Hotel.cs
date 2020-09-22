using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string TIN { get; set; }
        public string STNo { get; set; }
        public string CIN { get; set; }
        public string Logo { get; set; }
        public string BaseCurrency { get; set; }
        public string CurrencyCode { get; set; }
        public string TicketFooterMessage { get; set; }

    }
}
