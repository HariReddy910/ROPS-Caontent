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
    [Route("api/RestaurantPOS_BillingInfoEB")]

    public class RestaurantPOS_BillingInfoEBController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_BillingInfoEBRepository RestaurantPOS_BillingInfoEBRepository;

        public RestaurantPOS_BillingInfoEBController()
        {
            RestaurantPOS_BillingInfoEBRepository = new RestaurantPOS_BillingInfoEBRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_BillingInfoEB> Get()
        {
            return RestaurantPOS_BillingInfoEBRepository.GetAll();
        }
        [HttpGet("{Id}")]
        public RestaurantPOS_BillingInfoEB Get(int id)
        {
            return RestaurantPOS_BillingInfoEBRepository.GetByID(id);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_BillingInfoEB RestaurantPOS_BillingInfoEB)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoEBRepository.Add(RestaurantPOS_BillingInfoEB);
        }
        //[Route("Get")]
        [HttpGet("GetEB")]
        public IEnumerable<RestaurantPOS_BillingInfoEB> Get(   DateTime tdate ,  DateTime fdate)
        {
          return     RestaurantPOS_BillingInfoEBRepository.GetAll(tdate, fdate);
        }
        [HttpPut("{Id}")]
        public void Put(int id, [FromBody]RestaurantPOS_BillingInfoEB RestaurantPOS_BillingInfoEB)
        {
            RestaurantPOS_BillingInfoEB.Id = id;

            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoEBRepository.Update(RestaurantPOS_BillingInfoEB);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoEBRepository.Delete(Id);
        }
    }
}