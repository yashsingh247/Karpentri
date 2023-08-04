namespace KarpentriAPI.Models
{
    public class CatalogDto
    {
        public string catalogId { get; set; }
        public string catalogDescription { get; set; }
        // public string Description { get; set; }

        public ICollection<ServiceDto> catalogServices { get; set; } = new List<ServiceDto>();
    }
}
