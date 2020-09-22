using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ResturantPOS.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ResturantPOS.Controllers
{
    public class PosPrinterSettingController : Controller
    {

        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> PosPrinterSetting()
        {
            List<PosPrinterSetting> CatInfo = new List<PosPrinterSetting>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/PosPrinterSetting");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CatInfo = JsonConvert.DeserializeObject<List<PosPrinterSetting>>(CatResponse);
                }


                List<SelectListItem> Items = new List<SelectListItem>();
                
                    Items.Add(new SelectListItem
                    {
                        Text = "Ticket Priter",
                        Value = "Ticket Priter"
                    });
                Items.Add(new SelectListItem
                {
                    Text = "Invoice Printer",
                    Value = "Invoice Printer"
                });


                ViewBag.PrinterType = Items;

                List<SelectListItem> Item = new List<SelectListItem>();
                foreach (string sPrinters in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    Item.Add(new SelectListItem
                    {
                        Text = sPrinters,
                        Value = sPrinters.ToString()
                    });
                }

                ViewBag.PrinterName = Item;
            }
            Session["UserModel"] = CatInfo;
            return View(CatInfo);
        }
        public ActionResult SavePosPrinterSetting(PosPrinterSetting CAT_save)
        {

            using (
                var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/PosPrinterSetting", CAT_save).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("PosPrinterSetting");
            }
        }
        public ActionResult DeleteContact(PosPrinterSetting cat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/PosPrinterSetting/" + cat.Id).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("PosPrinterSetting");
        }
        public ActionResult PosPrinterSettingUpdate(PosPrinterSetting CAT_save)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PutAsJsonAsync("api/PosPrinterSetting/" + CAT_save.Id, CAT_save).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("PosPrinterSetting");
        }
    }
}

    
