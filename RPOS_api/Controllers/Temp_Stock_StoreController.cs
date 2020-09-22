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
    [Route("api/Temp_Stock_Store")]
    public class Temp_Stock_StoreController : Microsoft.AspNetCore.Mvc.Controller
    {
         private readonly Temp_Stock_StoreRepository Temp_Stock_StoreRepository;

        public Temp_Stock_StoreController()
        {
            Temp_Stock_StoreRepository = new Temp_Stock_StoreRepository();
        }
        [HttpGet]
         public IEnumerable<Temp_Stock_Store> Get()
        {
            return Temp_Stock_StoreRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Temp_Stock_Store Get(int id)
        {
            return Temp_Stock_StoreRepository.GetByID(id);

        }
        [HttpPost]
        public void Post([FromBody]Temp_Stock_Store Tems)
        {
            if (ModelState.IsValid)
                Temp_Stock_StoreRepository.Add(Tems);
        }
        [HttpPut("{id}")]
        public void Put(int id ,[FromBody] Temp_Stock_Store Tems)
        {
            Tems.Id = id;
            if (ModelState.IsValid)
                Temp_Stock_StoreRepository.Update(Tems);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid)
                Temp_Stock_StoreRepository.Delete(id);
        }
    
    }
}