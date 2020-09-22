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
    [Route("api/Member")]
    public class MemberController : ControllerBase
    {

        private readonly MemberRepository MemberRepository;
        public MemberController()
        {
            MemberRepository = new MemberRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Member> Get()
        {
            return MemberRepository.GetAll();
        }
        [HttpGet("GetId")]
        public int GetId()
        {
            return MemberRepository.GetId();
        }

        // GET api/values/5
        [HttpGet("{MemberID}")]
        public Member Get(int id)
        {
            return MemberRepository.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Member member)
        {
            if (ModelState.IsValid)
                MemberRepository.Add(member);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Member member)
        {
            
            if (ModelState.IsValid)
                MemberRepository.Update(member);
        }

        // DELETE api/values/5
        [HttpDelete("{MemberID}")]
        public void Delete(int MemberID)
        {
            MemberRepository.Delete(MemberID);
        }
    }
}
 