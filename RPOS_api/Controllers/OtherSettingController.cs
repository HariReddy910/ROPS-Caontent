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
    [Route("api/OtherSetting")]
    public class OtherSettingController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly OtherSettingRepository OtherSettingRepository;
        public OtherSettingController()
        {
            OtherSettingRepository = new OtherSettingRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<OtherSetting> Get()
        {
            return OtherSettingRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public OtherSetting Get(int id)
        {
            return OtherSettingRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]OtherSetting NotesMaster)
        {
            if (ModelState.IsValid)
                OtherSettingRepository.Add(NotesMaster);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]OtherSetting notesMaster)
        {
            notesMaster.ID = id;
            if (ModelState.IsValid)
                OtherSettingRepository.Update(notesMaster);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OtherSettingRepository.Delete(id);
        }
    }
}