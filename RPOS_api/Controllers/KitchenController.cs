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
    [Route("api/Kitchen")]
    public class KitchenController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly KitchenRepository KitchenRepository;
        public KitchenController()
        {
            KitchenRepository = new KitchenRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Kitchen> Get()
        {
            return KitchenRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Kitchen Get(String kitchenName)
        {
            return KitchenRepository.GetByID(kitchenName);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Kitchen kitchen)
        {
            if (ModelState.IsValid)
                KitchenRepository.Add(kitchen);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String oldKitchenName, [FromBody]Kitchen Kitchen)
        {
             
            if (ModelState.IsValid)
                KitchenRepository.Update(oldKitchenName,Kitchen);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string kitchenName)
        {
            KitchenRepository.Delete(kitchenName);
        }


    }
}