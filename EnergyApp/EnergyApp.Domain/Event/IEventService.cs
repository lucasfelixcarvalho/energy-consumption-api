using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event
{
    public interface IEventService
    {
        object HandleEvent(EventDto eventData);
    }
}
