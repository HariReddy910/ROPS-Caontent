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
    [Route("api/StockTransfer_Join")]
    public class StockTransfer_JoinController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly StockTransfer_JoinRepository StockTransfer_JoinRepository;

        public StockTransfer_JoinController()
        {
            StockTransfer_JoinRepository = new StockTransfer_JoinRepository();
        }
        [HttpGet]
        public IEnumerable<StockTransfer_Join> Get()
        {
            return StockTransfer_JoinRepository.GetAll();
        }
        [HttpGet("{STJ_ID}")]
        public StockTransfer_Join Get(int STJ_ID)
        {
            return StockTransfer_JoinRepository.GetByID(STJ_ID);

        }
        [HttpPost]
        public void Post([FromBody]StockTransfer_Join store)
        {
            if (ModelState.IsValid)
                StockTransfer_JoinRepository.Add(store);
        }
        [HttpPut("{STJ_ID}")]
        public void Put(int STJ_ID, [FromBody] StockTransfer_Join store)
        {
            store.STJ_ID = STJ_ID;
            if (ModelState.IsValid)
                StockTransfer_JoinRepository.Update(store);
        }
        [HttpDelete("{STJ_ID}")]
        public void Delete(int STJ_ID)
        {

            if (ModelState.IsValid)
                StockTransfer_JoinRepository.Delete(STJ_ID);
        }

    }
}