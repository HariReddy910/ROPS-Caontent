using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Model;
using RPOS.Repository;

namespace RPOS.Controllers
{
    [Produces("application/json")]
    [Route("api/Dish")]
    public class DishController : ControllerBase
    {

        private readonly DishRepository DishRepository;
        public DishController()
        {
            DishRepository = new DishRepository();
        }
        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return DishRepository.GetAll();
        }
        [HttpGet("{DishName}")]
        public Dish Get(string DishName)
        {
            return DishRepository.GetByDishName(DishName);
        }
        [HttpPost]
        public void Post([FromBody]Dish dish)
        {
            DishRepository.Add(dish);
        }
        [HttpPut("{DishName}")]
        public void Put(string DishName, [FromBody]Dish dish)
        {
            DishRepository.Update(DishName, dish);
        }
        [HttpDelete("{DishName}")]
        public void Delete(string DishName)
        {
            DishRepository.Delete(DishName);
        }
    }
}