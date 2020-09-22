using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Model;
using RPOS.Repository;
namespace RPOS.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountReport")]
    public class AccountReportController : ControllerBase
    {
        private readonly AccountReportRepogistory PurchaseDayBookRepogistory;
        public AccountReportController()
        {
            PurchaseDayBookRepogistory = new AccountReportRepogistory();
        }
        [HttpGet("PurchaseDaybook1")]
       //[HttpGet]
        public IEnumerable<Supplier> PurchaseDaybook( DateTime fdate ,DateTime tdate)
        {
            return PurchaseDayBookRepogistory.PurchaseDaybook(fdate,tdate);
        }

        [HttpGet("GrenaralLadge")]
        public IEnumerable<LedgerBook> GrenaralLadge(DateTime fdate, DateTime tdate)
        {
            return PurchaseDayBookRepogistory.GrenaralLadge(fdate, tdate);
        }
        [HttpGet("TrialBalance")]
        public IEnumerable<LedgerBook> TrialBalance(DateTime fdate, DateTime tdate)
        {
            return PurchaseDayBookRepogistory.TrialBalance(fdate, tdate);
        }
        [HttpGet("PerchaseInventoryReport")]
        public IEnumerable<Supplier> PerchaseInventoryReport(DateTime fdate, DateTime tdate)
        {
            return PurchaseDayBookRepogistory.PerchaseInventoryReport(fdate, tdate);
        }
        [HttpGet("PerchaseInventoryReport1")]
        public IEnumerable<Purchase_Join> PerchaseInventoryReport1()
        {
            return PurchaseDayBookRepogistory.PurchasedInventoryReport1();
        }
        [HttpGet("PerchaseInventoryReport2")]
        public IEnumerable<Purchase> PerchaseInventoryReport2()
        {
            return PurchaseDayBookRepogistory.PurchasedInventoryReport2();
        }
        [HttpGet("StockTransferReport")]
        public IEnumerable<StockTransfer> StockTransferReport(DateTime fdate, DateTime tdate)
        {
            return PurchaseDayBookRepogistory.StockTransferReport(fdate, tdate);
        }

       
        [HttpGet("StockTransferReport1")]
        public IEnumerable<StockTransfer_Join> StockTransferReport1()
        {
            return PurchaseDayBookRepogistory.StockTransferReport1();
        }
        [HttpGet("Voucher")]
        public IEnumerable<Voucher_OtherDetailsn> Voucher(DateTime fdate, DateTime tdate)
        {
            return PurchaseDayBookRepogistory.ExpendituresReport(fdate, tdate);
        }
        [HttpGet("SupplierLedger")]
        public IEnumerable<Supplier> SupplierLedger()
        {
            return PurchaseDayBookRepogistory.SupplierLedger();
        }
        [HttpGet("SupplierLedger1")]
        public IEnumerable<SupplierLedgerBook> SupplierLedger1(string Name, DateTime fdate, DateTime tdate)
        {
            return PurchaseDayBookRepogistory.SupplierLedger1(Name,fdate, tdate);
        }
        
        [HttpGet("GeneralDaybook")]
        public IEnumerable<LedgerBook> GeneralDaybook( DateTime date)
        {
            return PurchaseDayBookRepogistory.GeneralDaybook(date);
        }
        [HttpGet("ListOfCreditors")]
        public IEnumerable<ListOfCreditors> ListOfCreditors()
        {
            return PurchaseDayBookRepogistory.ListOfCreditors();
        }
        [HttpGet("StockinRecord")]
        public IEnumerable<Temp_Stock> StockinRecord()
        {
            return PurchaseDayBookRepogistory.StockinRecord();

        }
        [HttpGet("stockoutRecord")]
        public IEnumerable<Temp_Stock> stockoutRecord()
        {
            return PurchaseDayBookRepogistory.stockoutRecord();
        }
        [HttpGet("StockExpaire")]
        public IEnumerable<Temp_Stock> StockExpaire()
        {
            return PurchaseDayBookRepogistory.StockExpaire();
        }
        [HttpGet("LowStock")]
        public IEnumerable<Temp_Stock> LowStock()
        {
            return PurchaseDayBookRepogistory.LowStock();
        }

        [HttpGet("StockInMenuItem")]
        public IEnumerable<StockInMenuItem> StockInMenuItem()
        {
            return PurchaseDayBookRepogistory.StockInMenuItem();
        }
        [HttpGet("StockOutMenuItem")]
        public IEnumerable<StockInMenuItem> StockOutMenuItem()
        {
            return PurchaseDayBookRepogistory.StockOutMenuItem();
        }
        [HttpGet("StockInOfKitchenItem")]
        public IEnumerable<RawMaterialOfKitchen> StockInOfKitchenItem()
        {
            return PurchaseDayBookRepogistory.StockInOfKitchenItem();
        }
        [HttpGet("StockOutOfKitchenItem")]
        public IEnumerable<RawMaterialOfKitchen> StockOutOfKitchenItem()
        {
            return PurchaseDayBookRepogistory.StockOutOfKitchenItem();
        }
    }
}