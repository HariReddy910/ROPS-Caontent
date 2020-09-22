using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;
namespace RPOS.Repository
{
    public class MemberRepository
    {
        private string connectionString;
        public MemberRepository()
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

        public void Add(Member cust)
        {
            var custDOB = System.Convert.ToDateTime(cust.RegistrationDate);
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Member(MemberID,Name, ContactNo, Address,   Active)"
                             + " VALUES(@MemberID,@Name , @ContactNo, @Address ,@Active)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, cust);
            }
        }

        public IEnumerable<Member> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Member>("SELECT * FROM Member");
            }
        }

        public Member GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Member"
                               + " WHERE MemberID = @MemberID";
                dbConnection.Open();
                return dbConnection.Query<Member>(sQuery, new { MemberID = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Member"
                             + " WHERE MemberId = @MemberID";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { MemberID = id });
            }
        }

        public void Update(Member member)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE  Member SET Name = @Name,"
                             + " ContactNo = @ContactNo, Address = @Address,"
                               + "Active = @Active"
                             + " WHERE MemberID = @MemberID";
                dbConnection.Open();
                dbConnection.Query(sQuery, member);
            }
        }

        public int GetId()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Select Max(MemberID) from Member";
                dbConnection.Open();
                return dbConnection.ExecuteScalar<int>(sQuery);
            }
        }
    }
}
