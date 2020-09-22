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
    public class StockTransferRepository
    {
        private string connectionString;
        public StockTransferRepository()
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
                string sQuery = "INSERT INTO StockTransfer  (Date , Kitchen )"
                                + " VALUES(@Date , @Kitchen)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, stock);
            }
        }

        internal void Add(StockTransferRepository store)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockTransfer> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StockTransfer>("SELECT * FROM StockTransfer");
            }
        }

      

       

        public StockTransfer GetByID(int ST_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM StockTransfer"
                               + " WHERE ST_ID = @ST_ID";
                dbConnection.Open();
                return dbConnection.Query<StockTransfer>(sQuery, new { ST_ID = ST_ID }).FirstOrDefault();
            }
        }

        public void Delete(int ST_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM StockTransfer"
                             + " WHERE ST_ID = @ST_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { ST_ID = ST_ID });
            }
        }

        public void Update(StockTransfer stock)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE StockTransfer SET Date  = @Date"+"Kitchen=@Kitchen"
                               + " WHERE ST_ID = @ST_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, stock);
            }
        }
    }
}
