using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantPOS.Models
{
    public class EmailSetting
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public string SMTPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string TLS_SSL_Required { get; set; }
        public string IsDefault { get; set; }
        public string IsActive { get; set; }
    }
}