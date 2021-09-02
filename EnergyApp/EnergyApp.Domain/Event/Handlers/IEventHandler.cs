namespace EnergyApp.Domain.Event.Handlers
{
    public interface IEventHandler
    {
        object HandleEvent(EventDto eventData);

        public string EventType { get; }
    }
}
