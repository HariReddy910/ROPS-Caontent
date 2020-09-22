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
    [Route("api/Voucher_OtherDetails")]
    public class VocherOtherDetailsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly VoucherRepository VoucherRepository;

        public VocherOtherDetailsController()
        {
            VoucherRepository = new VoucherRepository();
        }
        [HttpGet]
        public IEnumerable<Voucher_OtherDetailsn> Get(int ID)
        {
            return VoucherRepository.GetAll(ID);
        }
        //[HttpGet()]
        //public Voucher_OtherDetailsn Get(int VD_ID)
        //{
        //    return VoucherRepository.GetByID(VD_ID);

        //}
        [HttpPost]
        public void Post([FromBody]List<Voucher_OtherDetailsn> voc)
        {
            if (ModelState.IsValid)
                VoucherRepository.Add(voc);
        }
        [HttpPut("{VD_ID}")]
        public void Put(int VD_ID, [FromBody] Voucher_OtherDetailsn voc)
        {
            voc.VD_ID = VD_ID;
            if (ModelState.IsValid)
                VoucherRepository.Update(voc);
        }
        [HttpDelete("{VD_ID}")]
        public void Delete(int VD_ID)
        {

            if (ModelState.IsValid)
                VoucherRepository.Delete(VD_ID);
        }
    }
}