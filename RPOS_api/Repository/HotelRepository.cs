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
    public class HotelRepository
    {
        private string connectionString;
        public HotelRepository()
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

        public void Add(Hotel hotel)
        {
           
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Hotel(HotelName, AddressLine1, AddressLine2, AddressLine3, ContactNo, EmailID, TIN, STNo, CIN, Logo, BaseCurrency, CurrencyCode, TicketFooterMessage)"
                                        + " VALUES(@HotelName , @AddressLine1, @AddressLine2, @AddressLine3,@ContactNo,@EmailID,@TIN,@STNo,@CIN,@Logo,@BaseCurrency,@CurrencyCode,@TicketFooterMessage)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, hotel);
            }
        }

        public IEnumerable<Hotel> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Hotel>("SELECT * FROM Hotel");
            }
        }

        public Hotel GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Hotel"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<Hotel>(sQuery, new {Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Hotel"
                             + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Hotel hotel)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE Hotel SET HotelName = @HotelName ,AddressLine1 = @AddressLine1,AddressLine2 = @AddressLine2,AddressLine3 = @AddressLine3,ContactNo = @ContactNo,EmailID = @EmailID,TIN = @TIN,STNo = @STNo,CIN = @CIN,Logo = @Logo,BaseCurrency = @BaseCurrency,CurrencyCode = @CurrencyCode,TicketFooterMessage = @TicketFooterMessage where id=@id";
                dbConnection.Open();
                dbConnection.Query(sQuery, hotel);
            }
        }

    }
}
