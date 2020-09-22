using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using RPOS.Model;
using RPOS.Repository;
using RPOS.ModelWarehouse;

namespace RPOS.Controllers
{
    [Produces("application/json")]
    [Route("api/RestaurantPOS_BillingInfoKOT")]
    public class RestaurantPOS_BillingInfoKOTController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_BillingInfoKOTRepository RestaurantPOS_BillingInfoKOTRepository;

        public RestaurantPOS_BillingInfoKOTController()
        {
            RestaurantPOS_BillingInfoKOTRepository = new RestaurantPOS_BillingInfoKOTRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_BillingInfoKOT> Get()
        {
            return RestaurantPOS_BillingInfoKOTRepository.GetAll();
        }
        //[Route("Get")]
        [HttpGet("GetKOT")]
        public IEnumerable<RestaurantPOS_BillingInfoKOT> Get(DateTime tdate, DateTime fdate)
        {
            return RestaurantPOS_BillingInfoKOTRepository.GetAll(fdate ,tdate);
        }
        [HttpGet("{Id}")]
        public RestaurantPOS_BillingInfoKOT Get(int id)
        {
            return RestaurantPOS_BillingInfoKOTRepository.GetByID(id);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_BillingInfoKOT RestaurantPOS_BillingInfoKOT)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoKOTRepository.Add(RestaurantPOS_BillingInfoKOT);
        }
        [HttpPut("{Id}")]
        public void Put(int id, [FromBody]RestaurantPOS_BillingInfoKOT RestaurantPOS_BillingInfoKOT)
        {
            RestaurantPOS_BillingInfoKOT.Id = id;

            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoKOTRepository.Update(RestaurantPOS_BillingInfoKOT);
        }
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoKOTRepository.Delete(id);
        }
    }
}