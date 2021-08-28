using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event
{
    public interface IEventService
    {
        void InsertMeter(MeterDto meter);
        MeterDto UpdateMeterConsumption(ConsumptionDto consumption);
        object HandleEvent(EventDto eventData);
    }
}
