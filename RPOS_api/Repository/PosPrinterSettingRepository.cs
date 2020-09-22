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
    public class PosPrinterSettingRepository
    {
        private string connectionString;
        public PosPrinterSettingRepository()
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

        public void Add(PosPrinterSetting PosPrinterSetting)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " INSERT INTO PosPrinterSetting(PrinterName, PrinterType, IsEnabled)"
                                       + " VALUES(@PrinterName, @PrinterType, @IsEnabled )";
                dbConnection.Open();
                dbConnection.Execute(sQuery, PosPrinterSetting);
            }
        }

        public IEnumerable<PosPrinterSetting> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<PosPrinterSetting>("SELECT * FROM PosPrinterSetting");
            }
        }

        public PosPrinterSetting GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM PosPrinterSetting"
                               + " WHERE  ID = @Id";
                dbConnection.Open();
                return dbConnection.Query<PosPrinterSetting>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM PosPrinterSetting"
                             + " WHERE ID = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(PosPrinterSetting PosPrinterSetting)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE PosPrinterSetting SET PrinterName=@PrinterName,PrinterType=@PrinterType,IsEnabled=@IsEnabled"
                               + " WHERE ID = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, PosPrinterSetting);
            }
        }
    }
}
