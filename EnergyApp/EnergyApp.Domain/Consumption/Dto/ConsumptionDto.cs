using EnergyApp.Domain.Event.Dto;

namespace EnergyApp.Domain.Consumption
{
    public class ConsumptionDto
    {
        public string MeterNumber { get; set; }
        public decimal ActiveEnergy { get; set; }
        public decimal InjectedEnergy { get; set; }
    }
}
