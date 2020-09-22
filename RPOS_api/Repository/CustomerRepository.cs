using Dapper;
using System.Collections.Generic;
using System.Linq;
using RPOS.Model;
using System.Data;
using System.Data.SqlClient;

namespace RPOS.Repository
{
    public class CustomerRepository
    {
        private string connectionString;
        public CustomerRepository()
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

        public void Add(Customer cust)
        {
            var custDOB = System.Convert.ToDateTime(cust.CustomerDOB);
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Customer (CustomerName, CustomerDOB, Contact, TicketId)"
                                + " VALUES(@CustomerName, @CustomerDOB, @Contact, @TicketId)";
                dbConnection.Open();
                dbConnection.Query(sQuery, cust);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Customer>("SELECT * FROM Customer");
            }
        }

        public Customer GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Customer"
                               + " WHERE CustomerId = @CustomerId";
                dbConnection.Open();
                return dbConnection.Query<Customer>(sQuery, new { CustomerId = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Customer"
                             + " WHERE CustomerId = @CustomerId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { CustomerId = id });
            }
        }

        public void Update(Customer cust)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Customer SET CustomerName = @CustomerName,"
                               + " Contact = @Contact, TicketId = @TicketId"
                               + " WHERE CustomerId = @CustomerId";
                dbConnection.Open();
                dbConnection.Query(sQuery, cust);
            }
        }
    }
}

