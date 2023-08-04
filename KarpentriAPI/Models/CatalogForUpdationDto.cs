namespace KarpentriAPI.Models
{
    public class CatalogForUpdationDto
    {
        public string catalogDescription { get; set; }

        public ICollection<ServiceDto> catalogServices { get; set; } = new List<ServiceDto>();

    }
}
