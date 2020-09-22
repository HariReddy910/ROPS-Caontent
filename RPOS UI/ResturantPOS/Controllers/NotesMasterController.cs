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
    public class NotesMasterController : Controller
    {
        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> NotesMaster()
        {
            List<NotesMaster> CatInfo = new List<NotesMaster>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/NotesMaster");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CatInfo = JsonConvert.DeserializeObject<List<NotesMaster>>(CatResponse);
                }
            }
            Session["UserModel"] = CatInfo;
            return View(CatInfo);
        }
        public ActionResult SaveNotesMaster(NotesMaster cat)
        {

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/NotesMaster", cat).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("NotesMaster");
            }
        }
        public ActionResult DeleteContact(NotesMaster cat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/NotesMaster/" + cat.ID ).Result;
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
            return RedirectToAction("NotesMaster");
        }
        public ActionResult NotesUpdate(NotesMaster cat)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PutAsJsonAsync("api/NotesMaster/" + cat.ID, cat).Result;
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
            return RedirectToAction("NotesMaster");
        }
    }
}
    
