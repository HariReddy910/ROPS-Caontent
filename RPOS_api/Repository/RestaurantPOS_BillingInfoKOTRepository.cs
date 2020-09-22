using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPOS.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using RPOS.ModelWarehouse;

namespace RPOS.Repository
{
    public class RestaurantPOS_BillingInfoKOTRepository
    {
        private string connectionString;
        public RestaurantPOS_BillingInfoKOTRepository()
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

        public void Add(RestaurantPOS_BillingInfoKOT RestaurantPOS_BillingInfoKOT)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO  RestaurantPOS_BillingInfoKOT(Id, BillNo, BillDate, KOTDiscountPer, GrandTotal, Cash, Change, Operator,PaymentMode,ExchangeRate,CurrencyCode,DiscountReason,Member_ID )"
                                    + " VALUES(@Id, @BillNo, @BillDate, @KOTDiscountPer, @GrandTotal, @Cash, @Change, @Operator,@PaymentMode,@ExchangeRate,@CurrencyCode,@DiscountReason,@Member_ID   )";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoKOT);
            }
        }

       

        //internal void Add(RestaurantPOS_BillingInfoKOT restaurantPOS_BillingInfoKOT)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<RestaurantPOS_BillingInfoKOT> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoKOT>("SELECT * FROM  RestaurantPOS_BillingInfoKOT");
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoKOT> GetAll(DateTime fdate ,DateTime tdate )
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoKOT>("select * from RestaurantPOS_BillingInfoKOT where BillDate between  '"+fdate +"' and '"+tdate+"'");
            }
        }
        public RestaurantPOS_BillingInfoKOT GetByID(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_BillingInfoKOT"
                               + " WHERE  Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoKOT>(sQuery, new { Id = Id }).FirstOrDefault();
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_BillingInfoKOT"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = Id });
            }
        }

        public void Update(RestaurantPOS_BillingInfoKOT RestaurantPOS_BillingInfoKOT)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_BillingInfoKOT SET  BillNo=@BillNo, BillDate=@BillDate, KOTDiscountPer=@KOTDiscountPer, GrandTotal=@GrandTotal, Cash=@Cash, Change=@Change, Operator=@Operator,PaymentMode=@PaymentMode,ExchangeRate=@ExchangeRate,CurrencyCode=@CurrencyCode,DiscountReason=@DiscountReason,Member_ID=@Member_ID"
                                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoKOT);
            }
        }
    }
}
