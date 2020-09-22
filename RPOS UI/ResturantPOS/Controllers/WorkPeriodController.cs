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
    public class WorkPeriodController : Controller
    {
        //    string Baseurl = "http://localhost:2159/";
        //    public async Task<ActionResult> WorkPeriod()
        //    {
        //        List<WorkPeriodStart> WorkInfo = new List<WorkPeriodStart>();
        //        using (var client = new HttpClient())
        //        {
        //            //Passing service base url  
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();
        //            //Define request data format  
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
        //            HttpResponseMessage Res = await client.GetAsync("api/WorkPeriodStart");
        //            //Checking the response is successful or not which is sent using HttpClient  
        //            if (Res.IsSuccessStatusCode)
        //            {
        //                //Storing the response details recieved from web api   
        //                var WorkStart = Res.Content.ReadAsStringAsync().Result;
        //                ViewBag.Name = JsonConvert.SerializeObject(WorkStart);
        //                //Deserializing the response recieved from web api and storing into the Employee list  
        //                WorkInfo = JsonConvert.DeserializeObject<List<WorkPeriodStart>>(WorkStart);
        //            }
        //        }
        //        Session["UserModel"] = WorkInfo;
        //        return View(WorkInfo);
        //    }
        //    public ActionResult SaveCategory(WorkPeriodStart WorkStart)
        //    {

        //        using (var client = new HttpClient())
        //        {
        //            //Passing service base url  
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();
        //            //Define request data format  
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
        //            HttpResponseMessage Res = client.PostAsJsonAsync("api/WorkPeriodStart", WorkStart).Result;
        //            //Checking the response is successful or not which is sent using HttpClient  
        //            if (Res.IsSuccessStatusCode)
        //            {
        //                //Storing the response details recieved from web api   
        //                var CatResponse = Res.Content.ReadAsStringAsync().Result;
        //                ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
        //                //Deserializing the response recieved from web api and storing into the Employee list  
        //                //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
        //            }
        //            return RedirectToAction("WorkPeriod");
        //        }
        //    }
        //    public ActionResult DeleteContact(WorkPeriodStart WorkStart)
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();
        //            //Define request data format  
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
        //            HttpResponseMessage Res = client.DeleteAsync("api/WorkPeriodStart/" + WorkStart.Id).Result;
        //            //Checking the response is successful or not which is sent using HttpClient  
        //            if (Res.IsSuccessStatusCode)
        //            {
        //                //Storing the response details recieved from web api   
        //                var CatResponse = Res.Content.ReadAsStringAsync().Result;
        //                ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
        //                //Deserializing the response recieved from web api and storing into the Employee list  
        //                //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
        //            }
        //        }
        //        return RedirectToAction("WorkPeriod");
        //    }
        //    //public ActionResult CategoryUpdate(WorkPeriodStart WorkStart)
        //    //{
        //    //    using (var client = new HttpClient())
        //    //    {
        //    //        client.BaseAddress = new Uri(Baseurl);
        //    //        client.DefaultRequestHeaders.Clear();
        //    //        //Define request data format  
        //    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    //        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
        //    //        HttpResponseMessage Res = client.PutAsJsonAsync("api/WorkPeriodStart/" + WorkStart.ID, WorkStart).Result;
        //    //        //Checking the response is successful or not which is sent using HttpClient  
        //    //        if (Res.IsSuccessStatusCode)
        //    //        {
        //    //            //Storing the response details recieved from web api   
        //    //            var CatResponse = Res.Content.ReadAsStringAsync().Result;
        //    //            ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
        //    //            //Deserializing the response recieved from web api and storing into the Employee list  
        //    //            //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
        //    //        }
        //    //    }
        //    //    return RedirectToAction("WorkPeriod");
        //    //}
        //}
    }
}