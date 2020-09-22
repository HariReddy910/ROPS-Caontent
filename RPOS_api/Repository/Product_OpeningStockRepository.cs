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
    public class Product_OpeningStockRepository
    {
        private string connectionString;
        public Product_OpeningStockRepository()
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

        public void Add(List<Product_OpeningStock> Product_OpeningStock)
        {

            using (IDbConnection dbConnection = Connection)
            {
                foreach (var temp in Product_OpeningStock)
                {
                    string Q = "SELECT  top 1 PID FROM Product order by PID desc";
                    dbConnection.Open();
                    var PID_t = dbConnection.ExecuteScalar(Q);
                    int PID = Convert.ToInt32(PID_t);
                    temp.ProductID = PID;
                    dbConnection.Close();
                    string sQuery = "INSERT INTO Product_OpeningStock(ProductID, Warehouse, Qty, HasExpiryDate, ExpiryDate)"
                                            + " VALUES(@ProductID, @Warehouse, @Qty, @HasExpiryDate, @ExpiryDate)";
                    dbConnection.Open();
                    dbConnection.Query(sQuery, temp);
                    dbConnection.Close();
                }
            }
        }

        public IEnumerable<Product_OpeningStock> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Product_OpeningStock>("SELECT * FROM Product_OpeningStock");
            }
        }

        public Product_OpeningStock GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Product_OpeningStock"
                               + " WHERE  PS_ID = @PS_ID";
                 
                dbConnection.Open();
                return dbConnection.Query<Product_OpeningStock>(sQuery, new { PS_ID = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Product_OpeningStock"
                             + " WHERE PS_ID = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Product_OpeningStock Product_OpeningStock)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Product_OpeningStock SET ProductID=@ProductID, Warehouse=@Warehouse, Qty=@Qty, HasExpiryDate=@HasExpiryDate, ExpiryDate=@ExpiryDate"
                               + " WHERE PS_ID = @PS_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, Product_OpeningStock);
            }
        }
    }
}
