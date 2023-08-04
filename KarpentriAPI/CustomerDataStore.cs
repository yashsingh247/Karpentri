using KarpentriAPI.Models;
using System.Text.Json;

namespace KarpentriAPI
{
    public class CustomerDataStore
    {
        public List<CustomerDto> customersList { get; set; }

        public static CustomerDataStore current { get; } = new CustomerDataStore();

        public CustomerDataStore()
        {
            customersList = new List<CustomerDto>()
            {
                       new CustomerDto()
                       {
                           customerId = 1,
                           customerName = "Pappu Kumar",
                           address= "787 Gali No-11 Village Kapashera 201301 NocustomerIda",
                           email= "dummy@example.com",
                           phone= "8130296867"
                        },

                       new CustomerDto()
                        {
                            customerId= 2,
                            customerName= "Nitin Kumar",
                            address= "Hno A 69 Satyam Vihar Phase 2 Chandel Park Nangloi Najafgarh 201301 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "9971932178"
                        },

                       new CustomerDto()
                        {
                            customerId= 3,
                            customerName= "Manmohan Singh",
                            address= "H No- 4664 Sector- 23 A Near Columbia Asia Hospital 201301 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "8105966116"
                        },

                       new CustomerDto()
                        {
                            customerId= 4,
                            customerName= "Deep Sakre",
                            address= "1a Sector-25a NocustomerIda 201301 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "8804722759"
                        },

                       new CustomerDto()
                        {
                            customerId= 5,
                            customerName= "Neeraj Kumar",
                            address= "D -1/5 Room No -402 Top Floor Acharya Niketan Mayur Vihar Phase -1 201304 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "7080840388"
                        },

                       new CustomerDto()
                        {
                            customerId= 6,
                            customerName= "Kanwal Singh",
                            address= "47150 Block 2 Khichripur 201301 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "9535099500"
                        },

                       new CustomerDto()
                        {
                            customerId= 7,
                            customerName= "S Kannan",
                            address= "A-1 Udyog Marg Sec-1 NocustomerIda 201301 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "9903045542"
                        },

                       new CustomerDto()
                        {
                            customerId= 8,
                            customerName= "Rajeev Nirala",
                            address= "C 29 Sector 58 Noda 201301 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "9836510287"
                        },

                       new CustomerDto()
                        {
                            customerId= 9,
                            customerName= "Shivam Agarwal",
                            address= "Flat No-404 T-tower Amrapali Silicon City Sector-76 201301 NocustomerIda",
                            email= "dummy@example.com",
                            phone= "9899278287"
                        },

                       new CustomerDto()
                        {
                            customerId= 10,
                            customerName= "Pradeep Srivastav",
                            address= "Northern Railways Sinior Divisional Electric Eng Office Loco Shed 201001 Ghaziabad",
                            email= "dummy@example.com",
                            phone= "9910990868"
                        },

            };
        }

    }
}
