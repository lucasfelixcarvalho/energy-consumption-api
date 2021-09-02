using EnergyApp.Domain.Meter;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event.Handlers
{
    public class ImportHandler : IEventHandler
    {
        private readonly IMeterRepository _MeterRepository;

        public string EventType { get => "Import"; }
        
        public ImportHandler(IMeterRepository meterRepository)
        {
            _MeterRepository = meterRepository;            
        }

        public object HandleEvent(EventDto eventData)
        {
            MeterDto meter = EventToMeter(eventData);
            _MeterRepository.InsertMeter(meter);
            return meter;
        }

        private MeterDto EventToMeter(EventDto eventData)
        {
            return new MeterDto
            {
                MeterNumber = eventData.MeterNumber,
                Consumption = eventData.Consumption,
                Microgeneration = eventData.Microgeneration
            };
        }
    }
}