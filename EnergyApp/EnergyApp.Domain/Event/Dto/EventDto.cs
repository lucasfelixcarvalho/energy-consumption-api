namespace EnergyApp.Domain.Event
{
    public class EventDto
    {
        public string Type { get; set; }
        public string MeterNumber { get; set; }
        public decimal Consumption { get; set; }
        public decimal Microgeneration { get; set; }
        public decimal ActiveEnergy { get; set; }
        public decimal InjectedEnergy { get; set; }
        public decimal Unit { get; set; }
    }
}
