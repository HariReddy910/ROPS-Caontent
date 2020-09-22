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
    [Route("api/Product_OpeningStock")]
    public class Product_OpeningStockRepositoryController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Product_OpeningStockRepository Product_OpeningStockRepository;
        public Product_OpeningStockRepositoryController()
        {
            Product_OpeningStockRepository = new Product_OpeningStockRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Product_OpeningStock> Get()
        {
            return Product_OpeningStockRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{PS_ID}")]
        public Product_OpeningStock Get(int PS_ID)
        {
            return Product_OpeningStockRepository.GetByID(PS_ID);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]List<Product_OpeningStock> Product_OpeningStock)
        {
            if (ModelState.IsValid)
                Product_OpeningStockRepository.Add(Product_OpeningStock);
        }

        // PUT api/values/5
        [HttpPut("{PS_ID}")]
        public void Put(int id, [FromBody]Product_OpeningStock Product_OpeningStock)
        {
           
            if (ModelState.IsValid)
                Product_OpeningStockRepository.Update(Product_OpeningStock);
        }

        // DELETE api/values/5
        [HttpDelete("{PS_ID}")]
        public void Delete(int id)
        {
            Product_OpeningStockRepository.Delete(id);
        }
    }
}