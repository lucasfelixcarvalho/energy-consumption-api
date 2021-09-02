using EnergyApp.Domain.Billing.Dto;
using EnergyApp.Domain.Meter;
using EnergyApp.Domain.Meter.Dto;

namespace EnergyApp.Domain.Event.Handlers
{
    public class BillingHandler : IEventHandler
    {
        private readonly IMeterRepository _MeterRepository;
        private decimal kWhTax => 330;

        public string EventType { get => "Billing"; }
        
        public BillingHandler(IMeterRepository meterRepository)
        {
            _MeterRepository = meterRepository;            
        }

        public object HandleEvent(EventDto eventData)
        {
            BillingDto billing = EventToBilling(eventData);
            MeterDto meter = _MeterRepository.UpdateBillingConsumption(billing);
            if (meter is null)
            {
                return null;
            }
            
            BillingResponseDto billingResponse = new BillingResponseDto
            {
                MeterNumber = meter.MeterNumber,
                Cash = meter.Unit * kWhTax
            };

            return billingResponse;
        }

        private BillingDto EventToBilling(EventDto eventData)
        {
            return new BillingDto
            {
                MeterNumber = eventData.MeterNumber,
                Unit = eventData.Unit
            };
        }
    }
}