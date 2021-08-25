using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Meter
{
    public interface IMeterRepository
    {
        void InsertMeter(MeterDto meter);
        decimal? GetConsumptionForMeter(string meter_number);
    }
}
