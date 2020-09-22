using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;
using Dapper;


namespace RPOS.Repository
{
    public class Voucher_Repository
    {
        private string connectionString;
        public Voucher_Repository()
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

        public void Add(Voucher vou)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Voucher (ID , VoucherNo , Name, Date,Details, PaymentMode, GrandTotal)"
                                + " VALUES(@ID, @VoucherNo, @Name, @Date,@Details,@PaymentMode,@GrandTotal)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, vou);
            }
        }

        public IEnumerable<Voucher> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Voucher>("SELECT * FROM Voucher");
            }
        }

        public Voucher GetByID(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Voucher"
                               + " WHERE ID = @ID";
                dbConnection.Open();
                return dbConnection.Query<Voucher>(sQuery, new { ID = ID }).FirstOrDefault();
            }
        }

        public void Delete(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Voucher"
                             + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { ID = ID });
            }
        }

        public void Update(Voucher vou)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Voucher SET VoucherNo = @VoucherNo,"
                               + " Name = @Name, Date = @Date,"
                               + "Details=@Details,PaymentMode=@PaymentMode"
                               + " WHERE GrandTotal = @GrandTotal";
                dbConnection.Open();
                dbConnection.Execute(sQuery, vou);
            }
        }

        public int GetId()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "select Max(ID) from voucher";
                dbConnection.Open();
              return  dbConnection.ExecuteScalar<int>(sQuery);
            }
        }
    }
}
