//work period start and end in front office

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class WorkPeriodStart
    {
        public int Id { get; set; }
        public System.DateTime WPStart { get; set; }
        public string Status { get; set; }

        public virtual WorkPeriodEnd WorkPeriodEnd { get; set; }
    }

    public class WorkPeriodEnd
    {
        public int Id { get; set; }
        public System.DateTime WPEnd { get; set; }

        public virtual WorkPeriodStart WorkPeriodStart { get; set; }
    }
}

