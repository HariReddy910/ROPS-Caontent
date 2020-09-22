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
    public class Temp_Stock_StoreRepository
    {
        private string connectionString;
        public Temp_Stock_StoreRepository()
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

        public void Add(Temp_Stock_Store TemS)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Temp_Stock_Store (Dish , Qty)"
                                + " VALUES(@Dish, @Qty)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, TemS);
            }
        }

        public IEnumerable<Temp_Stock_Store> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock_Store>("SELECT * FROM Temp_Stock_Store");
            }
        }

        public Temp_Stock_Store GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Temp_Stock_Store"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock_Store>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Temp_Stock_Store"
                             + " WHERE Id = @Id";
                dbConnection.Open();
               dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Temp_Stock_Store TemS)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Temp_Stock_Store SET  Dish = @Dish,Qty = @Qty"
                              + " WHERE Id=@Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, TemS);
            }
        }

    }
}
