using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Meter
{
    public class MeterService : IMeterService
    {
        private readonly IMeterRepository _MeterRepository;

        public MeterService(IMeterRepository meterRepository)
        {
            _MeterRepository = meterRepository;
        }

        public decimal? GetConsumptionForMeter(string meter_number)
        {
            return _MeterRepository.GetConsumptionForMeter(meter_number);
        }

        public MeterDto UpdateMeterConsumption(ConsumptionDto consumption)
        {
            return _MeterRepository.UpdateMeterConsumption(consumption);
        }
    }    
}
