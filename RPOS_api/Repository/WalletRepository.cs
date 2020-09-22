using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;


namespace RPOS.Repository
{
    public class WalletRepository
    {
        private string connectionString;
        public WalletRepository()
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

        public void Add( Wallet wel)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO [Wallet] (WalletType)"
                                + " VALUES(@WalletType)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, wel);
            }
        }

       

       

        
        

        public IEnumerable<Wallet> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Wallet>("SELECT * FROM Wallet");
            }
        }

        

        public void Delete(string WallteType)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Wallte"
                             + " WHERE WallteType = @WallteType";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { WallteType = WallteType });
            }
        }

        public void Update(String OldWallteType, Wallet cat)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Wallet SET WalletType = @WallteType"
                               + " WHERE WalletType ="+ OldWallteType;
                dbConnection.Open();
                dbConnection.Execute(sQuery, cat);
            }
        }
    }
}

