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
    [Route("api/Temp_Stock")]
    public class Temp_StockController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly Temp_StockRepository Temp_StockRepository;

        public Temp_StockController()
        {
            Temp_StockRepository = new Temp_StockRepository();
        }
        [HttpGet]
        public IEnumerable<Temp_Stock> Get()
        {
            return Temp_StockRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Temp_Stock  Get(int id)
        {
            return Temp_StockRepository.GetByID(id);

        }
        [HttpPost]
        public void Post([FromBody]List<Temp_Stock> Tem)
        {
            if (ModelState.IsValid)
                Temp_StockRepository.Add(Tem);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Temp_Stock Tem)
        {
            Tem.Id = id;
            if (ModelState.IsValid)
                Temp_StockRepository.Update(Tem);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid)
                Temp_StockRepository.Delete(id);
        }
    }
}