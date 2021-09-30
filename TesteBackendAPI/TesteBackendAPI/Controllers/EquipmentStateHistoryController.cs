using Contracts.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentStateHistoryController : ControllerBase
    {

        private readonly IEquipmentStateHistoryService _equipmentStateHistoryService;
        public EquipmentStateHistoryController(IEquipmentStateHistoryService service)
        {
            _equipmentStateHistoryService = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<EquipmentStateHistoryController>
        [HttpGet]
        public ActionResult<IEnumerable<EquipmentStateHistory>> GetEquipmentStateHistory()
        {
            var equipments = _equipmentStateHistoryService.GetEquipmentStateHistories();

            if (equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        //// GET: api/<EquipmentStateHistoryController>
        //[HttpGet]
        //public ActionResult GetEquipmentState()
        //{
        //    var equipments = _equipmentStateHistoryService.GetEquipmentStateHistories();

        //    if (equipments == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(equipments);

        //    //return View("../Views/EquipmentStateHistory", equipments);
        //}

        [HttpGet("{equipmentId}/GetLastState")]
        public ActionResult<string> GetLastState(Guid equipmentId)
        {
            var state = _equipmentStateHistoryService.GetLastState(equipmentId);

            if (string.IsNullOrEmpty(state))
            {
                return NotFound();
            }

            return  state;
        }

        [HttpGet("{equipmentId}/GetEquipmentStateHistoryByEquipmentId")]
        public ActionResult<IEnumerable<EquipmentStateHistory>> GetEquipmentStateHistoriesByEquipment(Guid equipmentId)
        {
            var equipments = _equipmentStateHistoryService.GetEquipmentStateHistoriesByEquipment(equipmentId);

            if (equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        [HttpGet("{equipmentStateId}/GetEquipmentStateHistoryByStateId")]
        public ActionResult<IEnumerable<EquipmentStateHistory>> GetEquipmentStateHistoriesByState(Guid equipmentStateId)
        {
            var equipments = _equipmentStateHistoryService.GetEquipmentStateHistoriesByState(equipmentStateId);

            if (equipments == null)
            {
                return NotFound();
            }

            return equipments;
        }

        // POST api/<EquipmentStateHistoryController>
        [HttpPost]
        public ActionResult Post([FromBody] EquipmentStateHistory equipmentStateHistory)
        {
            _equipmentStateHistoryService.CreateEquipmentStateHistory(equipmentStateHistory);

            return NoContent();
        }

    }
}
