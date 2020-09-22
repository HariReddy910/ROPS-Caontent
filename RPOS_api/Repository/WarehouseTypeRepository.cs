
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;
using RPOS.ModelWarehouse;

namespace RPOS.Repository
{
    public class WarehouseTypeRepository
    {

        private string connectionString;
        public WarehouseTypeRepository()
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

        public void Add(WarehouseType Type)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO  WarehouseType (Type"
                                + " VALUES(@Type)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Type);
            }
        }

        public IEnumerable<WarehouseType> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<WarehouseType>("SELECT * FROM WarehouseType");
            }
        }

        

        
        public WarehouseType GetByID(String Type)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM  WarehouseType"
                               + " WHERE Type = @Type";
                dbConnection.Open();
                return dbConnection.Query<WarehouseType>(sQuery, new { Type = Type }).FirstOrDefault();
            }
        }

        

        public void Delete(string Type)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM WarehouseType"
                             + " WHERE Type = @Type";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Type = Type });
            }
        }

        public void Update( string type,  WarehouseType Type )
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE WarehouseType SET Type = @Type " 

                               + " WHERE Type = '"+type+"'";
                dbConnection.Open();
                dbConnection.Execute(sQuery, Type);
            }
        }
    }
}

    

