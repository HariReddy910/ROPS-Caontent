using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Repository;
using RPOS.ModelWarehouse;
using RPOS.Model;

namespace RPOS.Controllers
{

    [Produces("application/json")]
    [Route("api/Stock_Store_Join")]
    public class Stock_Store_JoinController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Stock_Store_JoinRepository Stock_Store_JoinRepository;

        public Stock_Store_JoinController()
        {
            Stock_Store_JoinRepository = new Stock_Store_JoinRepository();
        }
        [HttpGet]
        public IEnumerable<Stock_Store_Join> Get()
        {
            return Stock_Store_JoinRepository.GetAll();
        }
        [HttpGet("{SSJ_ID}")]
        public Stock_Store_Join Get(int SSJ_ID)
        {
            return Stock_Store_JoinRepository.GetByID(SSJ_ID);

        }
        [HttpPost]
        public void Post([FromBody]List<Stock_Store_Join>  Liststore)
        {
            if (ModelState.IsValid)
                Stock_Store_JoinRepository.Add(Liststore);
        }
        [HttpPut("{SSJ_ID}")]
        public void Put(int SSJ_ID, [FromBody] Stock_Store_Join store)
        {
            store.SSJ_ID = SSJ_ID;
            if (ModelState.IsValid)
                Stock_Store_JoinRepository.Update(store);
        }
        [HttpDelete("{SSJ_ID}")]
        public void Delete(int SSJ_ID)
        {

            if (ModelState.IsValid)
                Stock_Store_JoinRepository.Delete(SSJ_ID);
        }

    }
}