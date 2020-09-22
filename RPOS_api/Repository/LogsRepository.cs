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
    public class LogsRepository
    {
        private string connectionString;
        public LogsRepository()
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

        public void Add(Logs logs)
        {
            var date = System.Convert.ToDateTime(logs.Date);
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Logs(userId, Operation , Date )"
                               + " VALUES(@userId,@Operation , @Date)";
                dbConnection.Open();
                dbConnection.Query(sQuery, logs);
            }
        }

        public IEnumerable<Logs> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Logs>("SELECT * FROM logs");
            }
        }

        public Logs GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Logs"
                               + " WHERE  Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Logs>(sQuery, new {  Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM logs"
                             + " WHERE  Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new {  Id = id });
            }
        }

        public void Update(Logs logs)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE logs SET userId = @userId,"
                               + " Operation = @Operation,Date = @Date"
                               + " WHERE  Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, logs);
            }
        }
    }
}
