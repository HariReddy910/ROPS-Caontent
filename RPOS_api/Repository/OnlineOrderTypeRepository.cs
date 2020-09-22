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
    public class OnlineOrderTypeRepository
    {
        private string connectionString;
        public OnlineOrderTypeRepository()
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

        public void Add(OnlineOrderType onlineOrderType)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " INSERT INTO OnlineOrderType (OrderComanyName)"
                                + " VALUES(@OrderComanyName)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, onlineOrderType);
            }
        }

        public IEnumerable<OnlineOrderType> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<OnlineOrderType>("SELECT * FROM OnlineOrderType");
            }
        }

        public OnlineOrderType GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM OnlineOrderType"
                               + " WHERE  Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<OnlineOrderType>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM OnlineOrderType"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(OnlineOrderType onlineOrderType)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE OnlineOrderType SET OrderComanyName = @OrderComanyName"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, onlineOrderType);
            }
        }
    }
}
