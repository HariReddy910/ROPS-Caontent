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
    public class ExpenseRepository
    {
        private string connectionString;
        public ExpenseRepository()
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

        public void Add(Expense exp)
        {
             
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Expense (ExpenseName,ExpenseType )"
                                + " VALUES(@ExpenseName, @ExpenseType)";
                dbConnection.Open();
                dbConnection.Query(sQuery, exp);
            }
        }

        public IEnumerable<Expense> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Expense>("SELECT * FROM Expense");
            }
        }

        public Expense GetByID(String ExpName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM EmployeeRegistration"
                               + " WHERE ExpenseName = @ExpenseName";
                dbConnection.Open();
                return dbConnection.Query<Expense>(sQuery, new { ExpenseName = ExpName }).FirstOrDefault();
            }
        }

        public void Delete(String ExpName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Expense"
                             + " WHERE ExpenseName=@ExpenseName";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { ExpenseName = ExpName });
            }
        }

        public void Update(string OldExpName,Expense Exp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Expense SET ExpenseName = @ExpenseName, ExpenseType=@ExpenseType Where ExpenseName= '"+OldExpName+"'";
                dbConnection.Open();
                dbConnection.Query(sQuery, Exp);
            }
        }
        

    }
}
