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
    [Route("api/RestaurantPOS_OrderedProductBillOnLineOrder")]
    public class RestaurantPOS_OrderedProductBillOnLineOrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_OrderedProductBillOnLineOrderRepository RestaurantPOS_OrderedProductBillOnLineOrderRepository;

        public RestaurantPOS_OrderedProductBillOnLineOrderController()
        {
            RestaurantPOS_OrderedProductBillOnLineOrderRepository = new RestaurantPOS_OrderedProductBillOnLineOrderRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_OrderedProductBillOnLineOrder> Get()
        {
            return RestaurantPOS_OrderedProductBillOnLineOrderRepository.GetAll();
        }
        [HttpGet("{OP_ID}")]
        public RestaurantPOS_OrderedProductBillOnLineOrder Get(int OP_ID)
        {
            return RestaurantPOS_OrderedProductBillOnLineOrderRepository.GetByID(OP_ID);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_OrderedProductBillOnLineOrder RestaurantPOS_OrderedProductBillOnLineOrder)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillOnLineOrderRepository.Add(RestaurantPOS_OrderedProductBillOnLineOrder);
        }
        [HttpPut("{OP_ID}")]
        public void Put(int OP_ID, [FromBody]RestaurantPOS_OrderedProductBillOnLineOrder RestaurantPOS_OrderedProductBillOnLineOrder)
        {
            RestaurantPOS_OrderedProductBillOnLineOrder.OP_ID = OP_ID;

            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillOnLineOrderRepository.Update(RestaurantPOS_OrderedProductBillOnLineOrder);
        }
        [HttpDelete("{OP_ID}")]
        public void Delete(int OP_ID)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillOnLineOrderRepository.Delete(OP_ID);
        }
    }
}