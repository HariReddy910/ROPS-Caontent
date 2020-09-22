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
    public class RestaurantPOS_BillingInfoOnlineorderRepository
    {
        private string connectionString;
        public RestaurantPOS_BillingInfoOnlineorderRepository()
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

        public void Add(RestaurantPOS_BillingInfoOnlineorder RestaurantPOS_BillingInfoOnlineorder)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO  RestaurantPOS_BillingInfoOnlineorder( BillNo, BillDate, SubTotal,TADiscountPer,ParcelCharges, GrandTotal, Cash, Change, Operator,PaymentMode,BillNote,ExchangeRate,CurrencyCode,DiscountReason,Member_ID )"
                                    + " VALUES( @BillNo, @BillDate,@SubTotal, @TADiscountPer,@ParcelCharges, @GrandTotal, @Cash, @Change, @Operator,@PaymentMode,@BillNote,@ExchangeRate,@CurrencyCode,@DiscountReason,@Member_ID   )";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoOnlineorder);
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoOnlineorder> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoOnlineorder>("SELECT * FROM  RestaurantPOS_BillingInfoOnlineorder");
            }
        }
        public IEnumerable<RestaurantPOS_BillingInfoOnlineorder> GetAll(DateTime fdate ,DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoOnlineorder>("SELECT * FROM  RestaurantPOS_BillingInfoOnlineorder where BillDate between '"+fdate +"' and '"+tdate +"'");
            }
        }
        public RestaurantPOS_BillingInfoOnlineorder GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_BillingInfoOnlineorder"
                               + " WHERE  Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoOnlineorder>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_BillingInfoOnlineorder"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(RestaurantPOS_BillingInfoOnlineorder RestaurantPOS_BillingInfoOnlineorder)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_BillingInfoOnlineorder SET  BillNo=@BillNo, BillDate=@BillDate, SubTotal=@SubTotal,TADiscountPer=@TADiscountPer,ParcelCharges=@ParcelCharges, GrandTotal=@GrandTotal, Cash=@Cash, Change=@Change, Operator=@Operator,PaymentMode=@PaymentMode,BillNote=@BillNote,ExchangeRate=@ExchangeRate,CurrencyCode=@CurrencyCode,DiscountReason=@DiscountReason,Member_ID=@Member_ID"
                                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoOnlineorder);
            }
        }
    }
}
