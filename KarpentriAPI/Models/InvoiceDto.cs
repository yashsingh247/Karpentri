namespace KarpentriAPI.Models
{
    public class InvoiceDto
    {
        public int invoiceId { get; set; }
        public double discount { get; set; }
        public double totalAmount { get; set; }

        public ICollection<CustomerDto> customers { get; set; } = new List<CustomerDto>();
        public ICollection<ServiceDto> services { get; set; } = new List<ServiceDto>();    
    }
}
