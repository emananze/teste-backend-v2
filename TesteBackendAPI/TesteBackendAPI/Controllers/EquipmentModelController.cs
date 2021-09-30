using Contracts.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentModelController : ControllerBase
    {

        private readonly IEquipmentModelService _equipmentModelService;
        public EquipmentModelController(IEquipmentModelService service)
        {
            _equipmentModelService = service ?? throw new ArgumentNullException(nameof(service));
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<EquipmentModel>>  Get()
        {
            var equipmentModels = _equipmentModelService.GetEquipmentModels();

            if(equipmentModels == null)
            {
                return NotFound();
            }

            return equipmentModels;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{Id}")]
        public ActionResult<EquipmentModel> Get(Guid Id)
        {
            var equipmentModel = _equipmentModelService.GetEquipmentModel(Id);

            if (equipmentModel == null)
            {
                return NotFound();
            }

            return equipmentModel;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] EquipmentModel equipmentModel)
        {
            _equipmentModelService.CreateEquipmentModel(equipmentModel);

            return NoContent();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{Id}")]
        public ActionResult Put(Guid Id, [FromBody] EquipmentModel equipmentModel)
        {
            if (!_equipmentModelService.EquipmentModelExists(Id))
            {
                return NotFound();
            }

            _equipmentModelService.UpdateEquipmentModel(Id,equipmentModel);

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{Id}")]
        public ActionResult Delete(Guid Id)
        {
            if (!_equipmentModelService.EquipmentModelExists(Id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
