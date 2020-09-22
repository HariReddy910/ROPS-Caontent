using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.Models;
using RPOS.Repository;
using RPOS.ModelWarehouse;

namespace RPOS.Controllers
{

    [Produces("application/json")]
    [Route("api/Warehouse")]
    public class WarehouseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly WarehouseRepository WarehouseRepository;
        public WarehouseController()
        {
            WarehouseRepository = new WarehouseRepository();
        }
        [HttpGet]
        public IEnumerable<Warehouse> Get()
        {
            return WarehouseRepository.GetAll();
        }
        [HttpGet("{WarehouseName}")]
        public Warehouse Get(String WarehouseName)
        {
            return WarehouseRepository.GetByName(WarehouseName);
        }

        [HttpPost]
        public void Post([FromBody]Warehouse ware)
        {
            if (ModelState.IsValid)
                WarehouseRepository.Add(ware);
        }
        [HttpPut]
        public void Put(String WarehouseName, [FromBody] Warehouse ware)
        {

            if (ModelState.IsValid)
                WarehouseRepository.Update(WarehouseName, ware);
        }
        [HttpDelete]
        public void Delete(String WarehouseName)
        {

            if (ModelState.IsValid)
                WarehouseRepository.Delete(WarehouseName);
        }
    }
}

