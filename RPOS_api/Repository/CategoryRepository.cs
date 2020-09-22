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
    public class CategoryRepository
    {
        private string connectionString;
        public CategoryRepository()
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

        public object Cat_ID { get; private set; }

        public void Add(Category cat)
        {
            
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Category (CategoryName , VAT , ST, SC,BackColor)"
                                + " VALUES(@CategoryName, @VAT, @ST, @SC,@BackColor)";
                dbConnection.Open();
                dbConnection.Query(sQuery, cat);
            }
        }

        public IEnumerable<Category > GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Category >("SELECT * FROM Category");
            }
        }


        public Category  GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Category"
                              + " WHERE Cat_ID = @Cat_ID";
                dbConnection.Open();
                return dbConnection.Query<Category >(sQuery, new { Cat_ID = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Category"
                             + " WHERE Cat_ID = @Cat_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Cat_ID = id });
            }
        }

        public void Update(Category  cat)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Category SET CategoryName = @CategoryName,VAT = @VAT, ST = @ST,SC=@SC, BackColor=@BackColor WHERE Cat_ID = @Cat_ID"; 


                              
                dbConnection.Open();
          dbConnection.Query(sQuery, cat);
            }
        }
    }
}

