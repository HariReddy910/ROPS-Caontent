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
    public class Stock_Store_JoinRepository
    {
         private string connectionString;
        public Stock_Store_JoinRepository()
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

        public void Add(List<Stock_Store_Join> Listssj)
        {

            using (IDbConnection dbConnection = Connection)
            {

                foreach (var stockjoin in Listssj)
                {
                    string sQuery = "INSERT INTO Stock_Store_Join ( StockID , Dish,Qty)"
                                    + " VALUES(@StockID,@Dish, @Qty)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, stockjoin);
                    dbConnection.Close();
                }
            }
        }

        public IEnumerable<Stock_Store_Join> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Stock_Store_Join>("SELECT * FROM Stock_Store_Join");
            }
        }

        public Stock_Store_Join GetByID(int SSJ_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Stock_Store_Join"
                               + " WHERE SSJ_ID = @SSJ_ID";
                dbConnection.Open();
                return dbConnection.Query<Stock_Store_Join>(sQuery, new { SSJ_ID = SSJ_ID }).FirstOrDefault();
            }
        }

        public void Delete(int SSJ_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Stock_Store_Join"
                             + " WHERE SSJ_ID = @SSJ_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { SSJ_ID = SSJ_ID });
            }
        }

        public void Update(Stock_Store_Join TemS)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Stock_Store_Join SET StockID=@StockID,Dish = @Dish,Qty = @Qty"
                              + " WHERE SSJ_ID = @SSJ_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, TemS);
            }
        }
    }
}
