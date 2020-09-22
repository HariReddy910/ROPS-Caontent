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
    [Route("api/Registration")]
    public class RegistrationController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly RegistrationRepository RegistrationRepository;

        public RegistrationController()
        {
            RegistrationRepository = new RegistrationRepository();
        }
        [HttpGet]
        public IEnumerable<Registration> Get()
        {
            return RegistrationRepository.GetAll();
        }
        [HttpGet("{UserId}")]
        public Registration Get(string UserId)
        {
            return RegistrationRepository.GetByID(UserId);
        }
        [HttpPost]
        public void Post([FromBody]Registration Registration)
        {
            if (ModelState.IsValid)
                RegistrationRepository.Add(Registration);
        }
        [HttpPut("{UserId}")]
        public void Put(string UserId, [FromBody]Registration Registration)
        {

            if (ModelState.IsValid)
                RegistrationRepository.Update(UserId, Registration);
        }
        //[Route("api/ChangePin")]
        [HttpPut("ChangePin") ]
        public  int  ChangePin(string oldPwd, [FromBody]Registration Registration)
        {
            int id = default(int);
            if (ModelState.IsValid)
                id= RegistrationRepository.ChangePin(oldPwd, Registration);
            return id;
        }
        [HttpDelete("{UserId}")]
        public void Delete(string UserId)
        {
            if (ModelState.IsValid)
                RegistrationRepository.Delete(UserId);
        }
    }
}