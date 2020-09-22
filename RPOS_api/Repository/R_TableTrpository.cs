using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPOS.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace RPOS.Repository
{
    public class R_TableTrpository
    {

        private string connectionString;
        public R_TableTrpository()
        {
            connectionString = GetDatabaseConnection.SetConnection;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(R_Table R_Table)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO R_Table(TableNo,Status,BkColor )"
                                        + " VALUES(@TableNo,@Status,@BkColor )";
                dbConnection.Open();
                dbConnection.Execute(sQuery, R_Table);
            }
        }

        public IEnumerable<R_Table> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<R_Table>("SELECT * FROM R_Table");
            }
        }

        public R_Table GetByID(String tableNo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM R_Table"
                               + " WHERE  TableNo = @TableNo";

                dbConnection.Open();
                return dbConnection.Query<R_Table>(sQuery, new { TableNo = tableNo }).FirstOrDefault();
            }
        }

        public void Delete(String tableNo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM R_Table"
                             + " WHERE TableNo = @TableNo";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { TableNo = tableNo });
            }
        }

        public void Update(string OldTable, R_Table R_Table)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE R_Table SET TableNo=@TableNo,Status=@Status,BkColor=@BkColor "
                     + " WHERE TableNo ='" +OldTable+"'";
                dbConnection.Open();
                dbConnection.Query(sQuery, R_Table);
            }
        }
    }
}
