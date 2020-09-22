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
    [Route("api/Payment")]
    public class PaymentController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly PaymentRepositorycs PaymentRepositorycs;
        public PaymentController()
        {
            PaymentRepositorycs = new PaymentRepositorycs();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            return PaymentRepositorycs.GetAll();
        }
        [HttpGet("GetId")]
        public int GetId()
        {
            return PaymentRepositorycs.GetId();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Payment Get(int id)
        {
            return PaymentRepositorycs.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Payment NotesMaster)
        {
            if (ModelState.IsValid)
                PaymentRepositorycs.Add(NotesMaster);
        }

        // PUT api/values/5
        [HttpPut("{T_ID}")]
        public void Put(int T_ID, [FromBody]Payment notesMaster)
        {
            
            if (ModelState.IsValid)
                PaymentRepositorycs.Update(notesMaster);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PaymentRepositorycs.Delete(id);
        }
    }
}