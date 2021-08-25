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
    }    
}
