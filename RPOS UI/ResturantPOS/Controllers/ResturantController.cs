using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using ResturantPOS.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ResturantPOS.Controllers
{
    public class ResturantController : Controller
    {
        string Baseurl = "http://localhost:2159/";
        // GET: Resturant
        public ActionResult BackOffice()
        { 
            return View();
        }

        public ActionResult ResturantInfo()
        {
            return View();
        }
        public ActionResult CurrencyRate()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult SectionInfo()
        {
            return View();
        }

        public ActionResult MenuItems()
        {
            return View();
        }

        public async Task<ActionResult> MenuItemsStock()
    {
            List<Stock_Store> Dish = new List<Stock_Store>();
            List<Stock_Store_myjoin> mydata = new List<Stock_Store_myjoin>();
            Stock_Store model1 = new Stock_Store();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync("api/Stock_Store");


                if (Res.IsSuccessStatusCode)
                {

                    var Curr = Res.Content.ReadAsStringAsync().Result;
                    Dish = JsonConvert.DeserializeObject<List<Stock_Store>>(Curr);
       

                }
   
                model1.St_ID = Dish.Select(s => s.St_ID).LastOrDefault();
                model1.Date= Dish.Select(s => s.Date).LastOrDefault();
                model1.Remarks= Dish.Select(s => s.Remarks).LastOrDefault();
            }
           // List<Category> Category = new List<Category>();

            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(Baseurl);

                client1.DefaultRequestHeaders.Clear();

                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res1 = await client1.GetAsync("api/Stock_Store_Join");


                if (Res1.IsSuccessStatusCode)
                {

                    var Curr = Res1.Content.ReadAsStringAsync().Result;


                    mydata = JsonConvert.DeserializeObject<List<Stock_Store_myjoin>>(Curr);

                }
                //model.Sid = Category.Select(s => s.Cat_Id).LastOrDefault();
                List<SelectListItem> Items = new List<SelectListItem>();
                foreach (var c in mydata)
                {
                    Items.Add(new SelectListItem
                    {
                         Value = c.Dish,
                         Text = c.Dish
                    });
                }
               ViewBag.mydata= Items;


            }

            List<Kitchen> Kitchen = new List<Kitchen>();

            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(Baseurl);

                client2.DefaultRequestHeaders.Clear();

                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res2 = await client2.GetAsync("api/Kitchen");


                if (Res2.IsSuccessStatusCode)
                {

                    var Curr1 = Res2.Content.ReadAsStringAsync().Result;


                    Kitchen = JsonConvert.DeserializeObject<List<Kitchen>>(Curr1);

                }

                List<SelectListItem> Items2 = new List<SelectListItem>();
                //foreach (var c in Kitchen)
                //{
                //    model1.Getdashdata.Add(new Stock_Store
                //    {
                //         StockId = c.,
                //        Dish = c.Kitchenname
                //    });
                //}

                ViewBag.Kichen = Items2;
                Session["UserModel"] = Dish;
                return View(model1);



            }


        }

        [HttpPost]
       public ActionResult MenuItemsStock(string Sname, int Iqty)
        {


            Stock_Store_myjoin model = new Stock_Store_myjoin();
            
                model.Dish = Sname;
            model.Qty = Iqty;
            model.StockID =4;
            using (
                var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/Stock_Store_Join", model).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                    return RedirectToAction("MenuItemsStock");
                }

                return View();
            }
        }
        public ActionResult Table()
        {
            return View();
        }
        public ActionResult Settings()
        {

            return View();
        }
        public ActionResult POSPrinterSetting()
        {

            return View();
        }
        public ActionResult EmailSetting()
        {

            return View();
        }
        public ActionResult SMSSettings()
        {

            return View();
        }
        public ActionResult OtherSettings()
        {

            return View();
        }
        public ActionResult Database()
        {
            return View();
        }
        public ActionResult Note()
        {
            return View();
        }

        public ActionResult Hotel()
        {
            return View();
        }
        public ActionResult Wallet()
        {
            return View();
        }
        public ActionResult RPOSCard()
        {
            return View();
        }
        public ActionResult AddMember()
        {
            return View();
        }
        public ActionResult AddFunds()
        {
            return View();
        }
        public ActionResult Refund()
        {
            return View();
        }
        public ActionResult PrintCards()
        {
            return View();
        }
        public ActionResult MemberLedger()
        {
            return View();
        }
        public ActionResult WareHouseType()
        {
            return View();
        }
        public ActionResult WareHouse()
        {
            return View();
        }
        public ActionResult Supplier()
        {
            return View();
        }
        public ActionResult ExpenseType()
        {
            return View();
        }
        public ActionResult Expense()
        {
            return View();
        }
        public ActionResult Voucher()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult AccountingReports()
        {
            return View();
        }
        public ActionResult WorkPeriod()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Logs()
        {
            return View();
        }
        public ActionResult POSReport()
        {
            return View();
        }
        public ActionResult ChangePIN()
        {
            return View();
        }
        public ActionResult Recipe()
        {
            return View();
        }
        public ActionResult Delivery()
        {
            return View();
        }
        public ActionResult DeliveryPerson()
        {
            return View();
        }
        public ActionResult OtherResource()
        {
            return View();
        }
        public ActionResult StockIssues()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult RawMaterials()
        {
            return View();
        }
        public ActionResult Listofsuppliers()
        {
            return View();
        }


        public ActionResult PurchaseEntry()
        {
            return View();
        }





    }
    }
