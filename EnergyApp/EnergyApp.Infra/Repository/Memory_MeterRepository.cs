using System.Collections.Generic;
using System.Linq;
using EnergyApp.Domain.Billing.Dto;
using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Infra.Repository
{
    public class Memory_MeterRepository : IMeterRepository
    {
        private readonly List<MeterDto> _Meters;
        
        public Memory_MeterRepository()
        {
            _Meters = new List<MeterDto>();
        }

        public decimal? GetConsumptionForMeter(string meter_number)
        {
            MeterDto meter = _Meters.FirstOrDefault(m => m.MeterNumber == meter_number);
            return meter?.Consumption ?? null;
        }

        public decimal? GetMicrogenerationForMeter(string meter_number)
        {
            MeterDto meter = _Meters.FirstOrDefault(m => m.MeterNumber == meter_number);
            return meter?.Microgeneration ?? null;
        }

        public void InsertMeter(MeterDto meter)
        {
            if (_Meters.Any(m => m.MeterNumber == meter.MeterNumber))
            {
                return;
            }

            _Meters.Add(meter);
        }

        public MeterDto UpdateBillingConsumption(BillingDto billing)
        {
            if (!_Meters.Any(m => m.MeterNumber == billing.MeterNumber))
            {
                return null;
            }

            int meterIndex = _Meters.FindIndex(0, _Meters.Count, m => m.MeterNumber == billing.MeterNumber);
            _Meters[meterIndex].Unit = billing.Unit;            
            return _Meters[meterIndex];
        }

        public MeterDto UpdateMeterConsumption(ConsumptionDto consumption)
        {
            if (!_Meters.Any(m => m.MeterNumber == consumption.MeterNumber))
            {
                return null;
            }

            int meterIndex = _Meters.FindIndex(0, _Meters.Count, m => m.MeterNumber == consumption.MeterNumber);
            _Meters[meterIndex].Consumption += consumption.ActiveEnergy;
            _Meters[meterIndex].Microgeneration += consumption.InjectedEnergy;
            return _Meters[meterIndex];
        }
    }    
}
