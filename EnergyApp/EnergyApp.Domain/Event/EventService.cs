using EnergyApp.Domain.Meter;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event
{
    public class EventService : IEventService
    {
        private readonly IMeterRepository _MeterRepository;

        public EventService(IMeterRepository meterRepository)
        {
            _MeterRepository = meterRepository;
        }

        public void InsertMeter(MeterDto meter)
        {
            _MeterRepository.InsertMeter(meter);
        }
    }
}
