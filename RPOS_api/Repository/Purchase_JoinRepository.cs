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
    public class Purchase_JoinRepository
    {
        private string connectionString;
        public Purchase_JoinRepository()
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

        public void Add(Purchase_Join Purchase_Join)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Purchase_Join(PurchaseID, ProductID, Qty, Price,TotalAmount,Warehouse,HasExpirydate,ExpiryDate)"
                                        + " VALUES(@PurchaseID, @ProductID, @Qty, @Price,@TotalAmount,@Warehouse,@HasExpirydate,@ExpiryDate)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Purchase_Join);
            }
        }

        public IEnumerable<Purchase_Join> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Purchase_Join>("SELECT * FROM Purchase_Join");
            }
        }

        public Purchase_Join GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Purchase_Join"
                               + " WHERE  SP_ID = @Id";

                dbConnection.Open();
                return dbConnection.Query<Purchase_Join>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Purchase_Join"
                             + " WHERE SP_ID = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Purchase_Join Purchase_Join)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Purchase SET PurchaseID=@PurchaseID, ProductID=@ProductID, Qty=@Qty, Price=@Price,TotalAmount=@TotalAmount,Warehouse=@Warehouse,HasExpirydate=@HasExpirydate,ExpiryDate=@ExpiryDate"
                     + " WHERE SP_ID = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, Purchase_Join);
            }
        }
    }
}
