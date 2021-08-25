using System;
using EnergyApp.Domain.Event;
using EnergyApp.Domain.Meter.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EnergyApp.Api.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _EventService;

        public EventController(IEventService eventService)
        {
            _EventService = eventService;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok($"Ping successfull: {DateTime.Now:yyyy-MMM-dd HH:mm:ss}");
        }

        [HttpPost]
        public IActionResult InsertNewMeter(MeterDto meter)
        {
            _EventService.InsertMeter(meter);
            return Ok();
        }
    }
}
