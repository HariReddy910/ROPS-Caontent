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
    [Route("api/RestaurantPOS_OrderedProductBillKOT")]
    public class RestaurantPOS_OrderedProductBillKOTController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly RestaurantPOS_OrderedProductBillKOTRepository RestaurantPOS_OrderedProductBillKOTRepository;

        public RestaurantPOS_OrderedProductBillKOTController()
        {
            RestaurantPOS_OrderedProductBillKOTRepository = new RestaurantPOS_OrderedProductBillKOTRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_OrderedProductBillKOT> Get()
        {
            return RestaurantPOS_OrderedProductBillKOTRepository.GetAll();
        }
        [HttpGet("{OP_ID}")]
        public RestaurantPOS_OrderedProductBillKOT Get(int OP_ID)
        {
            return RestaurantPOS_OrderedProductBillKOTRepository.GetByID(OP_ID);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_OrderedProductBillKOT RestaurantPOS_OrderedProductBillKOT)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillKOTRepository.Add(RestaurantPOS_OrderedProductBillKOT);
        }
        [HttpPut("{OP_ID}")]
        public void Put(int OP_ID, [FromBody]RestaurantPOS_OrderedProductBillKOT RestaurantPOS_OrderedProductBillKOT)
        {
            RestaurantPOS_OrderedProductBillKOT.OP_ID = OP_ID;

            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillKOTRepository.Update(RestaurantPOS_OrderedProductBillKOT);
        }
        [HttpDelete("{OP_ID}")]
        public void Delete(int OP_ID)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillKOTRepository.Delete(OP_ID);
        }
    }
}