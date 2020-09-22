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
    [Route("api/Purchase_Join")]
    public class Purchase_JoinController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Purchase_JoinRepository Purchase_JoinRepository;
        public Purchase_JoinController()
        {
            Purchase_JoinRepository = new Purchase_JoinRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Purchase_Join> Get()
        {
            return Purchase_JoinRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Purchase_Join Get(int id)
        {
            return Purchase_JoinRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Purchase_Join Purchase_Join)
        {
            if (ModelState.IsValid)
                Purchase_JoinRepository.Add(Purchase_Join);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Purchase_Join Purchase_Join)
        {
            Purchase_Join.SP_ID = id;
            if (ModelState.IsValid)
                Purchase_JoinRepository.Update(Purchase_Join);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Purchase_JoinRepository.Delete(id);
        }
    }
}