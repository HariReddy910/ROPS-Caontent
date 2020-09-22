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
    public class RestaurantPOS_BillingInfoHDRepository
    {
        private string connectionString;
        public RestaurantPOS_BillingInfoHDRepository()
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

        public void Add(RestaurantPOS_BillingInfoHD  RestaurantPOS_BillingInfoHD )
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO  RestaurantPOS_BillingInfoHD(BillNo, BillDate, Operator, HDDiscountPer, SubTotal, HomeDeliveryCharges, GrandTotal, CustomerName, ContactNo, Address, Employee_ID, PaymentMode, BillNote, DiscountReason, Member_ID)"
                                          + " VALUES( @BillNo, @BillDate,@Operator, @HDDiscountPer,@SubTotal,@HomeDeliveryCharges, @GrandTotal,@CustomerName, @ContactNo,@Address ,@Employee_ID, @PaymentMode,@BillNote,@DiscountReason,@Member_ID )";
                dbConnection.Open();
                dbConnection.Execute(sQuery, RestaurantPOS_BillingInfoHD );
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoHD > GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoHD >("SELECT * FROM  RestaurantPOS_BillingInfoHD");
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoHD> GetAll(DateTime fdate,DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoHD>("SELECT * FROM  RestaurantPOS_BillingInfoHD where BillDate between '"+fdate +"' and '"+tdate +"");
            }
        }

        public RestaurantPOS_BillingInfoHD  GetByID(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_BillingInfoHD "
                               + " WHERE  Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoHD >(sQuery, new { Id = Id }).FirstOrDefault();
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_BillingInfoHD "
                             + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { ID = Id });
            }
        }

        public void Update(RestaurantPOS_BillingInfoHD  RestaurantPOS_BillingInfoHD )
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE RestaurantPOS_BillingInfoHD SET  BillNo=@BillNo, BillDate=@BillDate,Operator=@Operator, HDDiscountPer=@HDDiscountPer,SubTotal=@SubTotal,HomeDeliveryCharges=@HomeDeliveryCharges, GrandTotal=@GrandTotal,CustomerName=@CustomerName, ContactNo=@ContactNo,Address=@Address ,Employee_ID=@Employee_ID, PaymentMode=@PaymentMode,BillNote=@BillNote,DiscountReason=@DiscountReason,Member_ID =@Member_ID"
                                             + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoHD );
            }
        }
    }
}
