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
    [Route("api/Hotel")]
    public class HotelController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly HotelRepository HotelRepository;
        public HotelController()
        {
            HotelRepository = new HotelRepository();
        }
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return HotelRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return HotelRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Hotel cust)
        {
            if (ModelState.IsValid)
                HotelRepository.Add(cust);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Hotel cust)
        {
            cust.Id = id;
            if (ModelState.IsValid)
                HotelRepository.Update(cust);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            HotelRepository.Delete(id);
        }

    }
}