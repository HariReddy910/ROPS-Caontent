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
    [Route("api/R_Table")]
    public class R_TableController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly R_TableTrpository R_TableTrpository;
        public R_TableController()
        {
            R_TableTrpository = new R_TableTrpository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<R_Table> Get()
        {
            return R_TableTrpository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{TableNo}")]
        public R_Table Get(string TableNo)
        {
            return R_TableTrpository.GetByID(TableNo);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]R_Table R_Table)
        {
            if (ModelState.IsValid)
                R_TableTrpository.Add(R_Table);
        }

        // PUT api/values/5
        [HttpPut("{TableNo}")]
        public void Put(string TableNo, [FromBody]R_Table R_Table)
        {
             
            if (ModelState.IsValid)
                R_TableTrpository.Update(TableNo, R_Table);
        }

        // DELETE api/values/5
        [HttpDelete("{TableNo}")]
        public void Delete(String TableNo)
        {
            R_TableTrpository.Delete(TableNo);
        }
    }
}