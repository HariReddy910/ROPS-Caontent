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
    public class RegistrationRepository
    {
        private string connectionString;
        public RegistrationRepository()
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

        public void Add(Registration Recipe_Join)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Registration(UserID, UserType, Password, Name, ContactNo, EmailID, JoiningDate, Active )"
                                    + " VALUES(@UserID,@UserType,@Password,@Name,@ContactNo,@EmailID,@JoiningDate,@Active )";
                dbConnection.Open();
                dbConnection.Query(sQuery, Recipe_Join);
            }
        }

        public IEnumerable<Registration> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Registration>("SELECT * FROM Registration");
            }
        }

        public Registration GetByID(String UserId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Registration"
                               + " WHERE  UserID = @UserID";

                dbConnection.Open();
                return dbConnection.Query<Registration>(sQuery, new { UserID = UserId }).FirstOrDefault();
            }
        }

        public void Delete(String  UserId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Registration"
                             + " WHERE UserID = @UserID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { UserID = UserId });
            }
        }
        
        public void Update(String OldUserId,Registration Registration)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Registration SET UserID = @UserID,UserType = @UserType,Password = @Password,Name = @Name,ContactNo = @ContactNo,EmailID = @EmailID,JoiningDate = @JoiningDate,Active = @Active   "
                                             + " WHERE UserID = '"+ OldUserId + "'";
                dbConnection.Open();
                dbConnection.Query(sQuery, Registration);
            }
        }

        public int ChangePin(String OldUserId, Registration Registration)
        {
            int id = 0;
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "update Registration set password = @Password where userid = @UserID and password = '" + OldUserId + "'";
                dbConnection.Open();
              id= dbConnection.Execute(sQuery, Registration);
                return id;
            }
        }
    }
}
