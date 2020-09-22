
//work period start and end in front office
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
    [Route("api/WorkPeriodEnd")]
    public class WorkController : Microsoft.AspNetCore.Mvc.Controller
    {

        //private readonly WorkPeriodEndRepository WorkPeriodEndRepository;

        //public int Id { get; private set; }

        //public WorkController()
        //{
        //    WorkPeriodEndRepository = new WorkPeriodEndRepository();
        //}
        //[HttpGet]
        //public IEnumerable<WorkPeriodEnd> Get()
        //{
        //    return WorkPeriodEndRepository.GetAll();
        //}
        //[HttpGet("{id}")]
        //public WorkPeriodEnd Get(int id)
        //{
        //    return WorkPeriodEndRepository.GetByID(id);

        //}
        //[HttpPost]
        //public void Post([FromBody]WorkPeriodEnd Work)
        //{
        //    if (ModelState.IsValid)
        //        WorkPeriodEndRepository.End(Work);
        //}
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] WorkPeriodEnd Work)
        //{

        //    Id = id;
        //    if (ModelState.IsValid)
        //        WorkPeriodEndRepository.Update(Work);
        //}
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //    if (ModelState.IsValid)
        //        WorkPeriodEndRepository.Delete(id);
        //}
    }
}
