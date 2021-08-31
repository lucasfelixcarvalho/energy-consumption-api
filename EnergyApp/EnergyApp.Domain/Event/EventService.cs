using EnergyApp.Domain.Billing.Dto;
using EnergyApp.Domain.Consumption;
using EnergyApp.Domain.Meter;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event
{
    public class EventService : IEventService
    {
        private readonly IMeterRepository _MeterRepository;

        public EventService(IMeterRepository meterRepository)
        {
            _MeterRepository = meterRepository;
        }

        public object HandleEvent(EventDto eventData)
        {
            if (string.IsNullOrEmpty(eventData.Type))
            {
                return null;
            }

            // TODO: factory
            if (eventData.Type == "import")
            {
                MeterDto meter = eventData.EventToMeter();
                _MeterRepository.InsertMeter(meter);
                return meter;
            }
            else if (eventData.Type == "push")
            {
                ConsumptionDto consumption = eventData.EventToConsumption();
                MeterDto meter = _MeterRepository.UpdateMeterConsumption(consumption);
                return meter;
            }
            else if (eventData.Type == "billing")
            {
                BillingDto billing = eventData.EventToBilling();
                MeterDto meter = _MeterRepository.UpdateBillingConsumption(billing);
                if (meter is null)
                {
                    return null;
                }
                
                BillingResponseDto billingResponse = new BillingResponseDto
                {
                    MeterNumber = meter.MeterNumber,
                    Cash = meter.Unit * 330
                };

                return billingResponse;
            }

            return null;
        }
    }
}
