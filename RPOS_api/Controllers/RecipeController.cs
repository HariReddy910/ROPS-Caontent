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
    [Route("api/Recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeRepository RecipeRepository;
        public RecipeController()
        {
            RecipeRepository = new RecipeRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return RecipeRepository.GetAll();
        }
        [HttpGet("GetId")]
        public int GetId()
        {
            return RecipeRepository.GetId();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return RecipeRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Recipe Recipe)
        {
            if (ModelState.IsValid)
                RecipeRepository.Add(Recipe);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Recipe Recipe)
        {
            Recipe.R_ID = id;
            if (ModelState.IsValid)
                RecipeRepository.Update(Recipe);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RecipeRepository.Delete(id);
        }
    }
}