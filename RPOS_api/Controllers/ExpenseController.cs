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
    [Route("api/Expense")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseRepository ExpenseRepository;
        public ExpenseController()
        {
            ExpenseRepository = new ExpenseRepository();
        }
        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return ExpenseRepository.GetAll();
        }
        [HttpGet("{ExpenseName}")]
        public Expense Get(String ExpenseName)
        {
            return ExpenseRepository.GetByID(ExpenseName);
        }

        [HttpPost]
        public void Post([FromBody]Expense Exp)
        {
            if (ModelState.IsValid)
                ExpenseRepository.Add(Exp);
        }
        [HttpPut("{ExpenseName}")]
        public void Put(String ExpenseName, [FromBody] Expense Exp)
        {
             
            if (ModelState.IsValid)
                ExpenseRepository.Update(ExpenseName, Exp);
        }
        [HttpDelete("{ExpenseName}")]
        public void Delete(String ExpenseName)
        {

            if (ModelState.IsValid)
                ExpenseRepository.Delete(ExpenseName);
        }
    }
}