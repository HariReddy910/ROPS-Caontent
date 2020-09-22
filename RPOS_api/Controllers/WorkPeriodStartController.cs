//work period start controller.

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
    [Route("api/WorkPeriodStart")]
    public class WorkPeriodStartEndController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly WorkPeriodStartRepository WorkPeriodRepository;

        public int Id { get; private set; }

        public WorkPeriodStartEndController()
        {
            WorkPeriodRepository = new WorkPeriodStartRepository();
        }
        [HttpGet]
        public IEnumerable<WorkPeriodStart> Get()
        {
            return WorkPeriodRepository.GetAll();
        }
        [HttpGet("{id}")]
        public WorkPeriodStart Get(int id)
        {
            return WorkPeriodRepository.GetByID(id);

        }
        [HttpPost]
        public void Post([FromBody]WorkPeriodStart Work)
        {
            if (ModelState.IsValid)
                WorkPeriodRepository.Start(Work); 
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WorkPeriodStart Work)
        {

            Id = id;
            if (ModelState.IsValid)
                WorkPeriodRepository.Update(Work);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid)
                WorkPeriodRepository.Delete(id);
        }
    }
    }
