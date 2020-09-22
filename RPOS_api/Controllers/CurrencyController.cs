using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Model;
using RPOS.Repository;
using RPOS.ModelWarehouse;

namespace RPOS.Controllers
{   [Produces("application/json")]
    [Route("api/Currency")]
    public class CurrencyController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly CurrencyRepository CurrencyRepository;

        public CurrencyController()
        {
            CurrencyRepository = new CurrencyRepository();
        }
        [HttpGet]
        public IEnumerable<Currency> Get()
        {
            return CurrencyRepository.GetAll();
        }
        [HttpGet("{currencyCode}")]
        public Currency Get(string currencyCode)
        {
            return CurrencyRepository.GetByID(currencyCode);
        }
        [HttpPost]
        public void Post([FromBody]Currency curr)
        {
            if (ModelState.IsValid)
                CurrencyRepository.Add(curr);
        }
        [HttpPut("{CurrencyCode}")]
        public void Put(string  CurrencyCode, [FromBody]Currency curr)
        {
            
            if (ModelState.IsValid)
                CurrencyRepository.Update(CurrencyCode, curr );
        }
        [HttpDelete("{Currencycode}")]
        public void Delete(string currencyCode)
        {
            if (ModelState.IsValid)
                CurrencyRepository.Delete(currencyCode);
        }
    }
}