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
    public class SupplierRepository
    {
        private string connectionString;
        public SupplierRepository()
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

        public void Add(Supplier supa)
        {
            int id = 0;
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Select max(id) from Supplier ";
                dbConnection.Open();
                id = dbConnection.ExecuteScalar<int>(sQuery);
                if (id > 0)
                    id = id + 1;
                else
                    id = id + 1;
             
            }
            supa.ID = id;
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO Supplier (ID , SupplierID , Name, Address,City, State, ZipCode, ContactNo, EmailID,Remarks, TIN, STNo, CST,PAN, AccountName, AccountNumber, Bank,Branch, IFSCCode, OpeningBalance, OpeningBalanceType)"
                                + " VALUES(@ID, @SupplierID, @Name, @Address,@City,@State,@ZipCode,@ContactNo, @EmailID,@Remarks,@TIN,@STNo,@CST,@PAN,@AccountName,@AccountNumber, @Bank,@Branch,@IFSCCode,@OpeningBalance,@OpeningBalanceType)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, supa);
            }
        }

        //internal void Update(Supplier supa)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Supplier> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Supplier>("SELECT * FROM Supplier");
            }
        }

        public Supplier GetByID(string SupplierId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Supplier"
                               + " WHERE SupplierID = @SupplierId";
                dbConnection.Open();
               return dbConnection.Query<Supplier>(sQuery, new { SupplierId = SupplierId }).FirstOrDefault();
            }
        }

        public void Delete(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Supplier"
                             + " WHERE ID = ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { supaID = ID });
            }
        }

        public void Update(Supplier supa)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Supplier SET SupplierID = @SupplierID,"
                               + " Name = @Name, Address = @Address,"
                               + "City=@City,State=@State,"
                               + "ZipCode=@ZipCode,"
                               + " ContactNo = @ContactNo, EmailID = @EmailID,"
                               + "Remarks=@Remarks,TIN=@TIN,"
                               + "STNo=@STNo,"
                               + " CST = @CST, PAN = @PAN,"
                               + "AccountName=@AccountName,AccountNumber=@AccountNumber,"
                               + "Bank=@Bank,"
                               + " Branch = @Branch, IFSCCode = @IFSCCode,"
                               + "OpeningBalance=@OpeningBalance"
                               + " WHERE ID = @ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, supa);
            }
        }
        
        public int GetId()
        {
            int id = 0;
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "Select max(id) from Supplier ";
                dbConnection.Open();
               id= dbConnection.ExecuteScalar<int>(sQuery) ;
                if (id > 0)
                    id = id + 1;
                else
                    id = id + 1;
                return id;
            }
        }

    }
}


