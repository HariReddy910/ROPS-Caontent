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
    public class StockTransfer_JoinRepository
    {
        private string connectionString;
        public StockTransfer_JoinRepository()
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

        public void Add(StockTransfer_Join stock)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO StockTransfer_Join  (StockTransferID,Warehouse, ProductID,ExpiryDate,Qty )"
                                + " VALUES(@StockTransferID,@Warehouse,@ProductID,@ExpiryDate,@Qty)";
                
                dbConnection.Open();
      
        dbConnection.Query(sQuery, stock);
            }
        }

       

        public IEnumerable<StockTransfer_Join> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StockTransfer_Join>("SELECT * FROM StockTransfer_Join");
            }
        }
  

        public StockTransfer_Join GetByID(int STJ_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM StockTransfer_Join"
                               + " WHERE STJ_ID = @STJ_ID";
                dbConnection.Open();
                return dbConnection.Query<StockTransfer_Join>(sQuery, new { STJ_ID = STJ_ID }).FirstOrDefault();
            }
        }

        public void Delete(int STJ_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM StockTransfer_Join"
                             + " WHERE STJ_ID = @STJ_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { STJ_ID = STJ_ID });
            }
        }

        public void Update(StockTransfer_Join stock)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE StockTransfer_Join SET StockTransferID=@StockTransferID,Warehouse=@Warehouse,ProductID=@ProductID,ExpiryDate=@ExpiryDate,Qty=@Qty"
                               + " WHERE STJ_ID = @STJ_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, stock);
            }
        }
    }
}
