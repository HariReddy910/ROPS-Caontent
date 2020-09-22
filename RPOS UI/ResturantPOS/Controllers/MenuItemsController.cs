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
    public class MenuItemsController : Controller
    {
       // int id = 0;
        string Baseurl = "http://localhost:2159/";
        // GET: MenuItems
        public async Task<ActionResult> MenuItems()
        {
           
            List<Dish> Dish = new List<Dish>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync("api/Dish");


                if (Res.IsSuccessStatusCode)
                {

                    var Curr = Res.Content.ReadAsStringAsync().Result;


                    Dish = JsonConvert.DeserializeObject<List<Dish>>(Curr);

                }
            }
            List<Category> Category = new List<Category>();

            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(Baseurl);

                client1.DefaultRequestHeaders.Clear();

                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res1 = await client1.GetAsync("api/Category");


                if (Res1.IsSuccessStatusCode)
                {

                    var Curr = Res1.Content.ReadAsStringAsync().Result;


                    Category = JsonConvert.DeserializeObject<List<Category>>(Curr);

                }

                List<SelectListItem> Items = new List<SelectListItem>();
                foreach (var c in Category)
                {
                    Items.Add(new SelectListItem
                    {
                        Text = c.CategoryName,
                        Value = c.CategoryName
                    });
                }
                ViewBag.Type = Items;


            }

                List<Kitchen> Kitchen = new List<Kitchen>();

                using (var client2 = new HttpClient())
                {
                    client2.BaseAddress = new Uri(Baseurl);

                    client2.DefaultRequestHeaders.Clear();

                    client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res2 = await client2.GetAsync("api/Kitchen");


                    if (Res2.IsSuccessStatusCode)
                    {

                        var Curr1 = Res2.Content.ReadAsStringAsync().Result;


                        Kitchen = JsonConvert.DeserializeObject<List<Kitchen>>(Curr1);

                    }

                    List<SelectListItem> Items2 = new List<SelectListItem>();
                    foreach (var c in Kitchen)
                    {
                        Items2.Add(new SelectListItem
                        {
                            Text = c.Kitchenname,
                            Value = c.Kitchenname
                        });
                    }

                    ViewBag.Kichen = Items2;
                    Session["UserModel"] = Dish;
                    return View(Dish);



                }
            }


         
        public ActionResult DishUpdate(String DishName1, String DishName2,string Category,string Kitchen,double Rate,double Discount)
        {
            string DishName = DishName2;
            Dish dish = new Dish();
            dish.DishName = DishName1;
            dish.Category = Category;
            dish.Kitchen = Kitchen;
            dish.Rate = (decimal) Rate;
            dish.Discount = (decimal)Discount;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PutAsJsonAsync("api/Dish/" + DishName, dish).Result;
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
            return RedirectToAction("MenuItems");
        }

        public ActionResult DeleteDish(Dish dish)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.DeleteAsync("api/Dish/" + dish.DishName).Result;
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
            return RedirectToAction("MenuItems");
        }
        public ActionResult SaveDish(Dish dish)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync("api/Dish", dish).Result;
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CatResponse = Res.Content.ReadAsStringAsync().Result;
                    ViewBag.Name = JsonConvert.SerializeObject(CatResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    //CatInfo = JsonConvert.DeserializeObject<List<Category>>(CatResponse);
                }
                return RedirectToAction("MenuItems");
            }
        }
    }
}
