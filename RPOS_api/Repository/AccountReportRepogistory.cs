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
    public class AccountReportRepogistory
    {
        private string connectionString;
        public AccountReportRepogistory()
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

        

        public IEnumerable<Supplier> PurchaseDaybook(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Supplier>("select p.Date, p.InvoiceNo,s.Name,p.SubTotal,p.Discount,p.FreightCharges,p.OtherCharges, p.PreviousDue,p.GrandTotal from Purchase p inner join Supplier s on s.ID = p.ST_ID where date between '"+fdate + "' and '"+tdate+"'");
            }
        }

        public IEnumerable<LedgerBook> GrenaralLadge(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<LedgerBook>(" SELECT    * FROM LedgerBook  where date between '" + fdate + "' and '" + tdate + "'");
            }
        }

        public IEnumerable<LedgerBook> TrialBalance(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<LedgerBook>("Select Name,CASE WHEN (Sum(Debit)-Sum(Credit))<= 0 THEN 0 ELSE (Sum(Debit)-Sum(Credit)) END AS Debit,CASE WHEN (Sum(Credit)-Sum(Debit))<= 0 THEN 0 ELSE (Sum(Credit)-Sum(debit)) END AS Credit from LedgerBook where Date >='"+fdate+"' and Date < '"+tdate+"' Group By Name order by Name");
            }
        }

        public IEnumerable<Supplier> PerchaseInventoryReport(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Supplier>(" SELECT P.InvoiceNo,P.Date,P.PurchaseType,S.Name  FROM Purchase P INNER JOIN Supplier S ON P.Supplier_ID= S.ID where date between '" + fdate + "' and '" + tdate + "'");
            }
        }

       
        public IEnumerable<Purchase_Join> PurchasedInventoryReport1()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Purchase_Join>("SELECT P.ProductName,P.Price,PJ.Qty,P.Unit,PJ.HasExpirydate,PJ.ExpiryDate ,PU.InvoiceNo FROM Product P INNER JOIN Purchase_Join PJ ON P.PID=PJ.ProductID  INNER JOIN  PURCHASE PU ON PU.ST_ID=PJ.PURCHASEID ");
            }
        }

        public IEnumerable<Purchase> PurchasedInventoryReport2( )
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Purchase>("SELECT InvoiceNo ,SubTotal,DiscountPer, Discount ,PreviousDue ,FreightCharges, OtherCharges, Total ,RoundOff,GrandTotal,TotalPayment,PaymentDue  FROM  Purchase  ");
            }
        }

        public IEnumerable<StockTransfer> StockTransferReport(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StockTransfer>("SELECT * FROM  StockTransfer  where date between '" + fdate + "' and '" + tdate + "'");
            }
        }

        public IEnumerable<StockTransfer_Join> StockTransferReport1()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StockTransfer_Join>(" SELECT P.ProductName,SJ.Warehouse,SJ.Qty ,P.Unit,SJ.ExpiryDate,st.ST_ID FROM StockTransfer_Join SJ INNER JOIN Product P ON SJ.ProductID= P.PID inner join StockTransfer st on st.ST_ID =sj.StockTransferID");
            }
        }


        public IEnumerable<Voucher_OtherDetailsn> ExpendituresReport(DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Voucher_OtherDetailsn>("SELECT VoucherNo,Name,Date,Details,VT.Particulars ,GrandTotal,VT.Note FROM Voucher V INNER JOIN Voucher_OtherDetails  VT ON V.ID=VT.VoucherID where date between '" + fdate + "' and '" + tdate + "'");
            }
        }

        public IEnumerable<Supplier> SupplierLedger ()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Supplier>("SELECT * FROM Supplier ");
            }
        }

        public IEnumerable<SupplierLedgerBook> SupplierLedger1(string Name, DateTime fdate, DateTime tdate)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<SupplierLedgerBook>("SELECT * FROM SupplierLedgerBook where Name='"+Name+"' and date between '" + fdate + "' and '" + tdate + "'");
            }
        }

        public IEnumerable<LedgerBook> GeneralDaybook( DateTime date)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<LedgerBook>("SELECT * FROM LedgerBook where date = '" + date + "'");
            }
        }

        public IEnumerable<ListOfCreditors> ListOfCreditors()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<ListOfCreditors>("Select s.SupplierID,s.Name ,s.City ,s.ContactNo ,CASE WHEN SUM(sb.Credit-sb.Debit) >0 then sum(sb.Credit-sb.Debit) end As Credit  from SupplierLedgerBook sb inner join Supplier s on  s.SupplierID =sb.PartyID group by s.SupplierID,s.City ,s.ContactNo ,s.Name");
            }
        }

        public IEnumerable<Temp_Stock> StockinRecord()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock>("select t.Warehouse,p.ProductCode, p.ProductName ,t.HasExpiryDate,t.ExpiryDate,t.Qty  from Temp_Stock t  inner join Product p on p.PID= t.ProductID");
            }
        }

        public IEnumerable<Temp_Stock> stockoutRecord()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock>("select t.Warehouse,p.ProductCode, p.ProductName   from Temp_Stock t  inner join Product p on p.PID= t.ProductID where t.Qty=0.00");
            }
        }

        public IEnumerable<Temp_Stock> StockExpaire()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock>("Select ts.Warehouse ,p.ProductCode, p.ProductName ,ts.ExpiryDate ,ts.Qty   from  Product p  inner join Temp_Stock ts on p.PID=ts.ProductID where ts.HasExpiryDate='Yes' ");
            }
        }

        public IEnumerable<Temp_Stock> LowStock()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Temp_Stock>("  select distinct t.Warehouse,p.ProductCode, p.ProductName ,t.Qty ,p.ReorderPoint  from Temp_Stock t  inner join Product p on p.PID= t.ProductID  where P.ReorderPoint>t.Qty and t.Qty!=0.00");
            }
        }

        public IEnumerable<StockInMenuItem> StockInMenuItem()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StockInMenuItem>("Select t.Dish,c.CategoryName,t.Qty   from Temp_Stock_Store t inner  join Dish d on t.Dish = d.DishName inner join Category c on c.Cat_ID=d.Category where Qty!=0.00");
            }
        }

        public IEnumerable<StockInMenuItem> StockOutMenuItem()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StockInMenuItem>("Select t.Dish,c.CategoryName from Temp_Stock_Store t inner  join Dish d on t.Dish = d.DishName inner join Category c on c.Cat_ID=d.Category where Qty=0.00");
            }
        }

        public IEnumerable<RawMaterialOfKitchen> StockInOfKitchenItem()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RawMaterialOfKitchen>("Select p.ProductCode,p.ProductName,t.Qty from Temp_Stock_RM t inner join Product p on t.ProductID=p.PID where t.Qty !=0.00");
            }
        }

        public IEnumerable<RawMaterialOfKitchen> StockOutOfKitchenItem()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<RawMaterialOfKitchen>("Select p.ProductCode,p.ProductName,t.Qty from Temp_Stock_RM t inner join Product p on t.ProductID=p.PID where t.Qty =0.00");
            }
        }
    }
}
