using System;
using EnergyApp.Domain.Meter;
using Microsoft.AspNetCore.Mvc;

namespace EnergyApp.Api.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ConsumptionController : ControllerBase
    {
        private readonly IMeterService _MeterService;
        
        public ConsumptionController(IMeterService meterService)
        {
            _MeterService = meterService;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok($"Ping successfull: {DateTime.Now:yyyy-MMM-dd HH:mm:ss}");
        }

        [HttpGet()]
        public IActionResult GetConsumptionForMeter(string meter_number)
        {
            decimal? consumption = _MeterService.GetConsumptionForMeter(meter_number);

            if (consumption  is null)
            {
                return NotFound();
            }

            return Ok(consumption);
        }
    }
}
