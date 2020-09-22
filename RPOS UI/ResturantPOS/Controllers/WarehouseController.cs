using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResturantPOS.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ResturantPOS.Controllers
{
    public class WarehouseController : Controller
    {
        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> Warehouse()
        {
            List<Warehouse> KitInfo = new List<Warehouse>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Warehouse");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var kitResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    KitInfo = JsonConvert.DeserializeObject<List<Warehouse>>(kitResponse);
                }
            }
                List<WarehouseType> WarehouseType = new List<WarehouseType>();
            using (var client2 = new HttpClient())
            {
                //Passing service base url  
                client2.BaseAddress = new Uri(Baseurl);
                client2.DefaultRequestHeaders.Clear();
                //Define request data format  
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res2 = await client2.GetAsync("api/WarehouseType");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res2.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var kitResponse = Res2.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    WarehouseType = JsonConvert.DeserializeObject<List<WarehouseType>>(kitResponse);
                }
            }
                    List<SelectListItem> Items = new List<SelectListItem>();
                    foreach (var c in WarehouseType)
                    {
                        Items.Add(new SelectListItem
                        {
                            Text = c.Type,
                            Value = c.Type
                        });
                    }

                   ViewBag.Warehouse = Items;


                
                Session["UserModel"] = KitInfo;
                return View(KitInfo);
            
        }
            public ActionResult SaveWarehouse(Warehouse CatIns1)
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = client.PostAsJsonAsync("api/Warehouse", CatIns1).Result;
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var CatResponse = Res.Content.ReadAsStringAsync().Result;
                        ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                        //Deserializing the response recieved from web api and storing into the Employee list  
                        //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                    }
                    return RedirectToAction("Warehouse");
                }
            }
            public ActionResult DeleteWarehouse(Warehouse CAT)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = client.DeleteAsync("api/Warehouse/" + CAT.WarehouseName).Result;
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
                return RedirectToAction("Warehouse");
            }
            public ActionResult WarehouseUpdate(string WarehouseName, Warehouse CAT)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = client.PutAsJsonAsync("api/Warehouse/" + CAT.WarehouseName, CAT).Result;
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var KitResponse = Res.Content.ReadAsStringAsync().Result;
                        ViewBag.Name = JsonConvert.SerializeObject(KitResponse);
                        //Deserializing the response recieved from web api and storing into the Employee list  
                        //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                    }
                }
                return RedirectToAction("Warehouse");
            }
        }
    }
