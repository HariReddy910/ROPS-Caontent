using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Model;
using RPOS.Repository;
namespace RPOS.Controllers
{
    [Produces("application/json")]
    [Route("api/RestaurantPOS_OrderInfoKOT")]
    public class RestaurantPOS_OrderInfoKOTController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_OrderInfoKOTRepsitory RestaurantPOS_OrderInfoKOTRepsitory;

        public RestaurantPOS_OrderInfoKOTController()
        {
            RestaurantPOS_OrderInfoKOTRepsitory = new RestaurantPOS_OrderInfoKOTRepsitory();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_OrderInfoKOT> Get()
        {
            return RestaurantPOS_OrderInfoKOTRepsitory.GetAll();
        }
        [HttpGet("{ID}")]
        public RestaurantPOS_OrderInfoKOT Get(int ID)
        {
            return RestaurantPOS_OrderInfoKOTRepsitory.GetByID(ID);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_OrderInfoKOT RestaurantPOS_OrderInfoKOT)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderInfoKOTRepsitory.Add(RestaurantPOS_OrderInfoKOT);
        }
        [HttpPut("{ID}")]
        public void Put(int ID, [FromBody]RestaurantPOS_OrderInfoKOT RestaurantPOS_OrderInfoKOT)
        {
            RestaurantPOS_OrderInfoKOT.ID = ID;

            if (ModelState.IsValid)
                RestaurantPOS_OrderInfoKOTRepsitory.Update(RestaurantPOS_OrderInfoKOT);
        }
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderInfoKOTRepsitory.Delete(ID);
        }
    }
}