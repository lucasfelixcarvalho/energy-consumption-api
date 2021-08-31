using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Meter
{
    public interface IMeterService
    {
        decimal? GetConsumptionForMeter(string meter_number);
        decimal? GetMicrogenerationForMeter(string meter_number);
        MeterDto UpdateMeterConsumption(ConsumptionDto consumption);
    }
}