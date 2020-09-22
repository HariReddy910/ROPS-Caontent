using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;
using Dapper;


namespace RPOS.Repository
{
    public class Temp_StockRepository
    {

        private string connectionString;
        public Temp_StockRepository()
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

        public void Add(List<Temp_Stock> Tem)
        {

            using (IDbConnection dbConnection = Connection)
            {
                foreach (var temp in Tem)
                {
                    string Q = "SELECT  top 1 PID FROM Product order by PID desc";
                    dbConnection.Open();
                    var PID_t = dbConnection.ExecuteScalar(Q);
                    int PID = Convert.ToInt32(PID_t);
                    temp.ProductID = PID;
                    dbConnection.Close();
                    string sQuery = "INSERT INTO Temp_Stock (ProductID, Warehouse,Qty,HasExpiryDate,ExpiryDate)"
                                + " VALUES( @ProductID, @Warehouse, @Qty,@HasExpiryDate,@ExpiryDate)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, temp);
                    dbConnection.Close();
                }
            }
        }

        public IEnumerable<Temp_Stock> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock>("SELECT * FROM Temp_Stock");
            }
        }

        public Temp_Stock GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Temp_Stock"
                               + " WHERE Id = Id";
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Temp_Stock"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Temp_Stock Tem)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Temp_Stock SET ProductID = @ProductID,"
                              + "Warehouse=@Warehouse,Qty = @Qty,"
                              + "HasExpiryDate=@HasExpiryDate "
                              + " WHERE  ExpiryDate=@ExpiryDate ";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Tem);
            }
        }
    }
}
