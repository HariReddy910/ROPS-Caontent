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
    [Route("api/RestaurantPOS_BillingInfoHD")]
    public class RestaurantPOS_BillingInfoHDController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_BillingInfoHDRepository RestaurantPOS_BillingInfoHDRepository;

        public RestaurantPOS_BillingInfoHDController()
        {
            RestaurantPOS_BillingInfoHDRepository = new RestaurantPOS_BillingInfoHDRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_BillingInfoHD> Get()
        {
            return RestaurantPOS_BillingInfoHDRepository.GetAll();
        }
        
        [HttpGet("GetHD")]
        public IEnumerable<RestaurantPOS_BillingInfoHD> Get( DateTime tdate,  DateTime fdate)
        {
            return RestaurantPOS_BillingInfoHDRepository.GetAll(tdate,fdate );
        }
        [HttpGet("{Id}")]
        public RestaurantPOS_BillingInfoHD Get(int Id)
        {
            return RestaurantPOS_BillingInfoHDRepository.GetByID(Id);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_BillingInfoHD RestaurantPOS_BillingInfoHD)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoHDRepository.Add(RestaurantPOS_BillingInfoHD);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody]RestaurantPOS_BillingInfoHD RestaurantPOS_BillingInfoHD)
        {
            RestaurantPOS_BillingInfoHD.Id = Id;

            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoHDRepository.Update(RestaurantPOS_BillingInfoHD);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            if (ModelState.IsValid)
                RestaurantPOS_BillingInfoHDRepository.Delete(Id);
        }
    }
}