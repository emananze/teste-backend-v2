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
    public class EquipmentModelStateHourlyEarningController : ControllerBase
    {

        private readonly IEquipmentModelStateHourlyEarningService _equipmentModelStateHourlyEarningService;
        public EquipmentModelStateHourlyEarningController(IEquipmentModelStateHourlyEarningService service)
        {
            _equipmentModelStateHourlyEarningService = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<EquipmentModelStateHourlyEarningController>
        [HttpGet]
        public ActionResult<IEnumerable<EquipmentModelStateHourlyEarning>> Get()
        {
            var equipments = _equipmentModelStateHourlyEarningService.GetEquipmentModelStateHourlys();

            if (equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        // GET: api/<EquipmentModelStateHourlyEarningController>
        [HttpGet("{equipmentStateId}/GetEquipmentModelStateHourlysByState")]
        public ActionResult<IEnumerable<EquipmentModelStateHourlyEarning>> GetCurrentState(Guid equipmentStateId)
        {
            var equipmentPositionHistory = _equipmentModelStateHourlyEarningService.GetEquipmentModelStateHourlysByState(equipmentStateId);

            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        // GET: api/<EquipmentPositionHistoryController>
        [HttpGet("{equipmentModelId}/GetEquipmentModelStateHourlysByModel")]
        public ActionResult<IEnumerable<EquipmentModelStateHourlyEarning>> GetEquipmentModelStateHourlysByModel(Guid equipmentModelId)
        {
            var equipments = _equipmentModelStateHourlyEarningService.GetEquipmentModelStateHourlysByModel(equipmentModelId);

            if (equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        // PUT api/<EquipmentModelStateHourlyEarningController>/5
        [HttpPost]
        public ActionResult Post([FromBody] EquipmentModelStateHourlyEarning equipmentModelStateHourlyEarning)
        {
            _equipmentModelStateHourlyEarningService.CreateEquipmentModelStateHourly(equipmentModelStateHourlyEarning);

            return NoContent();
        }

        
    }
}
