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
    public class SupplierLedgerBookRepository
    {
        private string connectionString;
        public SupplierLedgerBookRepository()
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

        public void Add(SupplierLedgerBook vou)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO SupplierLedgerBook ( Date , Name, LedgerNo,Label, Debit, Credit, PartyID)"
                                + " VALUES( @Date, @Name, @LedgerNo,@Label,@Debit,@Credit,@PartyID)";
                dbConnection.Open();
               dbConnection.Execute(sQuery, vou);
            }
        }

        public IEnumerable<SupplierLedgerBook> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<SupplierLedgerBook>("SELECT * FROM SupplierLedgerBook");
            }
        }

        public SupplierLedgerBook GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM SupplierLedgerBook"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<SupplierLedgerBook>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM SupplierLedgerBook"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(SupplierLedgerBook sup)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE SupplierLedgerBook SET Date = @Date,"
                               + " Name = @Name, LedgerNo = @LedgerNo,"
                               + "Label=@Label,Debit=@Debit,"
                               + "Credit=@Credit,PartyID=@PartyID"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, sup);
            }
        }


        public double Getbalance(string supplierId)
        {
            double balance = 0.00;
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID='" + supplierId + "' group By PartyID";
                    Connection.Open();
                balance= dbConnection.ExecuteScalar<double>(sQuery);

                if (balance > 0)
                    return balance;
                else
                    return balance = 0.00;
            }
        }
    }
}
