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
    public class RestaurantPOS_OrderInfoKOTRepsitory
    {
        private string connectionString;
        public RestaurantPOS_OrderInfoKOTRepsitory()
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

        public void Add(RestaurantPOS_OrderInfoKOT RestaurantPOS_OrderInfoKOT)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO RestaurantPOS_OrderInfoKOT(TicketNo, BillDate, GrandTotal, TableNo, Operator, GroupName, TicketNote )"
                                          + " VALUES( @TicketNo, @BillDate, @GrandTotal, @TableNo, @Operator, @GroupName, @TicketNote)";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_OrderInfoKOT);
            }
        }

        public IEnumerable<RestaurantPOS_OrderInfoKOT> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderInfoKOT>("SELECT * FROM  RestaurantPOS_OrderInfoKOT");
            }
        }

        public RestaurantPOS_OrderInfoKOT GetByID(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_OrderInfoKOT"
                               + " WHERE  ID = @ID";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderInfoKOT>(sQuery, new { ID = ID }).FirstOrDefault();
            }
        }

        public void Delete(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_OrderInfoKOT"
                             + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { ID = ID });
            }
        }

        public void Update(RestaurantPOS_OrderInfoKOT RestaurantPOS_OrderInfoKOT)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_OrderInfoKOT SET  TicketNo=@TicketNo, BillDate=@BillDate, GrandTotal=@GrandTotal, TableNo=@TableNo, Operator=@Operator, GroupName=@GroupName, TicketNote=@TicketNote"
                                             + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_OrderInfoKOT);
            }
        }
    }
}
