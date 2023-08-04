using KarpentriAPI.Models;

namespace KarpentriAPI
{
    public class InvoiceDataStore
    {
        public List<InvoiceDto> invoiceList { get; set; }
        public static InvoiceDataStore current { get; } = new InvoiceDataStore();
        public InvoiceDataStore()
        {
            invoiceList = new List<InvoiceDto>()
            {
                new InvoiceDto()
                {
                    invoiceId= 1,
                    discount = 50,
                    //totalAmount = 349,
                    customers = new List<CustomerDto>()
                    {
                        new CustomerDto()
                        {
                            customerId = 1,
                            customerName = "Pappu Kumar",
                            address= "787 Gali No-11 Village Kapashera 201301 Noida",
                            email= "dummy@example.com",
                            phone= "8130296867"
                        }
                    },

                    services = new List<ServiceDto>()
                    {
                        new ServiceDto()
                        {
                            serviceId = 1,
                            serviceName = "Bed Support Repair",
                            catalogId = "CAT001",
                            serviceDescription = "Repairing Service",
                            price = 399,
                        },

                        new ServiceDto()
                        {
                            serviceId = 2,
                            serviceName = "Bed Legs/Headboard Repair",
                            catalogId = "CAT001",
                            serviceDescription = "Repairing Service",
                            price = 399.00,
                        }
                    }
                },

               new InvoiceDto()
                {
                    invoiceId= 2,
                    discount = 50,
                    totalAmount = 349,
                    customers = new List<CustomerDto>()
                    {
                        new CustomerDto()
                        {
                            customerId = 2,
                            customerName= "Nitin Kumar",
                            address= "Hno A 69 Satyam Vihar Phase 2 Chandel Park Nangloi Najafgarh 201301 Noida",
                            email= "dummy@example.com",
                            phone= "9971932178"
                        }
                    },

                    services = new List<ServiceDto>()
                    {
                        new ServiceDto()
                        {
                            serviceId = 2,
                            serviceName = "Bed Legs/Headboard Repair",
                            catalogId = "CAT001",
                            serviceDescription = "Repairing Service",
                            price = 399.00,
                        }
                    }
                },

        };
        }
    }
}
