namespace EnergyApp.Domain.Meter.Dto
{
    public class MeterDto
    {
        public string MeterNumber { get; set; }
        public decimal Consumption { get; set; }
        public decimal Microgeneration { get; set; }        
    }    
}
