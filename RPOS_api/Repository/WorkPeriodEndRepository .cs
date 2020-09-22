//work period start and end in front office

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;
namespace RPOS.Repository
{
    public class WorkPeriodEndRepository
    {
        private string connectionString;
        public WorkPeriodEndRepository()
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

        

        public void End(WorkPeriodEnd Work)
        {

            using (IDbConnection dbConnection = Connection)
            {
             string sQuery = "INSERT INTO  WorkPeriodEnd (ID,WPEnd)"
                                + " VALUES(@id,@WPEnd)";
                dbConnection.Open();
               dbConnection.Execute(sQuery, Work);
            }
        }

        public IEnumerable<WorkPeriodEnd> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<WorkPeriodEnd>("SELECT * FROM WorkPeriodEnd");
            }
        }

        

        //internal void Update(WorkPeriodRepository work)
        //{
        //    throw new NotImplementedException();
        //}

        public WorkPeriodEnd GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  WorkPeriodEnd"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<WorkPeriodEnd>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM WorkPeriodEnd"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(WorkPeriodEnd Work)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Category SET WorkPeriodStart = @WPStart,"
                               + " Status = @Status"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Work);
            }
        }
    }
}
