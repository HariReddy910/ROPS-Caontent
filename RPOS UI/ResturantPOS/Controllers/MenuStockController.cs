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
    public class MenuStockController : Controller
    {
        // GET: MenuStock
        int id = 0;
        string Baseurl = "http://localhost:2159/";
        public async Task<ActionResult> MenuStock()
        {
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri(Baseurl);

                client2.DefaultRequestHeaders.Clear();

                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res2 = await client2.GetAsync("api/Stock_Store/GetId");


                if (Res2.IsSuccessStatusCode)
                {

                    var Curr = Res2.Content.ReadAsStringAsync().Result;


                    id = JsonConvert.DeserializeObject<int>(Curr);

                }
            }

            ViewBag.Id = id;


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
                List<SelectListItem> item = new List<SelectListItem>();
                foreach (var d in Dish)
                {
                    item.Add(new SelectListItem() { Text = d.DishName, Value = d.DishName });
                }
                ViewBag.Item = item;
                //List<Stock_Store_myjoin> stock_Store_Join = new List<Stock_Store_myjoin>();
                //using (var client1 = new HttpClient())
                //{
                //    client1.BaseAddress = new Uri(Baseurl);

                //    client1.DefaultRequestHeaders.Clear();

                //    client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //    HttpResponseMessage Res1 = await client1.GetAsync("api/Stock_Store_Join");


                //    if (Res1.IsSuccessStatusCode)
                //    {

                //        var Curr = Res1.Content.ReadAsStringAsync().Result;


                //        stock_Store_Join = JsonConvert.DeserializeObject<List<Stock_Store_myjoin>>(Curr);

                //    }


                //}
                return View();
            }


        public ActionResult AddStock(Stock_Store Stock_Store , List<Stock_Store_myjoin> list)
        {
            return RedirectToAction("MenuStock");
        }
        }
    }
