using System;
using Microsoft.AspNetCore.Mvc;

namespace EnergyApp.Api.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ConsumptionController : ControllerBase
    {
        public ConsumptionController()
        {
            
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok($"Ping successfull: {DateTime.Now:yyyy-MMM-dd HH:mm:ss}");
        }

        [HttpGet()]
        public IActionResult GetConsumptionForMeter(string meter_number)
        {
            return NotFound(meter_number);
        }
    }
}
