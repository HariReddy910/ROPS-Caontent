using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Repository;
using RPOS.Model;
namespace RPOS.Controllers
{
    [Produces("application/json")]
    [Route("api/Purchase")]
    public class PurchaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly PurchaseRepository PurchaseRepository;
        public PurchaseController()
        {
            PurchaseRepository = new PurchaseRepository();
        }
        // GET: api/values GetID
        [HttpGet]
        public IEnumerable<Purchase> Get()
        {
            return PurchaseRepository.GetAll();
        }
        [HttpGet("GetID")]
        public int GetID()
        {
            return PurchaseRepository.GetID();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Purchase Get(int id)
        {
            return PurchaseRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Purchase Purchase)
        {
            if (ModelState.IsValid)
                PurchaseRepository.Add(Purchase);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Purchase Purchase)
        {
            Purchase.ST_ID = id;
            if (ModelState.IsValid)
                PurchaseRepository.Update(Purchase);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PurchaseRepository.Delete(id);
        }
    }
}