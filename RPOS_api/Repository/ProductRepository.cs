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
    public class ProductRepository
    {
        private string connectionString;
        public ProductRepository()
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

        public int id()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Q = "SELECT  top 1 PID FROM Product order by PID desc";
                dbConnection.Open();
                return dbConnection.Execute(Q);
            }
        }

        public void Add(Product Product)
        {
            //int PID = id() + 1;
            //Product.PID = PID;

            using (IDbConnection dbConnection = Connection)
            {
                string Q = "SELECT  top 1 PID FROM Product order by PID desc";
                dbConnection.Open();
                var PID_t = dbConnection.ExecuteScalar(Q);
                int PID = Convert.ToInt32(PID_t);
                 if(PID>0)
                    Product.PID = PID + 1;
                 else  
                Product.PID = PID + 1;
                dbConnection.Close();

                string sQuery = "INSERT INTO Product(PID,ProductCode, ProductName, Category, Description, Unit, Price, ReorderPoint)"
                                         + " VALUES(@PID, @ProductCode,@ProductName, @Category, @Description, @Unit, @Price, @ReorderPoint)";

                dbConnection.Open();
                dbConnection.Query(sQuery, Product);
                dbConnection.Close();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Product>("SELECT * FROM Product");
            }
        }

        public Product GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Product"
                               + " WHERE  PID = @Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Product"
                             + " WHERE PID = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Product Product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Product SET ProductCode=@ProductCode,ProductName=@ProductName, Category=@Category, Description=@Description, Unit=@Unit, Price=@Price, ReorderPoint=@ReorderPoint"
                               + " WHERE PID = @PID";
                dbConnection.Open();
                dbConnection.Query(sQuery, Product);
            }
        }

        public int GetProductCode()
        {
            int id = 0;
             
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "select Max(PID) from Product";
                dbConnection.Open();
              id=  dbConnection.ExecuteScalar<int>(sQuery);
                if (id <= 9)
                    id = id + 1;
                else
                    id = id + 1; 
            }
            return id;
        }


        public IEnumerable<Product> GetCategory()
        { 
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Select Distinct Category from product";
                dbConnection.Open();
             return   dbConnection.Query<Product>(sQuery);
            }
        }
    }
}
