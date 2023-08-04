using KarpentriAPI.Models;

namespace KarpentriAPI
{
    public class UsersDataStore
    {
        public List<UsersDto> UsersList { get; set; }
        public static UsersDataStore Current { get; } = new UsersDataStore();
        public UsersDataStore()
        {
            UsersList = new List<UsersDto>()
            {
                    new UsersDto()
                    {
                        Id = "USR-00001",
                        Name = "Neeraj Arora",
                        Address = "16438 Satsang Wlai Gali Shani Mohlla West Rohtash Nagar Delhi 201301 Noida",
                        Email = "dummy@example.com",
                        Phone = "9811777060",
                        Type = "Individual"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00002",
                        Name = "Kanchan Kanchan",
                        Address = "A-8 Sec-16 Noida 201307 Greater Noida",
                        Email = "dummy@example.com",
                        Phone = "9599182955",
                        Type = "Individual"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00003",
                        Name = "Mahendra Rana",
                        Address = "Falt No 202 1st Floo Wz 10 A Ext Dk Marg Mohan Garden Uttam Nagar 201301 Noida",
                        Email = "dummy@example.com",
                        Phone = "9910622105",
                        Type = "Individual"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00004",
                        Name = "Ankit Aggarwal",
                        Address = "Dabur India Ltd Plot No-22 Site-4 Sahibabad 201010 Ghaziabad",
                        Email = "dummy@example.com",
                        Phone = "9991005165",
                        Type = "Individual"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00005",
                        Name = "Vijay Mathur",
                        Address = "A-16 Sector-60 Noida 201301 Noida",
                        Email = "dummy@example.com",
                        Phone = "9650030128",
                        Type = "Individual"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00006",
                        Name = "Harvinder Kaur",
                        Address = "Flat No 641 Neelkanth Apartment Sec 13 Rohini 201301 Noida",
                        Email = "dummy@example.com",
                        Phone = "9811480790",
                        Type = "Enterprise"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00007",
                        Name = "Sanchita Gupta",
                        Address = "B 60 B Block Ganesh Nagar Pandav Nagar Complex Delhi 201301 Noida",
                        Email = "dummy@example.com",
                        Phone = "8745078321",
                        Type = "Enterprise"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00008",
                        Name = "Suman Kumar",
                        Address = "D-383 Omicron-3 Greater Noida 201308 Greater Noida",
                        Email = "dummy@example.com",
                        Phone = "9540302381",
                        Type = "Enterprise"
                    },
                    new UsersDto()
                    {
                        Id = "USR-00009",
                        Name = "Sumeet Garg",
                        Address = "Plot No 188 Sf-1 Shalimar Garden Extn 1 201301 Noida",
                        Email = "dummy@example.com",
                        Phone = "7838833719",
                        Type = "Enterprise"
                    },
    
        };
        }
    }
}
