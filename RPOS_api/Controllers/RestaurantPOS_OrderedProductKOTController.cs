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
    [Route("api/RestaurantPOS_OrderedProductKOT")]
    public class RestaurantPOS_OrderedProductKOTController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_OrderedProductKOTRepository RestaurantPOS_OrderedProductKOTRepository;

        public RestaurantPOS_OrderedProductKOTController()
        {
            RestaurantPOS_OrderedProductKOTRepository = new RestaurantPOS_OrderedProductKOTRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_OrderedProductKOT> Get()
        {
            return RestaurantPOS_OrderedProductKOTRepository.GetAll();
        }
        [HttpGet("{OP_ID}")]
        public RestaurantPOS_OrderedProductKOT Get(int OP_ID)
        {
            return RestaurantPOS_OrderedProductKOTRepository.GetByID(OP_ID);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_OrderedProductKOT RestaurantPOS_OrderedProductKOT)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductKOTRepository.Add(RestaurantPOS_OrderedProductKOT);
        }
        [HttpPut("{OP_ID}")]
        public void Put(int OP_ID, [FromBody]RestaurantPOS_OrderedProductKOT RestaurantPOS_OrderedProductKOT)
        {
            RestaurantPOS_OrderedProductKOT.OP_ID = OP_ID;

            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductKOTRepository.Update(RestaurantPOS_OrderedProductKOT);
        }
        [HttpDelete("{OP_ID}")]
        public void Delete(int OP_ID)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductKOTRepository.Delete(OP_ID);
        }
    }
}