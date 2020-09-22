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
    public class RestaurantPOS_OrderedProductBillEBRepository
    {
        private string connectionString;
        public RestaurantPOS_OrderedProductBillEBRepository()
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

        public void Add(RestaurantPOS_OrderedProductBillEB RestaurantPOS_OrderedProductBillEB)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " INSERT INTO RestaurantPOS_OrderedProductBillEB(BillID, Dish, Rate, Quantity, Amount, VATPer, VATAmount,STPer,STAmount, SCPer, SCAmount, DiscountPer, DiscountAmount, TotalAmount, Notes )"
                                          + " VALUES(@BillID, @Dish, @Rate, @Quantity, @Amount, @VATPer, @VATAmount,@STPer,@STAmount,@SCPer,@SCAmount,@DiscountPer,@DiscountAmount,@TotalAmount,@Notes   )";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_OrderedProductBillEB);
            }
        }

        public IEnumerable<RestaurantPOS_OrderedProductBillEB> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderedProductBillEB>("SELECT * FROM  RestaurantPOS_OrderedProductBillEB");
            }
        }
        

        public RestaurantPOS_OrderedProductBillEB GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_OrderedProductBillEB"
                               + " WHERE  OP_ID = @OP_ID";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderedProductBillEB>(sQuery, new { OP_ID = id }).FirstOrDefault();
            }
        }

        public void Delete(int OP_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_OrderedProductBillEB"
                             + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { OP_ID = OP_ID });
            }
        }

        public void Update(RestaurantPOS_OrderedProductBillEB RestaurantPOS_OrderedProductBillEB)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_OrderedProductBillEB SET  BillID=@BillID, Dish=@Dish, Rate=@Rate, Quantity=@Quantity, Amount=@Amount, VATPer=@VATPer, VATAmount=@VATAmount,STPer=@STPer,STAmount=@STAmount,SCPer=@SCPer,SCAmount=@SCAmount,DiscountPer=@DiscountPer,DiscountAmount=@DiscountAmount,TotalAmount=@TotalAmount,Notes=@Notes"
                                             + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_OrderedProductBillEB);
            }
        }
    }
}
