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
    [Route("api/Category")]

    public class CategoryController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly CategoryRepository CategoryRepository;

        public CategoryController()
        {
            CategoryRepository = new CategoryRepository();
        }
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return CategoryRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return CategoryRepository.GetByID(id);

        }
        [HttpPost]
        public void Post([FromBody]Category Cat)
        {
            if (ModelState.IsValid)
                CategoryRepository.Add(Cat);
        }
        [HttpPut("{Cat_ID}")]
        public void Put(int Cat_ID, [FromBody] Category Cat)
        {
            Cat.Cat_ID = Cat_ID;
            if (ModelState.IsValid)
                CategoryRepository.Update(Cat);
        }
        [HttpDelete("{Cat_ID}")]
        public void Delete(int Cat_ID)
        {

            if (ModelState.IsValid)
                CategoryRepository.Delete(Cat_ID);
        }
    }
}