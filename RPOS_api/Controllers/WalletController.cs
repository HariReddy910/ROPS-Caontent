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
    [Route("api/Wallet")]
    public class WalletController : Microsoft.AspNetCore.Mvc.Controller
    {


        private readonly WalletRepository WalletRepository;

        public WalletController()
        {
            WalletRepository = new WalletRepository();
        }
        [HttpGet]
        public IEnumerable<Wallet> Get()
        {
            return WalletRepository.GetAll();
        }
        //[HttpGet("{WalletType}")]
        //public Wallet Get( String WalletType)
        //{
        //    return WalletRepository.GetByWalletType(WalletType);

        //}
        [HttpPost]
        public void Post([FromBody]Wallet wel)
        {
            if (ModelState.IsValid)
                WalletRepository.Add(wel);
        }
        [HttpPut("{WalletType}")]
        public void Put(string WalletType, [FromBody] Wallet wel)
        {
            
            if (ModelState.IsValid)
                WalletRepository.Update(WalletType,wel);
        }
        [HttpDelete("{WalletType}")]
        public void Delete(String wel)
        {

            if (ModelState.IsValid)
                WalletRepository.Delete(wel);
        }
    }
}