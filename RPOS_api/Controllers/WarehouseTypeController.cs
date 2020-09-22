using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPOS.ModelWarehouse;
using RPOS.Repository;

namespace RPOS.Controllers
{
     [Produces("application/json")]
        [Route("api/WarehouseType")]
    public class WarehouseTypeController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly WarehouseTypeRepository WarehouseTypeRepository;

            public String Type { get; private set; }

            public WarehouseTypeController()
            {
            WarehouseTypeRepository = new WarehouseTypeRepository();
            }
            [HttpGet]
            public IEnumerable<WarehouseType> Get()
            {
                return WarehouseTypeRepository.GetAll();
            }
            [HttpGet("{Type}")]
            public WarehouseType Get(String Type)
            {
                return WarehouseTypeRepository.GetByID(Type);

            }
            [HttpPost]
            public void Post([FromBody]WarehouseType Type)
            {
                if (ModelState.IsValid)
                WarehouseTypeRepository.Add(Type);
            }
            [HttpPut("{Type}")]
            public void Put(String Type, [FromBody] WarehouseType ware)
            {

           
                if (ModelState.IsValid)
                WarehouseTypeRepository.Update(Type,ware);
            }
            [HttpDelete("{Type}")]
            public void Delete(String Type)
            {

                if (ModelState.IsValid)
                WarehouseTypeRepository.Delete(Type);
            }
        }
    }

