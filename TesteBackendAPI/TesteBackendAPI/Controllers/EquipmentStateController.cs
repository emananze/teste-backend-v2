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
    public class EquipmentStateController : ControllerBase
    {

        private readonly IEquipmentStateService _equipmentStateService;
        public EquipmentStateController(IEquipmentStateService service)
        {
            _equipmentStateService = service ?? throw new ArgumentNullException(nameof(service));
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<EquipmentState>>  Get()
        {
            var equipmentStates = _equipmentStateService.GetEquipmentStates();

            if(equipmentStates == null)
            {
                return NotFound();
            }

            return equipmentStates;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{Id}")]
        public ActionResult<EquipmentState> Get(Guid Id)
        {
            var equipmentState = _equipmentStateService.GetEquipmentState(Id);

            if (equipmentState == null)
            {
                return NotFound();
            }

            return equipmentState;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] EquipmentState equipmentState)
        {
            _equipmentStateService.CreateEquipmentState(equipmentState);

            return NoContent();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{Id}")]
        public ActionResult Put(Guid Id, [FromBody] EquipmentState equipmentState)
        {
            if (!_equipmentStateService.EquipmentStateExists(Id))
            {
                return NotFound();
            }

            _equipmentStateService.UpdateEquipmentState(Id, equipmentState);

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{Id}")]
        public ActionResult Delete(Guid Id)
        {
            if (!_equipmentStateService.EquipmentStateExists(Id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
