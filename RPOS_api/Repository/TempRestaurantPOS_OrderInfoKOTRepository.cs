using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RPOS.ModelWarehouse;
using Dapper;
using RPOS.Model;

namespace RPOS.Repository
{
    public class TempRestaurantPOS_OrderInfoKOTRepository
    {
        private string connectionString;
        public TempRestaurantPOS_OrderInfoKOTRepository()
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

        public void Add(TempRestaurantPOS_OrderInfoKOT Temp)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO TempRestaurantPOS_OrderInfoKOT  (Id,TicketNo , BillDate , GrandTotal, TableNo, GroupName, Operator, TicketNote)"
                                   + " VALUES(@Id,@TicketNo , @BillDate ,@GrandTotal, @TableNo,@GroupName,@Operator,@TicketNote)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Temp);
            }
        }

        public IEnumerable<TempRestaurantPOS_OrderInfoKOT> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TempRestaurantPOS_OrderInfoKOT>("SELECT * FROM TempRestaurantPOS_OrderInfoKOT");
            }
        }

        public TempRestaurantPOS_OrderInfoKOT GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM TempRestaurantPOS_OrderInfoKOT"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<TempRestaurantPOS_OrderInfoKOT>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM TempRestaurantPOS_OrderInfoKOT"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(TempRestaurantPOS_OrderInfoKOT Temp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE TempRestaurantPOS_OrderInfoKOT SET TicketNo = @TicketNo,"
                               + " BillDate = @BillDate, GrandTotal = @GrandTotal,"
                               + "TableNo=@TableNo,GroupName=@GroupName,Operator=@Operator,TicketNote=@TicketNote"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, Temp);
            }
        }

    }
}
