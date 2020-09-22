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
    public class EmailSettingController : Controller
    {
        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> EmailSetting()
        {
            List<EmailSetting> EmailInfo = new List<EmailSetting>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/EmailSetting");
                //Checking the response is successful or not which is sent using HttpClient  


                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmailResponse = Res.Content.ReadAsStringAsync().Result;

                    ViewBag.Name = JsonConvert.SerializeObject(EmailResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmailInfo = JsonConvert.DeserializeObject<List<EmailSetting>>(EmailResponse);
                }
                List<SelectListItem> Items = new List<SelectListItem>();
                foreach (var c in EmailInfo)
                {
                    Items.Add(new SelectListItem
                    {
                        Text = c.ServerName,
                        Value = c.ServerName.ToString()
                    });
                }

                ViewBag.ServerName = Items;
                List<SelectListItem> Item = new List<SelectListItem>();
                foreach (var c in EmailInfo)
                {
                    Item.Add(new SelectListItem
                    {
                        Text = c.TLS_SSL_Required,
                        Value = c.TLS_SSL_Required.ToString()
                    });
                }

                ViewBag.TLS_SSL_Required = Item;

            }
            Session["UserModel"] = EmailInfo;
            return View(EmailInfo);
        }
        public ActionResult SaveEmailSetting(EmailSetting kit)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/EmailSetting", kit).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmailResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(EmailResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("EmailSetting");
            }
        }
        public ActionResult DeleteEmailSetting(EmailSetting Menu)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/EmailSetting/" + Menu.Id).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmailResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(EmailResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("EmailSetting");
        }
        public ActionResult EmailSettingUpdate(EmailSetting kit)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PutAsJsonAsync("api/EmailSetting/" + kit.Id, kit).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmailResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(EmailResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
            }
            return RedirectToAction("EmailSetting");
        }
    }
}