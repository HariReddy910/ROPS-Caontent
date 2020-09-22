using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class Logs
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Operation { get; set; }
        public DateTime Date { get; set; }
    }
}
