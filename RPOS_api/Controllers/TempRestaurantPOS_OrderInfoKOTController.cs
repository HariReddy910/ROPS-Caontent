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
    [Route("api/TempRestaurantPOS_OrderInfoKOT")]
    public class TempRestaurantPOS_OrderInfoKOTController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly TempRestaurantPOS_OrderInfoKOTRepository TempRestaurantPOS_OrderInfoKOTRepository;

        public TempRestaurantPOS_OrderInfoKOTController()
        {
            TempRestaurantPOS_OrderInfoKOTRepository = new TempRestaurantPOS_OrderInfoKOTRepository();
        }
        [HttpGet]
        public IEnumerable<TempRestaurantPOS_OrderInfoKOT> Get()
        {
            return TempRestaurantPOS_OrderInfoKOTRepository.GetAll();
        }
        [HttpGet("{OP_ID}")]
        public TempRestaurantPOS_OrderInfoKOT Get(int OP_ID)
        {
            return TempRestaurantPOS_OrderInfoKOTRepository.GetByID(OP_ID);

        }
        [HttpPost]
        public void Post([FromBody]TempRestaurantPOS_OrderInfoKOT temp)
        {
            if (ModelState.IsValid)
                TempRestaurantPOS_OrderInfoKOTRepository.Add(temp);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] TempRestaurantPOS_OrderInfoKOT temp)
        {
            temp.Id = Id;
            if (ModelState.IsValid)
                TempRestaurantPOS_OrderInfoKOTRepository.Update(temp);
        }
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid)
                TempRestaurantPOS_OrderInfoKOTRepository.Delete(id);
        }

    }
}