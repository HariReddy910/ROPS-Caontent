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
    [Route("api/Supplier")]
    public class SupplierController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly SupplierRepository SupplierRepository;

        public SupplierController()
        {
            SupplierRepository = new SupplierRepository();
        }
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return SupplierRepository.GetAll();
        }
         
        [HttpGet ]
        [Route("Get")]
        public int GetID()
        {
            return SupplierRepository.GetId();
        }
        [HttpGet("{SupplierId}")]
        public Supplier Get(string SupplierId)
        {
            return SupplierRepository.GetByID(SupplierId);

        }
        [HttpPost]
        public void Post([FromBody]Supplier supa)
        {
            if (ModelState.IsValid)
                SupplierRepository.Add(supa);
        }
        [HttpPut("{ID}")]
        public void Put(int ID, [FromBody] Supplier supa)
        {
            supa.ID = ID;
            if (ModelState.IsValid)
                SupplierRepository.Update(supa);
        }
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {

            if (ModelState.IsValid)
                SupplierRepository.Delete(ID);
        }
    }
}