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
    [Route("api/RestaurantPOS_OrderedProductBillTA")]
    public class RestaurantPOS_OrderedProductBillTAController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly  RestaurantPOS_OrderedProductBillTARepository RestaurantPOS_OrderedProductBillTARepository;

        public RestaurantPOS_OrderedProductBillTAController()
        {
            RestaurantPOS_OrderedProductBillTARepository = new RestaurantPOS_OrderedProductBillTARepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_OrderedProductBillTA> Get()
        {
            return RestaurantPOS_OrderedProductBillTARepository.GetAll();
        }
        [HttpGet("{OP_ID}")]
        public RestaurantPOS_OrderedProductBillTA Get(int OP_ID)
        {
            return RestaurantPOS_OrderedProductBillTARepository.GetByID(OP_ID);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_OrderedProductBillTA RestaurantPOS_OrderedProductBillTA)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillTARepository.Add(RestaurantPOS_OrderedProductBillTA);
        }
        [HttpPut("{OP_ID}")]
        public void Put(int OP_ID, [FromBody]RestaurantPOS_OrderedProductBillTA RestaurantPOS_OrderedProductBillTA)
        {
            RestaurantPOS_OrderedProductBillTA.OP_ID = OP_ID;

            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillTARepository.Update(RestaurantPOS_OrderedProductBillTA);
        }
        [HttpDelete("{OP_ID}")]
        public void Delete(int OP_ID)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillTARepository.Delete(OP_ID);
        }
    }
}