using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPOS.Repository
{
    public class GetDatabaseConnection
    {
        private static string _sqlConnection = @"Server=LAPTOP-TFB4G1S9\SQLEXPRESS;Database=RPOS_DB;Trusted_Connection=true;";
        public static string SetConnection {
            get {
                 return _sqlConnection;
            }
        }
    }
}
