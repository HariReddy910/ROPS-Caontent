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
    public class EmailSettingRepository
    {
        private string connectionString;

        public EmailSettingRepository()
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
        public void Add(EmailSetting emailSetting)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "insert into EmailSetting(ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive)" +
                               " VALUES (@ServerName,@SMTPAddress,@UserName,@Password,@Port,@TLS_SSL_Required,@IsDefault,@IsActive)";
                dbConnection.Open();
                dbConnection.Query(sQuery, emailSetting);
            }
        }

        public void Update(EmailSetting emailSetting)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Update EmailSetting set ServerName=@ServerName, " +
                               "SMTPAddress=@SMTPAddress, Username=@UserName, Password=@Password, Port=@Port," +
                              " TLS_SSL_Required=@TLS_SSL_Required, IsDefault=@IsDefault, IsActive=@IsActive where ID=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, emailSetting);
            }
            
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Delete From EmailSetting Where Id=@id";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { id = id });
            }
        }
        public IEnumerable<EmailSetting> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
               return  dbConnection.Query<EmailSetting>("Select * From EmailSetting");
            }
        }
        public EmailSetting GetById(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Select * From EmailSetting Where Id=@id";
                dbConnection.Open();
                return dbConnection.Query<EmailSetting>(sQuery, new { Id = Id }).SingleOrDefault();
            }
        
        }
    }
}
