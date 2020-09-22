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
    [Route("api/MemberLedger")]
    public class MemberLegdgerController : ControllerBase
    {
        private readonly MemberLedgerRipository MemberLedgerRipository;
        public MemberLegdgerController()
        {
            MemberLedgerRipository = new MemberLedgerRipository();
        }
       // GET: api/values
       [HttpGet]
        public IEnumerable<MemberLedger> Get()
        {
            return MemberLedgerRipository.GetBalanceOfMember();
        }

        [HttpPost("CardDetail")]
        public IEnumerable<MemberLedger> CardDetail([FromBody] List<Member> List)
        {
            return MemberLedgerRipository.CardDetail(List);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public MemberLedger Get(int id)
        {
            return MemberLedgerRipository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]MemberLedger memberLedger)
        {
            if (ModelState.IsValid)
                MemberLedgerRipository.Add(memberLedger);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]MemberLedger memberLedger)
        {
            memberLedger.Id = id;
            if (ModelState.IsValid)
                MemberLedgerRipository.Update(memberLedger);
        }

        // DELETE api/values/5
        [HttpDelete("{MemberID}")]
        public void Delete(int MemberID)
        {
            MemberLedgerRipository.Delete(MemberID);
        }
    }
}