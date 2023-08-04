namespace KarpentriAPI.Models
{
    public class InvoiceForCreationDto
    {
        public double discount { get; set; }
        public double totalAmount { get; set; }

        public ICollection<CustomerDto> customers { get; set; } = new List<CustomerDto>();
        public ICollection<ServiceDto> services { get; set; } = new List<ServiceDto>();
    }
}
