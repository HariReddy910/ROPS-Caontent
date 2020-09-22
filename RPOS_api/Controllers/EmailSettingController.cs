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
    [Route("api/EmailSetting")]
    public class EmailSettingController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly EmailSettingRepository EmailSettingRepository;
        public EmailSettingController()
        {
            EmailSettingRepository = new EmailSettingRepository();
        }
        [HttpGet]
        public IEnumerable<EmailSetting> Get()
        {
            return EmailSettingRepository.GetAll();
        }
        [HttpGet("{id}")]
        public EmailSetting Get(int id)
        {
            return EmailSettingRepository.GetById(id);
        }
        [HttpPost]
        public void Post([FromBody]EmailSetting emailSetting)
        {
            if(ModelState.IsValid)
            EmailSettingRepository.Add(emailSetting);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]EmailSetting emailSetting)
        {
            emailSetting.Id = id;
            if (ModelState.IsValid)
                EmailSettingRepository.Update(emailSetting);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
                EmailSettingRepository.Delete(id);
        }
    }
}