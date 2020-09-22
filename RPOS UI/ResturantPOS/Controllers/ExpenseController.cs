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
    public class ExpenseController : Controller
    {
        // GET: Expense

        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> ExpenseList()


        {
            List<Expense> Expense1 = new List<Expense>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync("api/Expense");


                if (Res.IsSuccessStatusCode)
                {

                    var Curr = Res.Content.ReadAsStringAsync().Result;


                    Expense1 = JsonConvert.DeserializeObject<List<Expense>>(Curr);

                }
            }
            List<ExpenseTypecs> ExpenseTypecs = new List<ExpenseTypecs>();

            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(Baseurl);

                client1.DefaultRequestHeaders.Clear();

                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res1 = await client1.GetAsync("api/ExpensType");


                if (Res1.IsSuccessStatusCode)
                {

                    var Curr = Res1.Content.ReadAsStringAsync().Result;


                    ExpenseTypecs = JsonConvert.DeserializeObject<List<ExpenseTypecs>>(Curr);

                }

                List<SelectListItem> Items = new List<SelectListItem>();
                foreach (var c in ExpenseTypecs)
                {
                    Items.Add(new SelectListItem
                    {
                        Text = c.Type,
                        Value = c.Type
                    });
                }

                ViewBag.Type = Items;
                Session["UserModel"] = Expense1;
                return PartialView(Expense1);
            }
        }





        public ActionResult SaveExpense(string ExpenseName1, string ExpenseName2, string ExpenseType)
        {

            Expense Exp = new Expense();
            string ExpenseName = ExpenseName1;
            Exp.ExpenseName = ExpenseName2;
            Exp.ExpenseType = ExpenseType;

            using (var client2 = new HttpClient())
            {
                //Passing service base url  
                client2.BaseAddress = new Uri(Baseurl);
                client2.DefaultRequestHeaders.Clear();
                //Define request data format  
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client2.PutAsJsonAsync("api/Expense/" + ExpenseName, Exp).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("ExpenseList");
            }
        }
        public ActionResult DeleteExpense(Expense Exp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/Expense/" + Exp.ExpenseName).Result;
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
            return RedirectToAction("ExpenseList");
        }



        public ActionResult SaveCategory(Expense Exp)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/Expense", Exp).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("ExpenseList");
            }
        }
    }
}

    