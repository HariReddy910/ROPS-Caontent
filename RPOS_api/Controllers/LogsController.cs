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
    [Route("api/Logs")]
    public class LogsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly LogsRepository LogsRepository;
        public LogsController()
        {
            LogsRepository = new LogsRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Logs> Get()
        {
            return LogsRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Logs Get(int id)
        {
            return LogsRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Logs cust)
        {
            if (ModelState.IsValid)
                LogsRepository.Add(cust);
        }

        // PUT api/values/5
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody]Logs cust)
        {
            cust.Id = Id;
            if (ModelState.IsValid)
                LogsRepository.Update(cust);
        }

        // DELETE api/values/5
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            LogsRepository.Delete(Id);
        }
    }
}