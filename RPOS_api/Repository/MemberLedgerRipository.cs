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
    public class MemberLedgerRipository
    {
        private string connectionString;
        public MemberLedgerRipository()
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

        public void Add(MemberLedger memberLedger)
        {
            var Date = System.Convert.ToDateTime(memberLedger.Date);
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = " INSERT INTO MemberLedger (Date, LedgerNo, Label, Debit,Credit,MemberID)"
                                + " VALUES(@Date, @LedgerNo, @Label, @Debit,@Credit,@MemberID)";
                dbConnection.Open();
                dbConnection.Query(sQuery, memberLedger);
            }
        }

        public IEnumerable<GetBanlace> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<GetBanlace>(" SELECT  RTRIM(Member.MemberID) AS Id,RTRIM(Member.Name) As Name,IsNull(sum(Credit)-sum(Debit),0) As Balance FROM Member left join MemberLedger on Member.MemberID=MemberLedger.MemberID group by name,Member.MemberID order by Name");
            }
        }

        public MemberLedger GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM MemberLedger"
                               + " WHERE  Id = @Id";
                dbConnection.Open();
                return dbConnection.Query<MemberLedger>(sQuery, new {  Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM MemberLedger"
                             + " WHERE MemberID = @MemberID";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { MemberID = id });
            }
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Member"
                             + " WHERE MemberId = @MemberID";
                dbConnection.Open();
                dbConnection.Query(sQuery, new { MemberID = id });
            }
        }

        public void Update(MemberLedger cust)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE MemberLedger SET Date = @Date,"
                               + " LedgerNo = @LedgerNo, Label = @Label,"
                                + "  Debit = @Debit, Credit = @Credit,MemberID=@MemberID"
                               + " WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, cust);
            }

        }

        public IEnumerable<MemberLedger> GetBalanceOfMember()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT RTRIM(Member.MemberID) As MemberID,Member.ContactNo  ,RTRIM(Name) As Name,IsNull(sum(Credit)-sum(Debit),0)As Credit FROM Member left join MemberLedger on Member.MemberID=MemberLedger.MemberID group by name, Member.ContactNo,Member.MemberID order by Name";
                dbConnection.Open();
              return  dbConnection.Query<MemberLedger>(sQuery);
            }

        }

        public IEnumerable<MemberLedger>  CardDetail(List<Member>  List)
        {
            MemberLedger MemberL = null;
            List<MemberLedger> MemberCardList = new List<MemberLedger>(); 
            foreach (var Id in List)
            {
                MemberL = new MemberLedger();
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = "  SELECT RTRIM(Member.MemberID) As MemberID,Member.ContactNo  ,RTRIM(Name) As Name,IsNull(sum(Credit)-sum(Debit),0)As Credit FROM Member left join MemberLedger on Member.MemberID=MemberLedger.MemberID   where Member.MemberID="+Id+"  group by name, Member.ContactNo,Member.MemberID order by Name";
                    dbConnection.Open();
                   SqlDataReader dr  = (SqlDataReader)dbConnection.ExecuteReader(sQuery);
                    MemberCardList.Add(MemberL);
                }
            }
            return MemberCardList;
        }
    }
}
