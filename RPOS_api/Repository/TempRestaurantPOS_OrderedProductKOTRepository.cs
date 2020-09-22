using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RPOS.ModelWarehouse;
using Dapper;
using RPOS.Model;

namespace RPOS.Repository
{
    public class TempRestaurantPOS_OrderedProductKOTRepository
    {
        private string connectionString;
       

        public TempRestaurantPOS_OrderedProductKOTRepository()
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

        public void Add(TempRestaurantPOS_OrderedProductKOT Temp)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO TempRestaurantPOS_OrderedProductKOT  (TicketID , Dish , Rate, Quantity, Amount, VATPer, VATAmount, STPer, STAmount, SCPer, SCAmount, DiscountPer, DiscountAmount, TotalAmount, T_Number)"
                                          + " VALUES(@TicketID , @Dish , @Rate, @Quantity, @Amount, @VATPer, @VATAmount,@STPer,@STAmount,@SCPer,@SCAmount,@DiscountPer,@DiscountAmount,@TotalAmount,@T_Number)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Temp);
            }
        }

        public IEnumerable<TempRestaurantPOS_OrderedProductKOT> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TempRestaurantPOS_OrderedProductKOT>("SELECT * FROM TempRestaurantPOS_OrderedProductKOT");
            }
        }

        internal void Update(TempRestaurantPOS_OrderedProductKOTRepository temp)
        {
            throw new NotImplementedException();
        }

        public TempRestaurantPOS_OrderedProductKOT GetByID(int OP_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM TempRestaurantPOS_OrderedProductKOT"
                               + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                return dbConnection.Query<TempRestaurantPOS_OrderedProductKOT>(sQuery, new { OP_ID = @OP_ID }).FirstOrDefault();
            }
        }

        public void Delete(int OP_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM TempRestaurantPOS_OrderedProductKOT"
                             + " WHERE OP_ID=OP_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { OP_ID = @OP_ID });
            }
        }

        public void Update(TempRestaurantPOS_OrderedProductKOT Temp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE TempRestaurantPOS_OrderedProductKOT SET TicketID=@TicketID,Dish=@Dish,Rate=@Rate,Quantity=@Quantity," 
                    + "Amount=@Amount,VATPer=@VatPer,VATAmount=@VATAmount,STPer=@STPer,STAmount=@STAmount,"
                    +"SCPer=@SCPer,SCAmount=SCAmount,DiscountPer=@DiscountPer,DiscountAmount=@DiscountAmount,TotalAmount=@TotalAmount,T_Number=@T_Number"
                + " WHERE OP_ID = @OP_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Temp);
            }
        }

    }
}
