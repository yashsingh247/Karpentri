namespace KarpentriAPI.Models
{
    public class CatalogForCreationDto
    {
        public string catalogDescription { get; set; }

        public ICollection<ServiceDto> catalogServices { get; set; } = new List<ServiceDto>();

    }
}
