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
    [Route("api/SMSSetting")]
    public class SMSSettingController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly SMSSettingRepository SMSSettingRepository;

        public SMSSettingController()
        {
            SMSSettingRepository = new SMSSettingRepository();
        }
        [HttpGet]
        public IEnumerable<SMSSetting> Get()
        {
            return SMSSettingRepository.GetAll();
        }
        [HttpGet("{Id}")]
        public SMSSetting Get(int Id)
        {
            return SMSSettingRepository.GetByID(Id);
        }
        [HttpPost]
        public void Post([FromBody]SMSSetting SMSSetting)
        {
            if (ModelState.IsValid)
                SMSSettingRepository.Add(SMSSetting);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody]SMSSetting SMSSetting)
        {
            SMSSetting.Id = Id;

            if (ModelState.IsValid)
                SMSSettingRepository.Update(SMSSetting);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            if (ModelState.IsValid)
                SMSSettingRepository.Delete(Id);
        }
    }
}