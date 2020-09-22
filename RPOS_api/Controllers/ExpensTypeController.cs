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
    [Route("api/ExpensType")]
    public class ExpensTypeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ExpenseTypeRepository ExpenseTypeRepository;
        public ExpensTypeController()
        {
            ExpenseTypeRepository = new ExpenseTypeRepository();
        }

        [HttpGet]
        public IEnumerable<ExpenseType> Get()
        {
            return ExpenseTypeRepository.GetAll();
        }
        [HttpPost]
        public void Post([FromBody]ExpenseType Exp)
        {
            ExpenseTypeRepository.Add(Exp);
        }
        [HttpPut("{Type}")]
        public void Put(String Type, [FromBody]ExpenseType Exp)
        {
            ExpenseTypeRepository.Update(Type, Exp);
        }
        [HttpDelete("{Type}")]
        public void Delete(String Type)
        {
            ExpenseTypeRepository.Delete(Type);
        }
    }
}