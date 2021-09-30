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
    public class EquipmentController : ControllerBase
    {

        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService service)
        {
            _equipmentService = service ?? throw new ArgumentNullException(nameof(service));
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<Equipment>>  Get()
        {
            var equipments = _equipmentService.GetEquipments();

            if(equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{Id}")]
        public ActionResult<Equipment> Get(Guid Id)
        {
            var equipment = _equipmentService.GetEquipment(Id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Equipment equipment)
        {
            _equipmentService.CreateEquipment(equipment);

            return NoContent();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{Id}")]
        public ActionResult Put(Guid Id, [FromBody] Equipment equipment)
        {
            if (!_equipmentService.EquipmentExists(Id))
            {
                return NotFound();
            }

            _equipmentService.UpdateEquipment(Id,equipment);

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{Id}")]
        public ActionResult Delete(Guid Id)
        {
            if (!_equipmentService.EquipmentExists(Id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
