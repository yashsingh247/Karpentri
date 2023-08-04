using System.ComponentModel.DataAnnotations;

namespace KarpentriAPI.Models
{
    public class ServiceForUpdationDto
    {
        [Required]
        public string serviceName { get; set; }
        public string catalogId { get; set; }
        public string serviceDescription { get; set; }
        public double price { get; set; } 
    }
}
