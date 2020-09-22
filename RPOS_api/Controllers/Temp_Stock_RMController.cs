using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RPOS.Repository;
using RPOS.Model;

namespace RPOS.Controllers
{
    [Produces("application/json")]
    [Route("api/Temp_Stock_RM")]
    public class Temp_Stock_RMController : Microsoft.AspNetCore.Mvc.Controller
    {
         private readonly Temp_Stock_RMRepository Temp_Stock_RMRepository;

        public Temp_Stock_RMController()
        {
            Temp_Stock_RMRepository = new Temp_Stock_RMRepository();
        }
        [HttpGet]
         public IEnumerable<Temp_Stock_RM> Get()
        {
            return Temp_Stock_RMRepository.GetAll();
        }
        [HttpGet("{Id}")]
        public Temp_Stock_RM Get(int id)
        {
            return Temp_Stock_RMRepository.GetByID(id);

        }
        [HttpPost]
        public void Post([FromBody]Temp_Stock_RM TemR)
        {
            if (ModelState.IsValid)
                Temp_Stock_RMRepository.Add(TemR);
        }
        [HttpPut("{Id}")]
        public void Put(int id ,[FromBody] Temp_Stock_RM TemR)
        {
            TemR.Id = id;
            if (ModelState.IsValid)
                Temp_Stock_RMRepository.Update(TemR);
        }
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid)
                Temp_Stock_RMRepository.Delete(id);
        }
    }
}