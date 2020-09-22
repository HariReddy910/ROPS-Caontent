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
    [Route("api/OnlineOrderType")]
    public class OnlineOrderTypeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly OnlineOrderTypeRepository OnlineOrderTypeRepository;
        public OnlineOrderTypeController()
        {
            OnlineOrderTypeRepository = new OnlineOrderTypeRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<OnlineOrderType> Get()
        {
            return OnlineOrderTypeRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public OnlineOrderType Get(int id)
        {
            return OnlineOrderTypeRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]OnlineOrderType NotesMaster)
        {
            if (ModelState.IsValid)
                OnlineOrderTypeRepository.Add(NotesMaster);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]OnlineOrderType notesMaster)
        {
            notesMaster.Id = id;
            if (ModelState.IsValid)
                OnlineOrderTypeRepository.Update(notesMaster);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OnlineOrderTypeRepository.Delete(id);
        }
    }
}