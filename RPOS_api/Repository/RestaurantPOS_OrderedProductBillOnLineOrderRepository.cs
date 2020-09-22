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
    public class RestaurantPOS_OrderedProductBillOnLineOrderRepository
    {
        private string connectionString;
        public RestaurantPOS_OrderedProductBillOnLineOrderRepository()
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

        public void Add(RestaurantPOS_OrderedProductBillOnLineOrder RestaurantPOS_OrderedProductBillOnLineOrder)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " INSERT INTO RestaurantPOS_OrderedProductBillOnLineOrder(BillID, Dish, Rate, Quantity, Amount, VATPer, VATAmount, STPer, STAmount, SCPer, SCAmount, DiscountPer, DiscountAmount, TotalAmount, Notes,OrderCode,OrderId )"
                                          + " VALUES(@BillID, @Dish, @Rate, @Quantity, @Amount, @VATPer, @VATAmount,@STPer,@STAmount,@SCPer,@SCAmount,@DiscountPer,@DiscountAmount,@TotalAmount,@Notes,@OrderCode,@OrderId)";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_OrderedProductBillOnLineOrder);
            }
        }

        public IEnumerable<RestaurantPOS_OrderedProductBillOnLineOrder> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderedProductBillOnLineOrder>("SELECT * FROM  RestaurantPOS_OrderedProductBillOnLineOrder");
            }
        }

        public RestaurantPOS_OrderedProductBillOnLineOrder GetByID(int OP_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_OrderedProductBillOnLineOrder"
                               + " WHERE  OP_ID = @OP_ID";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderedProductBillOnLineOrder>(sQuery, new { OP_ID = OP_ID }).FirstOrDefault();
            }
        }

        public void Delete(int OP_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_OrderedProductBillOnLineOrder"
                             + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { OP_ID = OP_ID });
            }
        }

        public void Update(RestaurantPOS_OrderedProductBillOnLineOrder RestaurantPOS_OrderedProductBillOnLineOrder)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_OrderedProductBillOnLineOrder SET  BillID=@BillID, Dish=@Dish, Rate=@Rate, Quantity=@Quantity, Amount=@Amount, VATPer=@VATPer, VATAmount=@VATAmount,STPer=@STPer,STAmount=@STAmount,SCPer=@SCPer,SCAmount=@SCAmount,DiscountPer=@DiscountPer,DiscountAmount=@DiscountAmount,TotalAmount=@TotalAmount,Notes=@Notes ,OrderCode=@OrderCode,OrderId=@OrderId"
                                             + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_OrderedProductBillOnLineOrder);
            }
        }
    }
}
