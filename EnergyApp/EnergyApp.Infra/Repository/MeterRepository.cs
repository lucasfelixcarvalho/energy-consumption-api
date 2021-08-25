using System.Collections.Generic;
using System.Linq;
using EnergyApp.Domain.Meter;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Infra.Repository
{
    public class MeterRepository : IMeterRepository
    {
        private readonly List<MeterDto> _Meters;
        
        public MeterRepository()
        {
            _Meters = new List<MeterDto>();
        }

        public decimal? GetConsumptionForMeter(string meter_number)
        {
            MeterDto meter = _Meters.FirstOrDefault(m => m.MeterNumber == meter_number);
            return meter?.Consumption ?? null;
        }

        public void InsertMeter(MeterDto meter)
        {
            if (_Meters.Any(m => m.MeterNumber == meter.MeterNumber))
            {
                return;
            }

            _Meters.Add(meter);
        }
    }    
}
