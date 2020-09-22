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
    [Route("api/PosPrinterSetting")]
    public class PosPrinterSettingController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly PosPrinterSettingRepository PosPrinterSettingRepository;
        public PosPrinterSettingController()
        {
            PosPrinterSettingRepository = new PosPrinterSettingRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<PosPrinterSetting> Get()
        {
            return PosPrinterSettingRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PosPrinterSetting Get(int id)
        {
            return PosPrinterSettingRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]PosPrinterSetting PosPrinterSetting)
        {
            if (ModelState.IsValid)
                PosPrinterSettingRepository.Add(PosPrinterSetting);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PosPrinterSetting PosPrinterSetting)
        {
            PosPrinterSetting.Id = id;
            if (ModelState.IsValid)
                PosPrinterSettingRepository.Update(PosPrinterSetting);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PosPrinterSettingRepository.Delete(id);
        }
    }
}