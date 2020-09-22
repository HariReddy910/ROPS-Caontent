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
    public class MemberLadgerController : Controller
    {
        string Baseurl = "http://localhost:2159/";
        // GET: MemberLadger
        public async Task<ActionResult> FoundMember()
        {


            List<Member> Member = new List<Member>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync("api/Member");


                if (Res.IsSuccessStatusCode)
                {

                    var Curr = Res.Content.ReadAsStringAsync().Result;


                    Member = JsonConvert.DeserializeObject<List<Member>>(Curr);

                }
            }

            Session["UserModel"] = Member;
            return View(Member);

        }
    }
}