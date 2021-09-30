using Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {

        private readonly IEquipmentStateHistoryService _equipmentStateHistoryService;
        public HomeController(IEquipmentStateHistoryService service)
        {
            _equipmentStateHistoryService = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<EquipmentStateHistoryController>
        [HttpGet]
        public ActionResult GetEquipmentState()
        {
            var equipments = _equipmentStateHistoryService.GetEquipmentStateHistories();

            if (equipments == null)
            {
                return NotFound();
            }

            return View("../EquipmentStateHistory", equipments);
        }
    }
}
