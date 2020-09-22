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
    public class LedgerBookRepository
    {
        private string connectionString;
        public LedgerBookRepository()
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

        public void Add(LedgerBook legerBook)
        {

            using (IDbConnection dbConnection = Connection)
            {

                string sQuery = " INSERT INTO LedgerBook (Date, Name, LedgerNo,Label,Debit,Credit,PartyID)"
                                + " VALUES(@Date, @Name, @LedgerNo,@Label,@Debit,@Credit,@PartyID)";
                dbConnection.Open();
                dbConnection.Query(sQuery, legerBook);
            }
        }

        public IEnumerable<LedgerBook> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<LedgerBook>("SELECT * FROM LedgerBook");
            }
        }

        public LedgerBook GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM LedgerBook"
                               + " WHERE id = @id";
                dbConnection.Open();
                return dbConnection.Query<LedgerBook>(sQuery, new { id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM LedgerBook"
                             + " WHERE  Id = @Id";
                dbConnection.Open();
               dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(LedgerBook LedgerBook)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE LedgerBook SET Date = @Date,"
                               + " Name = @Name, LedgerNo = @LedgerNo,"
                               + " Label = @Label, Debit = @Debit,"
                                + " Credit = @Credit, PartyId = @PartyId"
                               + " WHERE id = @id";
                dbConnection.Open();
                dbConnection.Query(sQuery, LedgerBook);
            }

        }
    }
}