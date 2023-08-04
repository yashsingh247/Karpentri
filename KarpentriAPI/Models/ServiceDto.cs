namespace KarpentriAPI.Models
{
    public class ServiceDto
    {
        public int serviceId { get; set; }
        public string serviceName { get; set; }
        public string catalogId{ get; set; }
        public string serviceDescription { get; set; }
        public double price { get; set; }
    }
}
