using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPOS.Repository;
using RPOS.Model;

namespace RPOS.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly CustomerRepository CustomerRepository;
        public CustomerController()
        {
            CustomerRepository = new CustomerRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return CustomerRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return CustomerRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Customer cust)
        {
            if (ModelState.IsValid)
                CustomerRepository.Add(cust);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer cust)
        {
            cust.CustomerId = id;
            if (ModelState.IsValid)
                CustomerRepository.Update(cust);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerRepository.Delete(id);
        }
    }
}