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
    [Route("api/NotesMaster")]
    public class NotesMasterController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly NotesMasterRepository NotesMasterRepository;
        public NotesMasterController()
        {
            NotesMasterRepository = new NotesMasterRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<NotesMaster> Get()
        {
            return NotesMasterRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public NotesMaster Get(int id)
        {
            return NotesMasterRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]NotesMaster NotesMaster)
        {
            if (ModelState.IsValid)
                NotesMasterRepository.Add(NotesMaster);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]NotesMaster notesMaster)
        {
            notesMaster.ID = id;
            if (ModelState.IsValid)
                NotesMasterRepository.Update(notesMaster);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            NotesMasterRepository.Delete(id);
        }
    }
}