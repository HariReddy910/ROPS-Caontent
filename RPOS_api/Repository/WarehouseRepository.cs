using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using RPOS.ModelWarehouse;
using RPOS.Models;

namespace RPOS.Repository

{
    public class WarehouseRepository
    {
        private string connectionString;
        public WarehouseRepository()
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

        public void Add(Warehouse house)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Warehouse (WarehouseName ,WarehouseType, City)"
                                + " VALUES(@WarehouseName, @WarehouseType, @City)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, house);
            }
        }

         

         

        public IEnumerable<Warehouse> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Warehouse>("SELECT * FROM Warehouse");
            }
        }

        internal void Update(string warehouseName, Warehouse ware)
        {
            throw new NotImplementedException();
        }

        public Warehouse GetByName(String WarehouseName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Warehouse"
                               + " WHERE WarehouseName = @WarehouseName";
                dbConnection.Open();
                return dbConnection.Query<Warehouse>(sQuery, new { WarehouseName = WarehouseName }).FirstOrDefault();
            }
        }

        public void Delete(String WarehouseName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Warehouse"
                             + " WHERE WarehouseName = @WarehouseName";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { WarehouseName = WarehouseName });
            }
        }

        public void Update(Warehouse house)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Warehouse SET WarehouseName = @WarehouseName,"
                               + " WarehouseType = @WarehouseType, City = @City"
                               
                               + " WHERE WarehouseName = @WarehouseName";
                dbConnection.Open();
                dbConnection.Execute(sQuery, house);
            }
        }
    }

         
                }
            

        
    
