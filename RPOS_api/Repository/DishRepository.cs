using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using RPOS.Model;

namespace RPOS.Repository
{
    
    public class DishRepository
    {
        private string connectionString;

        public DishRepository()
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

        public void Update(string OldDishName,Dish dish)
        {
            using (IDbConnection idbConnection = Connection)
            {
                string sQuery = "update Dish set DishName=@DishName,Category=@Category,Rate=@Rate,Discount=@Discount,BackColor=@BackColor,Kitchen=@Kitchen where DishName='" + OldDishName+"'";
                idbConnection.Open();
                idbConnection.Query(sQuery, dish);
            }
        }
        public IEnumerable<Dish> GetAll()
        {
            using (IDbConnection idbConnection = Connection)
            {
                idbConnection.Open();
                return idbConnection.Query<Dish>("SELECT * FROM Dish");
            }
        }

        public Dish GetByDishName(string DishName)
        {
            using (IDbConnection idbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Dish where DishName=@DishName";
                idbConnection.Open();  
                return idbConnection.Query<Dish>(sQuery, new { DishName = DishName }).FirstOrDefault();

            }
        }
        public void Add(Dish dish)
        {
            using (IDbConnection idbConnection = Connection)
            {
                string sQuery = " insert into Dish(DishName,Category,Rate,Discount,BackColor,Kitchen)Values(@DishName,@Category,@Rate,@Discount,@Backcolor,@Kitchen)";
                idbConnection.Open();
                idbConnection.Query(sQuery, dish);
            }
        }

        public void Delete(string dishName)
        {
            using (IDbConnection idbConnection = Connection)
            {
                string sQuery = " Delete from Dish where DishName=@DishName";
                idbConnection.Open();
                idbConnection.Query(sQuery,new {DishName=dishName  });
            }
        }
    }
}
