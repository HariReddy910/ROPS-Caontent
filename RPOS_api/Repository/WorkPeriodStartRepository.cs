//work period start repository in front office

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
    public class WorkPeriodStartRepository
    {
        private string connectionString;
        public WorkPeriodStartRepository()
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

        public void Start(WorkPeriodStart Work)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO  WorkPeriodStart (WPStart ,Status)"
                                + " VALUES(@WPStart, @Status)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Work);
            }
        }

       

        public IEnumerable<WorkPeriodStart> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<WorkPeriodStart>("SELECT * FROM WorkPeriodStart");
            }
        }

        

        //internal void Update(WorkPeriodRepository work)
        //{
        //    throw new NotImplementedException();
        //}

        public WorkPeriodStart GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  WorkPeriodStart"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<WorkPeriodStart>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM WorkPeriodStart"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(WorkPeriodStart Work)
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
