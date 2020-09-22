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
    public class NotesMasterRepository
    {
        private string connectionString;
        public NotesMasterRepository()
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

        public void Add(NotesMaster memberLedger)
        {
             
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " INSERT INTO NotesMaster (Notes)"
                                + " VALUES(@Notes)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, memberLedger);
            }
        }

        public IEnumerable<NotesMaster> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<NotesMaster>("SELECT * FROM NotesMaster");
            }
        }

        public NotesMaster GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM NotesMaster"
                               + " WHERE  Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<NotesMaster>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM NotesMaster"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(NotesMaster cust)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE NotesMaster SET Notes = @Notes" 
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, cust);
            }
        }
    }
}
