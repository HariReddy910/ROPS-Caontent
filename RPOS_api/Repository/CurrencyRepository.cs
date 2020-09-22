using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using RPOS.Model;
using RPOS.ModelWarehouse;

namespace RPOS.Repository
{
    public class CurrencyRepository
    {
        private string connectionString;

        public CurrencyRepository()
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

        public void Add(Currency curr)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Currency (CurrencyCode , CurrencyName, Rate)"
                                + " VALUES(@Currencycode, @CurrencyName, @Rate)";
                dbConnection.Open();
                dbConnection.Query(sQuery, curr);
            }
        }

        public IEnumerable<Currency> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Currency>("SELECT * FROM Currency");
            }
        }

        public Currency GetByID(string CurrencyCode)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Currency"
                               + " WHERE CurrencyCode = @CurrencyCode";
                dbConnection.Open();
                return dbConnection.Query<Currency>(sQuery, new { CurrencyCode = CurrencyCode  }).FirstOrDefault();
            }
        }
        public void Delete(string  currencyCode)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Currency"
                             + " WHERE CurrencyCode = @CurrencyCode";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { CurrencyCode = currencyCode  });
            }
        }

        public void Update(string OldcurrencyCode,Currency  curr  )
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery1 = "update RestaurantPOS_BillingInfoEB set CurrencyCode=@CurrencyCode where CurrencyCode='"+OldcurrencyCode+"'" ; 
                dbConnection.Open();
                dbConnection.Query(sQuery1, curr);
                dbConnection.Close();

                string sQuery2 = "update RestaurantPOS_BillingInfoKOT set CurrencyCode=@CurrencyCode where CurrencyCode='"+ OldcurrencyCode+"'";; 
                dbConnection.Open();
                dbConnection.Query(sQuery2, curr);
                dbConnection.Close();

                string sQuery3 = "update RestaurantPOS_BillingInfoTA set CurrencyCode=@CurrencyCode where CurrencyCode='" + OldcurrencyCode + "'"; ;
                dbConnection.Open();
                dbConnection.Query(sQuery3, curr);
                dbConnection.Close();


                string sQuery = " Update Currency set CurrencyName=@CurrencyName,CurrencyCode=@CurrencyCode,Rate=@Rate where CurrencyCode='"+ OldcurrencyCode+"'";
                               ;
                dbConnection.Open();
                dbConnection.Query(sQuery, curr);
            }
        }
    }
}

