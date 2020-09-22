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
    [Route("api/RestaurantPOS_OrderedProductBillEB")]
    public class RestaurantPOS_OrderedProductBillEBController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_OrderedProductBillEBRepository RestaurantPOS_OrderedProductBillEBRepository;

        public RestaurantPOS_OrderedProductBillEBController()
        {
            RestaurantPOS_OrderedProductBillEBRepository = new RestaurantPOS_OrderedProductBillEBRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_OrderedProductBillEB> Get()
        {
            return RestaurantPOS_OrderedProductBillEBRepository.GetAll();
        }
        [HttpGet("{OP_ID}")]
        public RestaurantPOS_OrderedProductBillEB Get(int OP_ID)
        {
            return RestaurantPOS_OrderedProductBillEBRepository.GetByID(OP_ID);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_OrderedProductBillEB RestaurantPOS_BillingInfoTA)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillEBRepository.Add(RestaurantPOS_BillingInfoTA);
        }
        [HttpPut("{OP_ID}")]
        public void Put(int OP_ID, [FromBody]RestaurantPOS_OrderedProductBillEB RestaurantPOS_BillingInfoTA)
        {
            RestaurantPOS_BillingInfoTA.OP_ID = OP_ID;

            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillEBRepository.Update(RestaurantPOS_BillingInfoTA);
        }
        [HttpDelete("{OP_ID}")]
        public void Delete(int OP_ID)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillEBRepository.Delete(OP_ID);
        }
    }
}