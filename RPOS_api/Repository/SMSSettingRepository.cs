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
    public class SMSSettingRepository
    {
        private string connectionString;
        public SMSSettingRepository()
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

        public void Add(SMSSetting SMSSetting)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO SMSSetting(APIURL,IsDefault,IsEnabled )"
                              + " VALUES( @APIURL,@IsDefault,@IsEnabled)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, SMSSetting);
            }
        }

        public IEnumerable<SMSSetting> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<SMSSetting>("SELECT * FROM  SMSSetting");
            }
        }

        public SMSSetting GetByID(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  SMSSetting"
                               + " WHERE  Id = @Id";

                dbConnection.Open();
                return dbConnection.Query<SMSSetting>(sQuery, new { Id = Id }).FirstOrDefault();
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM  SMSSetting"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = Id });
            }
        }

        public void Update(SMSSetting SMSSetting)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE SMSSetting SET  APIURL=@APIURL,IsDefault=@IsDefault,IsEnabled=@IsEnabled"
                                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, SMSSetting);
            }
        }
    }
}
