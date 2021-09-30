using Contracts.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentPositionHistoryController : ControllerBase
    {

        private readonly IEquipmentPositionHistoryService _equipmentPositionHistoryService;
        public EquipmentPositionHistoryController(IEquipmentPositionHistoryService service)
        {
            _equipmentPositionHistoryService = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<EquipmentPositionHistoryController>
        [HttpGet]
        public ActionResult<IEnumerable<EquipmentPositionHistory>> Get()
        {
            var equipments = _equipmentPositionHistoryService.GetEquipmentPositionHistories();

            if (equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        // GET: api/<EquipmentPositionHistoryController>
        [HttpGet("{equipmentId}/GetCurrentState")]
        public ActionResult<EquipmentPositionHistory> GetCurrentState(Guid equipmentId)
        {
            var equipmentPositionHistory = _equipmentPositionHistoryService.GetLastPosition(equipmentId);

            if (equipmentPositionHistory == null)
            {
                return NotFound();
            }

            return equipmentPositionHistory;
        }

        // GET: api/<EquipmentPositionHistoryController>
        [HttpGet("{equipmentId}/GetEquipmentPositionHistoriesByStateId")]
        public ActionResult<IEnumerable<EquipmentPositionHistory>> GetEquipmentPositionHistories(Guid equipmentId)
        {
            var equipments = _equipmentPositionHistoryService.GetEquipmentPositionHistories(equipmentId);

            if (equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        // POST api/<EquipmentPositionHistoryController>
        [HttpPost]
        public ActionResult Post([FromBody] EquipmentPositionHistory equipmentPosition)
        {
            _equipmentPositionHistoryService.CreateEquipmentPositionHistory(equipmentPosition);

            return NoContent();
        }
    }
}
