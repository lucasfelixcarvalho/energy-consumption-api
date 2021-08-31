using EnergyApp.Domain.Billing.Dto;
using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Meter
{
    public interface IMeterRepository
    {
        void InsertMeter(MeterDto meter);
        decimal? GetConsumptionForMeter(string meter_number);
        decimal? GetMicrogenerationForMeter(string meter_number);
        MeterDto UpdateMeterConsumption(ConsumptionDto consumption);
        MeterDto UpdateBillingConsumption(BillingDto billing);
    }
}
