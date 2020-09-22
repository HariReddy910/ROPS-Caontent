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
    public class RestaurantPOS_OrderedProductKOTRepository
    {
        private string connectionString;
        public RestaurantPOS_OrderedProductKOTRepository()
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

        public void Add(RestaurantPOS_OrderedProductKOT RestaurantPOS_OrderedProductKOT)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " INSERT INTO RestaurantPOS_OrderedProductKOT(TicketID, Dish, Rate, Quantity, Amount, VATPer, VATAmount, STPer, STAmount, SCPer, SCAmount, DiscountPer, DiscountAmount, TotalAmount, Notes )"
                                          + " VALUES(@TicketID, @Dish, @Rate, @Quantity, @Amount, @VATPer, @VATAmount,@STPer,@STAmount,@SCPer,@SCAmount,@DiscountPer,@DiscountAmount,@TotalAmount,@Notes)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, RestaurantPOS_OrderedProductKOT);
            }
        }

        public IEnumerable<RestaurantPOS_OrderedProductKOT> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderedProductKOT>("SELECT * FROM  RestaurantPOS_OrderedProductKOT");
            }
        }

        public RestaurantPOS_OrderedProductKOT GetByID(int OP_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_OrderedProductKOT"
                               + " WHERE  OP_ID = @OP_ID";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_OrderedProductKOT>(sQuery, new { OP_ID = OP_ID }).FirstOrDefault();
            }
        }

        public void Delete(int OP_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_OrderedProductKOT"
                             + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { OP_ID = OP_ID });
            }
        }

        public void Update(RestaurantPOS_OrderedProductKOT RestaurantPOS_OrderedProductKOT)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_OrderedProductKOT SET  TicketID=@TicketID, Dish=@Dish, Rate=@Rate, Quantity=@Quantity, Amount=@Amount, VATPer=@VATPer, VATAmount=@VATAmount,STPer=@STPer,STAmount=@STAmount,SCPer=@SCPer,SCAmount=@SCAmount,DiscountPer=@DiscountPer,DiscountAmount=@DiscountAmount,TotalAmount=@TotalAmount,Notes=@Notes"
                                             + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_OrderedProductKOT);
            }
        }
    }
}
