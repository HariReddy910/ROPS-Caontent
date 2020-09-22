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
    [Route("api/SupplierLedgerBook")]
    public class SupplierLedgerBookController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly SupplierLedgerBookRepository SupplierLedgerBookRepository;

        public SupplierLedgerBookController()
        {
            SupplierLedgerBookRepository = new SupplierLedgerBookRepository();
        }
        [HttpGet]
        public IEnumerable<SupplierLedgerBook> Get()
        {
            return SupplierLedgerBookRepository.GetAll();
        }

        [HttpGet("Getbalance")]
        public double Getbalance(string SupplierID)
        {
            return SupplierLedgerBookRepository.Getbalance(SupplierID);
        }
        [HttpGet("{Id}")]
        public SupplierLedgerBook Get(int id)
        {
            return SupplierLedgerBookRepository.GetByID(id);

        }
        [HttpPost]
        public void Post([FromBody]SupplierLedgerBook sup)
        {
            if (ModelState.IsValid)
                SupplierLedgerBookRepository.Add(sup);
                    
        }
        [HttpPut("{Id}")]
        public void Put(int id, [FromBody] SupplierLedgerBook sup)
        {
            sup.Id = id;
            if (ModelState.IsValid)
                SupplierLedgerBookRepository.Update(sup);
        }
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid)
                SupplierLedgerBookRepository.Delete(id);
        }
    }
}