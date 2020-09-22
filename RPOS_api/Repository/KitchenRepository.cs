using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using RPOS.Model;
namespace RPOS.Repository
{
    public class KitchenRepository
    {
        private string connectionString;
        public KitchenRepository()
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

        public void Add(Kitchen cust)
        {
            
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO [Kitchen] (Kitchenname, Printer, IsEnabled)"
                                + " VALUES(@Kitchenname, @Printer, @IsEnabled)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, cust);
            }
        }

        public IEnumerable<Kitchen> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Kitchen>("SELECT * FROM [Kitchen]");
            }
        }

        public Kitchen GetByID(String  kitchenName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Kitchen"
                               + " WHERE Kitchenname = @kitchenName";
                dbConnection.Open();
                return dbConnection.Query<Kitchen>(sQuery, new { kitchenName = kitchenName }).FirstOrDefault();
            }
        }

        public void Delete(String kitchenName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Kitchen"
                             + " WHERE kitchenName = @kitchenName";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { kitchenName = kitchenName });
            }
        }

        public void Update(string OldKitchenName,Kitchen cust)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Kitchen SET Kitchenname = @Kitchenname,"
                               + " Printer = @Printer, IsEnabled = @IsEnabled"
                               + " WHERE Kitchenname ='"+ OldKitchenName+"'";
                dbConnection.Open();
                dbConnection.Query(sQuery, cust);
            }
        }
    }
}
