﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Model
{
    public class PosPrinterSetting
    {
        public int Id { get; set; }
        public string PrinterName { get; set; }
        public string PrinterType { get; set; }
        public string IsEnabled { get; set; } 
    }
}
