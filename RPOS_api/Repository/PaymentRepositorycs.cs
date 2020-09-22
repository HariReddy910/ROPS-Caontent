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
    public class PaymentRepositorycs
    {
        private string connectionString;
        public PaymentRepositorycs()
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

        public void Add(Payment Payment)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Payment(T_ID,TransactionID, Date, PaymentMode, SupplierID, Amount, Remarks, PaymentModeDetails)"
                                       + " VALUES(@T_ID,@TransactionID, @Date, @PaymentMode, @SupplierID, @Amount,  @Remarks, @PaymentModeDetails)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Payment);
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Payment>("SELECT * FROM Payment");
            }
        }

        public Payment GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Payment"
                               + " WHERE  T_ID = @T_ID";
                dbConnection.Open();
                return dbConnection.Query<Payment>(sQuery, new { T_ID = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Payment"
                             + " WHERE T_ID = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Payment Payment)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Payment SET TransactionID=@TransactionID,Date=@Date,PaymentMode=@PaymentMode,SupplierID=@SupplierID,Amount=@Amount,Remarks=@Remarks,PaymentModeDetails=@PaymentModeDetails"
                               + " WHERE T_ID = T_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, Payment);
            }
        }

        public int GetId()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Select Max(T_ID) from Payment  ";
                dbConnection.Open();
               return dbConnection.ExecuteScalar<int>(sQuery);
            }
        }
    }
}
