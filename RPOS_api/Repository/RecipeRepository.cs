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
    public class RecipeRepository
    {
        private string connectionString;
        public RecipeRepository()
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

        public void Add(Recipe Recipe)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Recipe(R_ID,RecipeName,Dish,FixedCost,Description )"
                              + " VALUES(@R_ID,@RecipeName,@Dish,@FixedCost,@Description )";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Recipe);
            }
        }

        public IEnumerable<Recipe> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Recipe>("SELECT * FROM Recipe");
            }
        }

        public Recipe GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Recipe"
                               + " WHERE  R_ID = @R_ID";

                dbConnection.Open();
                return dbConnection.Query<Recipe>(sQuery, new { tableNo = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Recipe"
                             + " WHERE R_ID = @R_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { R_ID = id });
            }
        }

        public void Update(Recipe Recipe)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Recipe SET RecipeName=@RecipeName,Dish=@Dish,FixedCost=@FixedCost,Description=@Description   "
                              + " WHERE R_ID = @R_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, Recipe);
            }
        }

        public int GetId()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "select Max(R_ID) from Recipe";
                dbConnection.Open();
                return dbConnection.ExecuteScalar<int>(sQuery);
            }
        }
    }
}
