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
    public class SupplierController : Controller
    {

        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> Supplier()
        {
            List<Supplier> SupInfo = new List<Supplier>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Supplier");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var SupResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(SupResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    SupInfo = JsonConvert.DeserializeObject<List<Supplier>>(SupResponse);
                }
            }

            int id = 0;
            using (var client1 = new HttpClient())
            {
                //Passing service base url  
                client1.BaseAddress = new Uri(Baseurl);
                client1.DefaultRequestHeaders.Clear();
                //Define request data format  
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res1 = await client1.GetAsync("api/Supplier/get");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res1.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var SupResponse = Res1.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(SupResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                  id  = JsonConvert.DeserializeObject<int>(SupResponse);
                }
                if(id<9)
                ViewBag.SupplierId = "S-0" + id.ToString();
                else
                  ViewBag.SupplierId = "S-" + id.ToString();
            }

                List<SelectListItem> Items = new List<SelectListItem>();
                foreach (var c in SupInfo)
                {
                    Items.Add(new SelectListItem
                    {
                        Text = c.State,
                        Value = c.State.ToString()
                    });
                

                ViewBag.State = Items;

                List<SelectListItem> Item = new List<SelectListItem>();
                foreach (var c1 in SupInfo)
                {
                    Item.Add(new SelectListItem
                    {
                        Text = c1.OpeningBalanceType,
                        Value = c1.OpeningBalanceType.ToString()
                    });
                }

                ViewBag.OpeningBalanceType = Item;

            }


        
            Session["UserModel"] = SupInfo;
            return View(SupInfo);
        }
        public ActionResult SaveSupplier(Supplier cat)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/Supplier", cat).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("Supplier");
            }
        }
        public ActionResult DeleteSupplier(Supplier Sup)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/Supplier/" + Sup.SupplierID).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var SupResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(SupResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("Supplier");
        }
        public ActionResult SupplierUpdate(Supplier Sup)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PutAsJsonAsync("api/Supplier/" + Sup.ID, Sup).Result;
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
            return RedirectToAction("Supplier");
        }
    }
}
    

    