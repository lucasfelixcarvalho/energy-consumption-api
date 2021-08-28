using EnergyApp.Domain.Consumption;
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

        public object HandleEvent(EventDto eventData)
        {
            if (string.IsNullOrEmpty(eventData.Type))
            {
                return null;
            }

            if (eventData.Type == "import")
            {
                MeterDto meter = eventData.EventToMeter();
                _MeterRepository.InsertMeter(meter);
                return meter;
            }
            else if (eventData.Type == "push")
            {
                ConsumptionDto consumption = eventData.EventToConsumption();
                MeterDto meter = _MeterRepository.UpdateMeterConsumption(consumption);
                return meter;
            }

            return null;
        }

        public void InsertMeter(MeterDto meter)
        {
            _MeterRepository.InsertMeter(meter);
        }

        public MeterDto UpdateMeterConsumption(ConsumptionDto consumption)
        {
            return _MeterRepository.UpdateMeterConsumption(consumption);
        }
    }
}
