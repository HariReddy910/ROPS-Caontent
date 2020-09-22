using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Repository;
using RPOS.Model;
namespace RPOS.Controller
{
    [Produces("application/json")]
    [Route("api/Recipe_Join")]
    public class Recipe_JoinController : ControllerBase
    {
        private readonly Recipe_JoinRepository Recipe_JoinRepository;
        public Recipe_JoinController()
        {
            Recipe_JoinRepository = new Recipe_JoinRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Recipe_Join> Get()
        {
            return Recipe_JoinRepository.GetAll();
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public Recipe_Join Get(int id)
        {
            return Recipe_JoinRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]List<Recipe_Join> ledgerBook)
        {
            if (ModelState.IsValid)
                Recipe_JoinRepository.Add(ledgerBook);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Recipe_Join Recipe_Join)
        {
            Recipe_Join.RJ_ID = id;
            if (ModelState.IsValid)
                Recipe_JoinRepository.Update(Recipe_Join);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Recipe_JoinRepository.Delete(id);
        }
    }
}