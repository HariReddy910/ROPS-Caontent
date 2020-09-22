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
    public class Recipe_JoinRepository
    {
        private string connectionString;
        public Recipe_JoinRepository()
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

        public void Add(List<Recipe_Join> Recipe_Join)
        {
            foreach (var data in Recipe_Join)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "INSERT INTO Recipe_Join(RecipeID,ProductID,Quantity,Unit )"
                                  + " VALUES(@RecipeID,@ProductID,@Quantity,@Unit )";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, data);
                    dbConnection.Close();
                }
            }
        }

        public IEnumerable<Recipe_Join> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Recipe_Join>("SELECT * FROM Recipe_Join");
            }
        }

        public Recipe_Join GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Recipe_Join"
                               + " WHERE  RJ_ID = @RJ_ID";

                dbConnection.Open();
                return dbConnection.Query<Recipe_Join>(sQuery, new { RJ_ID = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Recipe_Join"
                             + " WHERE RJ_ID = @RJ_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { RJ_ID = id });
            }
        }

        public void Update(Recipe_Join Recipe_Join)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Recipe_Join SET RecipeID=@RecipeID,ProductID=@ProductID,Quantity=@Quantity,Unit=@Unit   "
                              + " WHERE RJ_ID = @RJ_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, Recipe_Join);
            }
        }
    }
}
