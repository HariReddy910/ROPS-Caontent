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
    [Route("api/Voucher")]
    public class VoucherController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly Voucher_Repository Voucher_Repository;

        public VoucherController()
        {
            Voucher_Repository = new Voucher_Repository();
        }
        [HttpGet]
        public IEnumerable<Voucher> Get()
        {
            return Voucher_Repository.GetAll();
        }
        [HttpGet("GetId")]
        public  int GetID()
        {
            return Voucher_Repository.GetId();
        }
        [HttpGet("GetByID")]
        public Voucher Get(int ID)
        {
            return Voucher_Repository.GetByID(ID);

        }
        [HttpPost]
        public void Post([FromBody]Voucher vou)
        {
            if (ModelState.IsValid)
                Voucher_Repository.Add(vou);
        }
        [HttpPut("{ID}")]
        public void Put(int id, [FromBody] Voucher vou)
        {
            vou.ID = id;
            if (ModelState.IsValid)
                Voucher_Repository.Update(vou);
        }
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {

            if (ModelState.IsValid)
                Voucher_Repository.Delete(ID);
        }

    }
}