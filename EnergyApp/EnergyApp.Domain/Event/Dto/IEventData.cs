using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event.Dto
{
    public interface IEventData
    {
        MeterDto EventToMeter();
        ConsumptionDto EventToConsumption();
    }
}
