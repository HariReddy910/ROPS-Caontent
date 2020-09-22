using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResturantPOS.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ResturantPOS.Controllers
{
    public class R_TableController : Controller
    {
        String Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> R_Table()
        {
            List<R_Table> TabInfo = new List<R_Table>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/R_Table");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TabResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(TabResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    TabInfo = JsonConvert.DeserializeObject<List<R_Table>>(TabResponse);
                }
            }
            Session["UserModel"] = TabInfo;
            return View(TabInfo);
        }
        public ActionResult SaveR_Table(R_Table tab)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/R_Table", tab).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TabResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(TabResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("R_Table");
            }
        }
        public ActionResult DeleteR_Table(R_Table tab)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/R_Table/" + tab.TableNo).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TabResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(TabResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("R_Table");
        }
        public ActionResult R_TableUpdate(R_Table tab)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PutAsJsonAsync("api/R_Table/" + tab.TableNo, tab).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TabResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(TabResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("R_Table");
        }
    }
}