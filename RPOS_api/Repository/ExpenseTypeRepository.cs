using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using RPOS.Model;

namespace RPOS.Repository
{
    public class ExpenseTypeRepository
    {
        private string connectionString;
        public ExpenseTypeRepository()
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

        public void Add(ExpenseType Exp)
        {
             
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO ExpenseType(Type)values(@Type)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Exp);
            }
        }

        public IEnumerable<ExpenseType> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<ExpenseType>("SELECT * FROM ExpenseType");
            }
        }

         

        public void Delete(String Type)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM ExpenseType"
                             + " WHERE Type=@Type";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Type = Type });
            }
        }

        public void Update(String OldType, ExpenseType Exp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE ExpenseType SET Type = @Type Where Type='"+OldType+ "'";
                dbConnection.Open();
                dbConnection.Query(sQuery, Exp);
            }
        }
        

    }
}
