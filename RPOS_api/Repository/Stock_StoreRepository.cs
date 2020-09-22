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
    public class Stock_StoreRepository
    {
        private string connectionString;
        public Stock_StoreRepository()
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

        public void Add(Stock_Store stock)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Stock_Store  (St_ID,Date, Remarks )"
                                + " VALUES(@St_ID,@Date , @Remarks)";

                dbConnection.Open();

                dbConnection.Query(sQuery, stock);
            }
        }



        public IEnumerable<Stock_Store> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Stock_Store>("SELECT * FROM Stock_Store");
            }
        }

        public Stock_Store GetByID(int St_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Stock_Store"
                               + " WHERE St_ID = @St_ID";
                dbConnection.Open();
                return dbConnection.Query<Stock_Store>(sQuery, new { St_ID = St_ID }).FirstOrDefault();
            }
        }

        public void Delete(int St_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Stock_Store"
                             + " WHERE St_ID = @St_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { St_ID = St_ID });
            }
        }

        public void Update(Stock_Store stock)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Stock_Store SET Date=@Date,Remarks=@Remarks"
                               + " WHERE St_ID = @St_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, stock);
            }
        }

        public int GetId()
        {
            int id = 0;
            using (IDbConnection dbconnecton = Connection)
            {
                dbconnecton.Open();
               id=    dbconnecton.ExecuteScalar<int>("select max(st_Id) from Stock_Store");
                if (id > 0)
                    id = id + 1;
                else
                    id = id + 1;
            }
            return id;
        }
    }
}
