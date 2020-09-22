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
    public class OnlineOrderTypeController : Controller
    {
        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> OnlineOrderType()




        {
            List<OnlineOrderType> IdInfo = new List<OnlineOrderType>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/OnlineOrderType");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var IdResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(IdResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    IdInfo = JsonConvert.DeserializeObject<List<OnlineOrderType>>(IdResponse);
                }
            }
            Session["UserModel"] = IdInfo;
            return View(IdInfo);
        }
        public ActionResult SaveOnlineOrderType(OnlineOrderType IdIns)
        {

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/OnlineOrderType", IdIns).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var IdResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(IdResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("OnlineOrderType");
            }
        }
        public ActionResult DeleteContact(OnlineOrderType OOT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/OnlineOrderType/" + OOT.Id).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var IdResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(IdResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("OnlineOrderType");
        }
        public ActionResult OrderComanyNameUpdate(OnlineOrderType OOT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PutAsJsonAsync("api/OnlineOrderType/" + OOT.Id, OOT).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var IdResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(IdResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("OnlineOrderType");
        }
    }
}