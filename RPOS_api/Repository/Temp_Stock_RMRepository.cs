using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;
using Dapper;


namespace RPOS.Repository
{
    public class Temp_Stock_RMRepository
    {
        private string connectionString;
        public Temp_Stock_RMRepository()
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

        public object Id { get; private set; }
        public object TemR_Id { get; private set; }

        public void Add(Temp_Stock_RM TemR)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Temp_Stock_RM ( ProductID , Qty)"
                                + " VALUES( @ProductID, @Qty)";
                dbConnection.Open();
                dbConnection.Query(sQuery, TemR);
            }
        }

        public IEnumerable<Temp_Stock_RM> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock_RM>("SELECT * FROM Temp_Stock_RM");
            }
        }

        public Temp_Stock_RM GetByID(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Temp_Stock_RM"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock_RM>(sQuery, new { Id =Id }).FirstOrDefault();
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Temp_Stock_RM"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = Id });


            }
        }

        public void Update(Temp_Stock_RM TemR)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Temp_Stock_RM SET ProductID = @ProductID,Qty = @Qty"
                              + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, TemR);
            }
        }

    }
}
