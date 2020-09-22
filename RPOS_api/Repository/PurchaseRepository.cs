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
    public class PurchaseRepository
    {
        private string connectionString;
        public PurchaseRepository()
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

        public void Add(Purchase Purchase)
        {
            int id = default(int);
            using (IDbConnection dbConnection = Connection)
            { 
                string sQuery1 = " select max(ST_ID) from Purchase";
                 dbConnection.Open();
                   id = dbConnection.ExecuteScalar<int>(sQuery1);
                id = id + 1;
                Purchase.ST_ID = id;
                dbConnection.Close();
                string sQuery = " INSERT INTO Purchase(ST_ID, InvoiceNo, Date, PurchaseType, Supplier_ID,SubTotal,DiscountPer,Discount,PreviousDue,FreightCharges,OtherCharges,Total,GrandTotal,TotalPayment,PaymentDue,Remarks)"
                                        + " VALUES(@ST_ID, @InvoiceNo, @Date, @PurchaseType, @Supplier_ID,@SubTotal,@DiscountPer,@Discount,@PreviousDue,@FreightCharges,@OtherCharges,@Total,@GrandTotal,@TotalPayment,@PaymentDue,@Remarks)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Purchase);
                dbConnection.Close();
            }
        }

        public IEnumerable<Purchase> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Purchase>("SELECT * FROM Purchase");
            }
        }

        public Purchase GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Purchase"
                               + " WHERE  ST_ID = @Id";

                dbConnection.Open();
                return dbConnection.Query<Purchase>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Purchase"
                             + " WHERE ST_ID = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Purchase Purchase)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Purchase SET ST_ID = @ST_ID, InvoiceNo = @InvoiceNo, Date = @Date, PurchaseType = @PurchaseType, Supplier_ID = @Supplier_ID,SubTotal = @SubTotal,DiscountPer = @DiscountPer,Discount = @Discount,PreviousDue = @PreviousDue,FreightCharges = @FreightCharges,OtherCharges = @OtherCharges,Total = @Total,GrandTotal = @GrandTotal,TotalPayment = @TotalPayment,PaymentDue = @PaymentDue,Remarks = @Remarks"
                                                               + " WHERE ST_ID = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, Purchase);
            }
        }

        public int  GetID()
        {
            int id = default(int);
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " select max(ST_ID) from Purchase";
                dbConnection.Open();
             return  id=  dbConnection.ExecuteScalar<int>(sQuery);
            }
        }
    }
}
