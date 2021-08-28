using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Event.Dto;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event
{
    public class EventDto : IEventData
    {
        public string Type { get; set; }
        public string MeterNumber { get; set; }
        public decimal Consumption { get; set; }
        public decimal Microgeneration { get; set; }
        public decimal ActiveEnergy { get; set; }
        public decimal InjectedEnergy { get; set; }
        public decimal Unit { get; set; }

        public ConsumptionDto EventToConsumption()
        {
            return new ConsumptionDto
            {
                ActiveEnergy = this.ActiveEnergy,
                InjectedEnergy = this.InjectedEnergy,
                MeterNumber = this.MeterNumber
            };
        }

        public MeterDto EventToMeter()
        {
            return new MeterDto
            {
                MeterNumber = this.MeterNumber,
                Consumption = this.Consumption,
                Microgeneration = this.Microgeneration
            };
        }
    }
}
