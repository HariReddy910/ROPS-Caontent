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
    public class OtherSettingRepository
    {
        private string connectionString;
        public OtherSettingRepository()
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

        public void Add(OtherSetting OtherSetting)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO OtherSetting(ParcelCharges, HomeDeliveryCharges, CashDrawer, VAT, ServiceTax,ServiceCharges,  TA, HD, EB, KG)"
                                        + " VALUES(@ParcelCharges,@HomeDeliveryCharges,@CashDrawer,@VAT,@ServiceTax,@ServiceCharges,@TA,@HD,@EB,@KG)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, OtherSetting);
            }
        }

        public IEnumerable<OtherSetting> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<OtherSetting>("SELECT * FROM OtherSetting");
            }
        }

        public OtherSetting GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM OtherSetting"
                               + " WHERE  Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<OtherSetting>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM OtherSetting"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(OtherSetting OtherSetting)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE OtherSetting SET ParcelCharges=@ParcelCharges,HomeDeliveryCharges=@HomeDeliveryCharges,CashDrawer=@CashDrawer,VAT=@VAT,ServiceTax=@ServiceTax,TA=@TA,HD=@HD,EB=@EB,KG=@KG"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, OtherSetting);
            }
        }
    }
}
