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
    [Route("api/EmployeeRegistration")]
    public class EmployeeRegistrationController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly EmployeeRegistrationRepository EmployeeRegistrationRepository;
        public EmployeeRegistrationController()
        {
            EmployeeRegistrationRepository = new EmployeeRegistrationRepository();
        }
        [HttpGet]
        public IEnumerable<EmployeeRegistration> Get()
        {
           return EmployeeRegistrationRepository.GetAll();
        }
        [HttpGet("{id}")]
        public EmployeeRegistration Get(int id)
        {
            return EmployeeRegistrationRepository.GetByID(id);
        }

        [HttpPost]
        public void  Post([FromBody]EmployeeRegistration Emp)
        {
            if(ModelState.IsValid)
              EmployeeRegistrationRepository.Add(Emp);
        }
        [HttpPut("{EmployeeID}")]
        public void Put(string EmployeeID, [FromBody]EmployeeRegistration Emp)
        {
                Emp.EmployeeID = EmployeeID;
            if (ModelState.IsValid)
                EmployeeRegistrationRepository.Update(Emp);
        }
        [HttpDelete("{EmployeeID}")]
        public void Delete(string EmployeeID)
        {
           
            if (ModelState.IsValid)
                EmployeeRegistrationRepository.Delete(EmployeeID);
        }
    }

}