using KarpentriAPI.Models;
using System.Xml.Linq;

namespace KarpentriAPI
{
    public class CatalogDataStore
    {
        public List<CatalogDto> catalogList { get; set; }

        // public static CatalogDataStore current { get; } = new CatalogDataStore();

        public CatalogDataStore()
        {
            catalogList = new List<CatalogDto>()
            {
                new CatalogDto()
                {
                    catalogId = "CAT001",
                    catalogDescription = "Drill & Hang",
                    catalogServices = new List<ServiceDto>()
                    {
                        new ServiceDto()
                        {
                            serviceId = 1,
                            serviceName = "Bed Support Repair",
                            catalogId = "CAT001",
                            serviceDescription = "Repairing Service",
                            price = 399.00,
                        },

                        new ServiceDto()
                        {
                            serviceId = 2,
                            serviceName = "Bed Legs/Headboard Repair",
                            catalogId = "CAT001",
                            serviceDescription = "Repairing Service",
                            price = 399.00,
                        },

                    }
                },
                    new CatalogDto()
                    {
                        catalogId = "CAT002",
                        catalogDescription = "Bed",
                        catalogServices = new List<ServiceDto>()
                        {

                            new ServiceDto()
                            {
                                serviceId = 3,
                                serviceName = "Cupboard Hinge Service (1 pair)",
                                catalogId = "CAT002",
                                serviceDescription = "Repairing Service",
                                price = 149.00,
                            },

                            new ServiceDto()
                            {
                                serviceId = 4,
                                serviceName = "Channel Repair/Replacement (1 pair)",
                                catalogId = "CAT002",
                                serviceDescription = "Repairing Service",
                                price = 199.00,
                            },

                            new ServiceDto()
                            {
                                serviceId = 5,
                                serviceName = "Handle Installation/Replacement",
                                catalogId = "CAT002",
                                serviceDescription = "Repairing Service",
                                price = 105.00,
                            },

                            new ServiceDto()
                            {
                                serviceId = 6,
                                serviceName = "Hinge Installation/Replacement (1 pair)",
                                catalogId = "CAT002",
                                serviceDescription = "Repairing Service",
                                price = 199.00,
                            },

                            new ServiceDto()
                            {
                                serviceId = 7,
                                serviceName = "Window Hinge Installation (1 pair)",
                                catalogId = "CAT002",
                                serviceDescription = "Repairing Service",
                                price = 149.00,
                            },
                        }

                    }
                
                 
                    
                
            };
        }
    }
}
