using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event
{
    public interface IEventService
    {
        void InsertMeter(MeterDto meter);
    }
}
