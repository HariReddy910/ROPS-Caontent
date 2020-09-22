using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Repository;
using RPOS.ModelWarehouse;
using RPOS.Model;

namespace RPOS.Controllers
{

    [Produces("application/json")]
    [Route("api/TempRestaurantPOS_OrderedProductKOT")]
    public class TempRestaurantPOS_OrderedProductKOTController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly TempRestaurantPOS_OrderedProductKOTRepository TempRestaurantPOS_OrderedProductKOTRepository;

        public TempRestaurantPOS_OrderedProductKOTController()
        {
            TempRestaurantPOS_OrderedProductKOTRepository = new TempRestaurantPOS_OrderedProductKOTRepository();
        }
        [HttpGet]
        public IEnumerable<TempRestaurantPOS_OrderedProductKOT> Get()
        {
            return TempRestaurantPOS_OrderedProductKOTRepository.GetAll();
        }
        [HttpGet("{id}")]
        public TempRestaurantPOS_OrderedProductKOT Get(int id)
        {
            return TempRestaurantPOS_OrderedProductKOTRepository.GetByID(id);

        }
        [HttpPost]
        public void Post([FromBody]TempRestaurantPOS_OrderedProductKOT temp)
        {
            if (ModelState.IsValid)
                TempRestaurantPOS_OrderedProductKOTRepository.Add(temp);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TempRestaurantPOS_OrderedProductKOT temp)
        {
            temp.OP_ID = id;
            if (ModelState.IsValid)
                TempRestaurantPOS_OrderedProductKOTRepository.Update(temp);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid)
                TempRestaurantPOS_OrderedProductKOTRepository.Delete(id);
        }

    }
}