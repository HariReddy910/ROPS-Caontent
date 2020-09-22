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
    [Route("api/Product")]
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ProductRepository ProductRepository;
        public ProductController()
        {
            ProductRepository = new ProductRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductRepository.GetAll();
        }

        [HttpGet("GetProductCode")]
        public int GetProductCode()
        {
            return ProductRepository.GetProductCode();
        }

        [HttpGet("GetCategory")]
        public IEnumerable<Product> GetCategory()
        {
            return ProductRepository.GetCategory();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return ProductRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product Product)
        {
            if (ModelState.IsValid)
                ProductRepository.Add(Product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product Product)
        {
            Product.PID= id;
            if (ModelState.IsValid)
                ProductRepository.Update(Product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductRepository.Delete(id);
        }

        
    }
}