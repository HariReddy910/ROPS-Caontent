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
    public class RestaurantPOS_BillingInfoTARepository
    {
        private string connectionString;
        public RestaurantPOS_BillingInfoTARepository()
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

        public void Add(RestaurantPOS_BillingInfoTA RestaurantPOS_BillingInfoTA)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO  RestaurantPOS_BillingInfoTA(Id,BillNo, BillDate,SubTotal, TADiscountPer,ParcelCharges, GrandTotal, Cash, Change, Operator,PaymentMode,BillNote,ExchangeRate,CurrencyCode,DiscountReason,Member_ID )"
                                    + " VALUES(@Id, @BillNo, @BillDate,@SubTotal, @TADiscountPer,@ParcelCharges, @GrandTotal, @Cash, @Change, @Operator,@PaymentMode,@BillNote,@ExchangeRate,@CurrencyCode,@DiscountReason,@Member_ID   )";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoTA);
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoTA> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoTA>("SELECT * FROM  RestaurantPOS_BillingInfoTA");
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoTA> GetAll(DateTime fdate ,DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoTA>("SELECT * FROM  RestaurantPOS_BillingInfoTA where between '" + fdate +"' and '"+tdate+"' ");
            }
        }
        public RestaurantPOS_BillingInfoTA GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_BillingInfoTA"
                               + " WHERE  Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoTA>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_BillingInfoTA"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(RestaurantPOS_BillingInfoTA RestaurantPOS_BillingInfoTA)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_BillingInfoTA SET  BillNo=@BillNo, BillDate=@BillDate,SubTotal=@SubTotal, TADiscountPer=@TADiscountPer, ParcelCharges=@ParcelCharges,GrandTotal=@GrandTotal, Cash=@Cash, Change=@Change, Operator=@Operator,PaymentMode=@PaymentMode,BillNote=@BillNote,ExchangeRate=@ExchangeRate,CurrencyCode=@CurrencyCode,DiscountReason=@DiscountReason,Member_ID=@Member_ID"
                                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoTA);
            }
        }
    }
}
