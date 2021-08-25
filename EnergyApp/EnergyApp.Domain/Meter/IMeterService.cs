namespace EnergyApp.Domain.Meter
{
    public interface IMeterService
    {
        decimal? GetConsumptionForMeter(string meter_number);
    }
}