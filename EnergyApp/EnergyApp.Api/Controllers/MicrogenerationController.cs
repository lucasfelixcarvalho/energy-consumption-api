using System;
using EnergyApp.Domain.Meter;
using Microsoft.AspNetCore.Mvc;

namespace EnergyApp.Api.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class MicrogenerationController : ControllerBase
    {
        private readonly IMeterService _MeterService;
        
        public MicrogenerationController(IMeterService meterService)
        {
            _MeterService = meterService;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok($"Ping successfull: {DateTime.Now:yyyy-MMM-dd HH:mm:ss}");
        }

        [HttpGet()]
        public IActionResult GetMicrogenerationForMeter(string meter_number)
        {
            decimal? microgeneration = _MeterService.GetMicrogenerationForMeter(meter_number);

            if (microgeneration is null)
            {
                return NotFound(0);
            }

            return Ok(microgeneration);
        }
    }
}