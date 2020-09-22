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
    [Route("api/RestaurantPOS_OrderedProductBillHD")]
    public class RestaurantPOS_OrderedProductBillHDController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RestaurantPOS_OrderedProductBillHDRepository RestaurantPOS_OrderedProductBillHDRepository;

        public RestaurantPOS_OrderedProductBillHDController()
        {
            RestaurantPOS_OrderedProductBillHDRepository = new RestaurantPOS_OrderedProductBillHDRepository();
        }
        [HttpGet]
        public IEnumerable<RestaurantPOS_OrderedProductBillHD> Get()
        {
            return RestaurantPOS_OrderedProductBillHDRepository.GetAll();
        }
        [HttpGet("{OP_ID}")]
        public RestaurantPOS_OrderedProductBillHD Get(int OP_ID)
        {
            return RestaurantPOS_OrderedProductBillHDRepository.GetByID(OP_ID);
        }
        [HttpPost]
        public void Post([FromBody]RestaurantPOS_OrderedProductBillHD RestaurantPOS_OrderedProductBillHD)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillHDRepository.Add(RestaurantPOS_OrderedProductBillHD);
        }
        [HttpPut("{OP_ID}")]
        public void Put(int OP_ID, [FromBody]RestaurantPOS_OrderedProductBillHD RestaurantPOS_OrderedProductBillHD)
        {
            RestaurantPOS_OrderedProductBillHD.OP_ID = OP_ID;

            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillHDRepository.Update(RestaurantPOS_OrderedProductBillHD);
        }
        [HttpDelete("{OP_ID}")]
        public void Delete(int OP_ID)
        {
            if (ModelState.IsValid)
                RestaurantPOS_OrderedProductBillHDRepository.Delete(OP_ID);
        }
    }
}