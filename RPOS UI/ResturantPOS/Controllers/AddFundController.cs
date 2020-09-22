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
    public class AddFundController : Controller
    {
        string Baseurl = "http://localhost:2159/";
        // GET: AddFound
        public async Task<ActionResult> FoundMember()
        {
            
         List<GetBalance> GetBalance = new List<GetBalance>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync("api/MemberLedger");


                if (Res.IsSuccessStatusCode)
                {

                    var Curr = Res.Content.ReadAsStringAsync().Result;


                    GetBalance = JsonConvert.DeserializeObject<List<GetBalance>>(Curr);

                }
            }

            Session["UserModel"] = GetBalance;
            return View(GetBalance);

        }
         

        public ActionResult DeleteMember(MemberLedger MemberLedger)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/MemberLedger/" + MemberLedger.MemberID).Result;
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
            return RedirectToAction("GetAFund");
        }
        public ActionResult SaveMember(MemberLedger MemberLedger)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/MemberLedger", MemberLedger).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("GetAFund");
            }
        }

        public async Task<ActionResult> RefundFund()
        {

            List<GetBalance> GetBalance = new List<GetBalance>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync("api/MemberLedger");


                if (Res.IsSuccessStatusCode)
                {

                    var Curr = Res.Content.ReadAsStringAsync().Result;


                    GetBalance = JsonConvert.DeserializeObject<List<GetBalance>>(Curr);

                }
            }

            Session["UserModel"] = GetBalance;
            return View(GetBalance);

        }


        public ActionResult DeleteMember1(MemberLedger MemberLedger)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/MemberLedger/" + MemberLedger.MemberID).Result;
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
            return RedirectToAction("RefundFund");
        }
        public ActionResult SaveMember1(MemberLedger MemberLedger)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/MemberLedger", MemberLedger).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("RefundFund");
            }
        }
    }
}