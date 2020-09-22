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
    [Route("api/RestaurantPOS_BillingInfoTA")]
    public class RestaurantPOS_BillingInfoTAController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_BillingInfoTARepository RestaurantPOS_BillingInfoTARepository;

        public RestaurantPOS_BillingInfoTAController()
        {
            RestaurantPOS_BillingInfoTARepository = new RestaurantPOS_BillingInfoTARepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_BillingInfoTA> Get()
        {
            return RestaurantPOS_BillingInfoTARepository.GetAll();
        }
        //[Route("Get")]
        [HttpGet("GetAT")]
        public IEnumerable<RestaurantPOS_BillingInfoTA> Get(  DateTime tdate , DateTime fdate)
        {
            return RestaurantPOS_BillingInfoTARepository.GetAll(tdate, fdate);
        }
        [HttpGet("{Id}")]
        public RestaurantPOS_BillingInfoTA Get(int id)
        {
            return RestaurantPOS_BillingInfoTARepository.GetByID(id);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_BillingInfoTA RestaurantPOS_BillingInfoTA)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoTARepository.Add(RestaurantPOS_BillingInfoTA);
        }
        [HttpPut("{Id}")]
        public void Put(int id, [FromBody]RestaurantPOS_BillingInfoTA RestaurantPOS_BillingInfoTA)
        {
            RestaurantPOS_BillingInfoTA.Id = id;

            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoTARepository.Update(RestaurantPOS_BillingInfoTA);
        }
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoTARepository.Delete(id);
        }
    }
}