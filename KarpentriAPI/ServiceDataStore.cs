using KarpentriAPI.Models;

namespace KarpentriAPI
{
    public class ServiceDataStore
    {
        public List<ServiceDto> ServiceList { get; set; }
        public static ServiceDataStore Current { get; } = new ServiceDataStore();
        public ServiceDataStore()
        {
            ServiceList = new List<ServiceDto>()
            {
                new ServiceDto()
                    {
                    Id = "SER0001",
                    Name = "Bed Support Repair",
                    Category = "CAT001",
                    Description = "Repairing Service",
                    Price = 399.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0002",
                    Name = "Bed Legs/Headboard Repair",
                    Category = "CAT001",
                    Description = "Repairing Service",
                    Price = 399.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0003",
                    Name = "Cupboard Hinge Service (1 pair)",
                    Category = "CAT002",
                    Description = "Repairing Service",
                    Price = 149.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0004",
                    Name = "Channel Repair/Replacement (1 pair)",
                    Category = "CAT002",
                    Description = "Repairing Service",
                    Price = 199.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0005",
                    Name = "Handle Installation/Replacement",
                    Category = "CAT002",
                    Description = "Repairing Service",
                    Price = 105.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0006",
                    Name = "Hinge Installation/Replacement (1 pair)",
                    Category = "CAT002",
                    Description = "Repairing Service",
                    Price = 199.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0007",
                    Name = "Window Hinge Installation (1 pair)",
                    Category = "CAT002",
                    Description = "Repairing Service",
                    Price = 149.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0008",
                    Name = "Major Door Repair",
                    Category = "CAT003",
                    Description = "Repairing Service",
                    Price = 249.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0009",
                    Name = "Hinge Installation (with door dismantling)",
                    Category = "CAT003",
                    Description = "Repairing Service",
                    Price = 299.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0010",
                    Name = "Mesh Grill Door Installation/Replacement (Jaali)",
                    Category = "CAT003",
                    Description = "Repairing Service",
                    Price = 399.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0011",
                    Name = "Overhead Door Closer Installation",
                    Category = "CAT003",
                    Description = "Repairing Service",
                    Price = 199.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0012",
                    Name = "Wall-mounted Door Closer Installation",
                    Category = "CAT003",
                    Description = "Repairing Service",
                    Price = 399.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0013",
                    Name = "Wooden Sliding Door Installation",
                    Category = "CAT003",
                    Description = "Repairing Service",
                    Price = 299.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0014",
                    Name = "Drill & Hang (Up to One Pair)",
                    Category = "CAT004",
                    Description = "Repairing Service",
                    Price = 105.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0015",
                    Name = "Curtain Rod Installation (Two Brackets)",
                    Category = "CAT004",
                    Description = "Repairing Service",
                    Price = 149.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0016",
                    Name = "Mirror Fittings Installation",
                    Category = "CAT004",
                    Description = "Repairing Service",
                    Price = 105.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0017",
                    Name = "Window AC Frame Installation",
                    Category = "CAT005",
                    Description = "Repairing Service",
                    Price = 105.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0018",
                    Name = "Bed Assembly",
                    Category = "CAT006",
                    Description = "Repairing Service",
                    Price = 299.00,
                    },

                    new ServiceDto()
                    {
                    Id = "SER0019",
                    Name = "Coffee Table Assembly",
                    Category = "CAT006",
                    Description = "Repairing Service",
                    Price = 199.00,
                    },


                    new ServiceDto()
                    {
                        Id = "SER0020",
                        Name = "STUDY TABLE ASSEMBLY",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 249.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0021",
                        Name = "DINING TABLE ASSEMBLY",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 299.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0022",
                        Name = "DINING CHAIR ASSEMBLY",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 149.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0023",
                        Name = "SHOE RACK/BOOK SHELF ASSEMBLY",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 299.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0024",
                        Name = "SHELVING UNIT/CABINET ASSEMBLY (3*7 FT)",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 399.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0025",
                        Name = "SHELVING UNIT/CABINET ASSEMBLY (4*8 FT)",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 499.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0026",
                        Name = "UNENSILS RACK ASSEMBLY",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 199.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0027",
                        Name = "BED DISMANTLES",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 299.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0028",
                        Name = "FURNITURE DISMANTLES",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 299.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0029",
                        Name = "PLASTIC BUFFER INSTALLATION (UP TO FOUR)",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 105.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0030",
                        Name = "TABLE/CHAIR WHEELS FITTING",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 105.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0031",
                        Name = "TV INSTALLATION (UP TO 52 INCHES)",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 399.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0032",
                        Name = "TV UNINSTALLATION (UP TO 32 INCHES)",
                        Category = "CAT006",
                        Description = "we are providing Repairing Service",
                        Price = 199.00
                    },

                    new ServiceDto()
                    {
                        Id = "SER0033",
                        Name = "Large Lock Installation/Replacement/Repair",
                        Category = "CAT007",
                        Description = "we are providing Repairing Service",
                        Price = 299.00,
                    },

                    new ServiceDto()
                    {
                        Id = "SER0034",
                        Name = "Medium Lock Installation/Replacement/Repair",
                        Category = "CAT007",
                        Description = "we are providing Repairing Service",
                        Price = 149.00,
                    },

                    new ServiceDto()
                    {
                        Id = "SER0035",
                        Name = "Large Lock Installation/Replacement/Repair",
                        Category = "CAT007",
                        Description = "we are providing Repairing Service",
                        Price = 105.00,
                    }


        };
        }
    }
}
