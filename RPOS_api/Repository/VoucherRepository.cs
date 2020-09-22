using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RPOS.Model;
using Dapper;
using RPOS.Repository;

namespace RPOS.Repository
{
    public class VoucherRepository
    {
        private string connectionString;
        public VoucherRepository()
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

        public void Add(List<Voucher_OtherDetailsn> voc)
        {

            using (IDbConnection dbConnection = Connection)
            {
                foreach (var list in voc)
                {
                    if (list.VD_ID == 0)
                    {
                        string sQuery = "INSERT INTO Voucher_OtherDetails ( VoucherID , Particulars, Amount,Note)"
                                        + " VALUES( @VoucherID, @Particulars, @Amount,@Note)";
                        dbConnection.Open();
                        dbConnection.Execute(sQuery, voc);
                        dbConnection.Close();
                    }
                    else
                    {
                        string sQuery = " UPDATE Voucher_OtherDetails SET VoucherID = @VoucherID,"
                             + " Particulars = @Particulars, Amount = @Amount,"
                             + "Note=@Note"
                             + " WHERE VD_ID = @VD_ID";
                        dbConnection.Open();
                        dbConnection.Execute(sQuery, voc);
                        dbConnection.Close();
                    }
                }
            }
        }

        public IEnumerable<Voucher_OtherDetailsn> GetAll(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Voucher_OtherDetailsn>("SELECT * FROM Voucher_OtherDetails where VoucherID=@ID",new { ID=ID });
            }
        }

        public Voucher_OtherDetailsn GetByID(int VD_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM Voucher_OtherDetails"
                               + " WHERE VD_ID = @VD_ID";
                dbConnection.Open();
                return dbConnection.Query<Voucher_OtherDetailsn>(sQuery, new { VD_ID = VD_ID }).FirstOrDefault();
            }
        }

        public void Delete(int VD_ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Voucher_OtherDetails"
                             + " WHERE VD_ID = @VD_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { VD_ID = VD_ID });
            }
        }

        public void Update(Voucher_OtherDetailsn voc)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " UPDATE Voucher_OtherDetails SET VoucherID = @VoucherID,"
                               + " Particulars = @Particulars, Amount = @Amount,"
                               + "Note=@Note"
                               + " WHERE VD_ID = @VD_ID";
                dbConnection.Open();
                dbConnection.Execute(sQuery, voc);
            }
        }
    }
}
