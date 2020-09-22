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
    public class EmployeeRegistrationRepository
    {
        private string connectionString;
        public EmployeeRegistrationRepository()
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

        public void Add(EmployeeRegistration Emp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Q = "select max(EmpId)from EmployeeRegistration"; dbConnection.Open(); var EmpId = dbConnection.ExecuteScalar(Q);
                if (Convert.ToInt32(EmpId) > 0)
                {
                    Emp.EmpId = (int)EmpId +1;
                    Emp.EmployeeID = "Emp-" + EmpId +1;
                }
                else
                {
                    EmpId = 1;   
                    Emp.EmpId =(int) EmpId ;
                    

                    Emp.EmployeeID = "Emp-" + EmpId +1;
                }
               // var custDOB = System.Convert.ToDateTime(Emp.DateOfJoining);
            }
       
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO EmployeeRegistration (EmpId,EmployeeID, EmployeeName, Address, City, ContactNo, Email, DateOfJoining, Active, Photo)"
                                + "VALUES(@EmpId,@EmployeeId, @EmployeeName, @Address, @City,@ContactNo,@Email,@dateofJoining,@Active,@Photo)";    
                dbConnection.Open();
                dbConnection.Query(sQuery, Emp);
            }
        }

        public IEnumerable<EmployeeRegistration> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<EmployeeRegistration>("SELECT * FROM EmployeeRegistration");
            }
        }

        public EmployeeRegistration GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM EmployeeRegistration"
                               + " WHERE EmpId = @EmpId";
                dbConnection.Open();
                return dbConnection.Query<EmployeeRegistration>(sQuery, new { EmpId = id }).FirstOrDefault();
            }
        }

        public void Delete(string  id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM EmployeeRegistration"
                             + " WHERE EmpId=@EmpId";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { EmpId = id });
            }
        }

        public void Update(EmployeeRegistration Emp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery ="UPDATE EmployeeRegistration SET EmployeeName = @EmployeeName,Address = @Address,City = @City,ContactNo = @ContactNo,Email = @Email," +
                    "DateOfJoining = @dateofJoining,Active = @Active,Photo = @Photo Where EmpId=@EmpId ";
                dbConnection.Open();
                dbConnection.Query(sQuery, Emp);
            }
        }
        public int GetEmpId()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "select MAX(isnull(EmpId, 0) + 1) from EmployeeRegistration";
                dbConnection.Open();
              return Convert.ToInt32(dbConnection.Query<int>(sQuery));
            }
        }
    }
}
