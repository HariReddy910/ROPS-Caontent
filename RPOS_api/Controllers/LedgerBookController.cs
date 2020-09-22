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
    [Route("api/LedgerBook")]
    public class LedgerBookController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly LedgerBookRepository LedgerBookRepository;
        public LedgerBookController()
        {
            LedgerBookRepository = new LedgerBookRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<LedgerBook> Get()
        {
            return LedgerBookRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public LedgerBook Get(int id)
        {
            return LedgerBookRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]LedgerBook ledgerBook)
        {
            if (ModelState.IsValid)
                LedgerBookRepository.Add(ledgerBook);
        }

        // PUT api/values/5
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody]LedgerBook LedgerBook)
        {
            LedgerBook.Id = Id;
            if (ModelState.IsValid)
                LedgerBookRepository.Update(LedgerBook);
        }

        // DELETE api/values/5
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            LedgerBookRepository.Delete(Id);
        }

    }
}