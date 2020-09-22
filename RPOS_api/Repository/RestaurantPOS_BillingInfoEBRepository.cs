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
    public class RestaurantPOS_BillingInfoEBRepository
    {
        private string connectionString;
        public RestaurantPOS_BillingInfoEBRepository()
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

        public void Add(RestaurantPOS_BillingInfoEB Recipe_Join)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO  RestaurantPOS_BillingInfoEB(Id, BillNo, BillDate, EBDiscountPer, GrandTotal, Cash, Change, Operator,PaymentMode,BillNote,ExchangeRate,CurrencyCode,EB_Status,DiscountReason,Member_ID )"
                                    + " VALUES(@Id, @BillNo, @BillDate, @EBDiscountPer, @GrandTotal, @Cash, @Change, @Operator,@PaymentMode,@BillNote,@ExchangeRate,@CurrencyCode,@EB_Status,@DiscountReason,@Member_ID   )";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Recipe_Join);
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>("SELECT * FROM  RestaurantPOS_BillingInfoEB");
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetAll(DateTime fdate ,DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>("SELECT * FROM  RestaurantPOS_BillingInfoEB where BillDate between '"+fdate +"' and '"+tdate +"'");
            }
        }



        public RestaurantPOS_BillingInfoEB GetByID(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  RestaurantPOS_BillingInfoEB"
                               + " WHERE  ID = @ID";

                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { ID = Id }).FirstOrDefault();
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  RestaurantPOS_BillingInfoEB"
                             + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new {ID = Id });
            }
        }

        public void Update(RestaurantPOS_BillingInfoEB RestaurantPOS_BillingInfoEB)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE RestaurantPOS_BillingInfoEB SET  BillNo=@BillNo, BillDate=@BillDate, EBDiscountPer=@EBDiscountPer, GrandTotal=@GrandTotal, Cash=@Cash, Change=@Change, Operator=@Operator,PaymentMode=@PaymentMode,BillNote=@BillNote,ExchangeRate=@ExchangeRate,CurrencyCode=@CurrencyCode,EB_Status=@EB_Status,DiscountReason=@DiscountReason,Member_ID=@Member_ID"
                                             + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, RestaurantPOS_BillingInfoEB);
            }
        }


        public RestaurantPOS_BillingInfoEB GetOprator(DateTime fdate ,DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate >=@fdate and BillDate <= @tdate union select Operator from RestaurantPOS_BillingInfoTA where BillDate >=@fdate and BillDate <= @tdate union select Operator from RestaurantPOS_BillingInfoHD where BillDate >=@fdate and BillDate <=@tdate Union select Operator from RestaurantPOS_BillingInfoEB where BillDate >=@fdate and BillDate <= @tdate";
                dbConnection.Open();
               return  dbConnection.ExecuteScalar<RestaurantPOS_BillingInfoEB>(sQuery,new {fdate=fdate,tdate=tdate });
            }
        }


        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator1(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " SELECT Operator,Sum(GrandTotal) as [GrandTotal] from(Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate <= @d2  Union all Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate <= @d2 Union all Select Operator,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate <= @d2 Union all Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate <= @d2)G  group by Operator order by 1";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d1 = fdate, d2= tdate });
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator2(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " SELECT Category,Sum(TotalAmount) as Total from (Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT,Dish, RestaurantPOS_BillingInfoKOT where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.Dishname and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d3 and BillDate <= @d4 UNION ALL Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA,Dish, RestaurantPOS_BillingInfoTA where RestaurantPOS_OrderedProductBillTA.Dish=Dish.Dishname and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d3 and BillDate <= @d4 UNION ALL Select category,(TotalAmount) as [TotalAmount] from RestaurantPOS_OrderedProductBillHD,Dish, RestaurantPOS_BillingInfoHD where RestaurantPOS_OrderedProductBillHD.Dish=Dish.Dishname and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d3 and BillDate <= @d4 Union all Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB,Dish, RestaurantPOS_BillingInfoEB where RestaurantPOS_OrderedProductBillEB.Dish=Dish.Dishname and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d3 and BillDate <= @d4)C group by Category order by 1";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d3 = fdate, d4 = tdate });
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator3(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT Category,Sum(Quantity) as TotalQuantity from (Select category,Quantity from RestaurantPOS_OrderedProductBillKOT,Dish, RestaurantPOS_BillingInfoKOT where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.Dishname and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d5 and BillDate <= @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillTA,Dish, RestaurantPOS_BillingInfoTA where RestaurantPOS_OrderedProductBillTA.Dish=Dish.Dishname and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d5 and BillDate <= @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillHD,Dish, RestaurantPOS_BillingInfoHD where RestaurantPOS_OrderedProductBillHD.Dish=Dish.Dishname and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d5 and BillDate <= @d6 Union all Select category,Quantity from RestaurantPOS_OrderedProductBillEB,Dish, RestaurantPOS_BillingInfoEB where RestaurantPOS_OrderedProductBillEB.Dish=Dish.Dishname and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d5 and BillDate <= @d6)C group by Category order by 1";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d5 = fdate, d6 = tdate });
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator4(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT Category,Sum(Quantity) as TotalQuantity from (Select category,Quantity from RestaurantPOS_OrderedProductBillKOT,Dish, RestaurantPOS_BillingInfoKOT where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.Dishname and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d5 and BillDate <= @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillTA,Dish, RestaurantPOS_BillingInfoTA where RestaurantPOS_OrderedProductBillTA.Dish=Dish.Dishname and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d5 and BillDate <= @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillHD,Dish, RestaurantPOS_BillingInfoHD where RestaurantPOS_OrderedProductBillHD.Dish=Dish.Dishname and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d5 and BillDate <= @d6 Union all Select category,Quantity from RestaurantPOS_OrderedProductBillEB,Dish, RestaurantPOS_BillingInfoEB where RestaurantPOS_OrderedProductBillEB.Dish=Dish.Dishname and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d5 and BillDate <= @d6)C group by Category order by 1";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d5 = fdate, d6 = tdate });
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator5(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT Dish,Sum(Quantity) as [Quantity],Sum(TotalAmount) as [Amount] from (Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT,RestaurantPOS_BillingInfoKOT where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID Union All Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA,RestaurantPOS_BillingInfoTA where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID Union All Select Dish,Quantity,TotalAmount as [TotalAmount] from RestaurantPOS_OrderedProductBillHD,RestaurantPOS_BillingInfoHD where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID Union all Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB,RestaurantPOS_BillingInfoEB where BillDate >=@d7 and BillDate <= @d8 and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID)G  group by Dish order by 1";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d7 = fdate, d8 = tdate });
            }
        }


        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator6(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT PaymentMode,Sum(GrandTotal) as [GrandTotal] from (Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoKOT where BillDate >=@d11 and BillDate <= @d12 Union All Select  PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoTA where BillDate >=@d11 and BillDate <= @d12 Union All Select  PaymentMode,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD where BillDate >=@d11 and BillDate <= @d12 Union all Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoEB where BillDate >=@d11 and BillDate <= @d12)G  group by PaymentMode order by 1";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d11 = fdate, d12 = tdate });
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator7(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "select IsNull(Sum(HomeDeliveryCharges),0) from RestaurantPOS_BillingInfoHD where BillDate >=@d9 and BillDate <= @d10";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d9 = fdate, d10 = tdate });
            }
        }

        public IEnumerable<RestaurantPOS_BillingInfoEB> GetOprator8(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "select IsNull(Sum(ParcelCharges*ExchangeRate),0) from RestaurantPOS_BillingInfoTA where BillDate >=@d11 and BillDate <= @d12";
                dbConnection.Open();
                return dbConnection.Query<RestaurantPOS_BillingInfoEB>(sQuery, new { d11 = fdate, d12 = tdate });
            }
        }
    }
}
