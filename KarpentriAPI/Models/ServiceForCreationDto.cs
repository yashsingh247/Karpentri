using System.Text.Json.Serialization;

namespace KarpentriAPI.Models
{
    public class ServiceForCreationDto
    {
        public string serviceName { get; set; }
        public string catalogId { get; set; }
        public string serviceDescription { get; set; }
        public double price { get; set; }
    }
}
