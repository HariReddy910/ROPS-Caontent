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
    [Route("api/Stock_Store")]

    public class Stock_StoreController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Stock_StoreRepository Stock_StoreRepository;

        public Stock_StoreController()
        {
            Stock_StoreRepository = new Stock_StoreRepository();
        }
        [HttpGet]
        public IEnumerable<Stock_Store> Get()
        {
            return Stock_StoreRepository.GetAll();
        }
        [HttpGet("GetId")]
        public int GetId()
        {
            return Stock_StoreRepository.GetId();
        }

        [HttpGet("{St_ID}")]    
        public Stock_Store Get(int St_ID)
        {
            return Stock_StoreRepository.GetByID(St_ID);

        }
        [HttpPost]
        public void Post([FromBody]Stock_Store store)
        {
            if (ModelState.IsValid)
                Stock_StoreRepository.Add(store);
        }
        [HttpPut("{St_ID}")]
        public void Put(int St_ID, [FromBody] Stock_Store store)
        {
            store.St_ID = St_ID;
            if (ModelState.IsValid)
                Stock_StoreRepository.Update(store);
        }
        [HttpDelete("{St_ID}")]
        public void Delete(int St_ID)
        {

            if (ModelState.IsValid)
                Stock_StoreRepository.Delete(St_ID);
        }

    }
}