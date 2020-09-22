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
    public class SMSSettingController : Controller
    {
        
            string Baseurl = "http://localhost:2159/";
            public async Task<ActionResult> SMSSetting()
            {
                List<SMSSetting> SMSInfo = new List<SMSSetting>();
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/SMSSetting");
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var SMSResponse = Res.Content.ReadAsStringAsync().Result;

                        ViewBag.Name = JsonConvert.SerializeObject(SMSResponse);
                        //Deserializing the response recieved from web api and storing into the Employee list  
                        SMSInfo = JsonConvert.DeserializeObject<List<SMSSetting>>(SMSResponse);
                    }

                }
                Session["UserModel"] = SMSInfo;
                return View(SMSInfo);
            }
            public ActionResult SaveSMSSetting(SMSSetting sms)
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = client.PostAsJsonAsync("api/SMSSetting", sms).Result;
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var SMSResponse = Res.Content.ReadAsStringAsync().Result;
                        ViewBag.Name = JsonConvert.SerializeObject(SMSResponse);
                        //Deserializing the response recieved from web api and storing into the Employee list  
                        //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                    }
                    return RedirectToAction("SMSSetting");
                }
            }
            public ActionResult DeleteSMSSetting(SMSSetting sms)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = client.DeleteAsync("api/SMSSetting/" + sms.Id).Result;
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var SMSResponse = Res.Content.ReadAsStringAsync().Result;
                        ViewBag.Name = JsonConvert.SerializeObject(SMSResponse);
                        //Deserializing the response recieved from web api and storing into the Employee list  
                        //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                    }
                }
                return RedirectToAction("SMSSetting");
            }
            public ActionResult SMSSettingUpdate(SMSSetting sms)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = client.PutAsJsonAsync("api/SMSSetting/" + sms.Id, sms).Result;
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var SMSResponse = Res.Content.ReadAsStringAsync().Result;
                        ViewBag.Name = JsonConvert.SerializeObject(SMSResponse);
                        //Deserializing the response recieved from web api and storing into the Employee list  
                        //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                    }
                }
                return RedirectToAction("SMSSetting");
            }
        }
    }
