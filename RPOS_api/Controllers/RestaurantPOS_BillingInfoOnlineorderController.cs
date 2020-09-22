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
    [Route("api/RestaurantPOS_BillingInfoOnlineorder")]
    public class RestaurantPOS_BillingInfoOnlineorderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_BillingInfoOnlineorderRepository RestaurantPOS_BillingInfoOnlineorderRepository;

        public RestaurantPOS_BillingInfoOnlineorderController()
        {
            RestaurantPOS_BillingInfoOnlineorderRepository = new RestaurantPOS_BillingInfoOnlineorderRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_BillingInfoOnlineorder> Get()
        {
            return RestaurantPOS_BillingInfoOnlineorderRepository.GetAll();
        }
       // [Route("Get")]
        [HttpGet("GetOnlineOrder")]
        public IEnumerable<RestaurantPOS_BillingInfoOnlineorder> Get( DateTime fdate, DateTime tdate )
        {
            return RestaurantPOS_BillingInfoOnlineorderRepository.GetAll(fdate, tdate);
        }
        [HttpGet("{Id}")]
        public RestaurantPOS_BillingInfoOnlineorder Get(int id)
        {
            return RestaurantPOS_BillingInfoOnlineorderRepository.GetByID(id);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_BillingInfoOnlineorder RestaurantPOS_BillingInfoOnlineorder)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoOnlineorderRepository.Add(RestaurantPOS_BillingInfoOnlineorder);
        }
        [HttpPut("{Id}")]
        public void Put(int id, [FromBody]RestaurantPOS_BillingInfoOnlineorder RestaurantPOS_BillingInfoOnlineor)
        {
            RestaurantPOS_BillingInfoOnlineor.Id = id;

            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoOnlineorderRepository.Update(RestaurantPOS_BillingInfoOnlineor);
        }
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoOnlineorderRepository.Delete(id);
        }
    }
}