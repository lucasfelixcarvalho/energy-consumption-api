using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event.Handlers
{
    public class PushHandler : IEventHandler
    {
        private readonly IMeterRepository _MeterRepository;

        public string EventType { get => "Push"; }
        
        public PushHandler(IMeterRepository meterRepository)
        {
            _MeterRepository = meterRepository;            
        }

        public object HandleEvent(EventDto eventData)
        {
            ConsumptionDto consumption = EventToConsumption(eventData);
            MeterDto meter = _MeterRepository.UpdateMeterConsumption(consumption);
            return meter;
        }

        private ConsumptionDto EventToConsumption(EventDto eventData)
        {
            return new ConsumptionDto
            {
                ActiveEnergy = eventData.ActiveEnergy,
                InjectedEnergy = eventData.InjectedEnergy,
                MeterNumber = eventData.MeterNumber
            };
        }
    }
}