using EnergyApp.Domain.Event.Handlers;
using EnergyApp.Domain.Meter;

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

            IEventHandler handler = new HandlerFactory(_MeterRepository).GetHandler(eventData.Type);
            if (handler is not null)
            {
                return handler.HandleEvent(eventData);
            }

            return null;
        }
    }
}
