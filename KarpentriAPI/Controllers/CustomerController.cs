using KarpentriAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace KarpentriAPI.Controllers
{
    public class CustomerController : ControllerBase
    {
        /* customer by customerId */
        [HttpGet("api/Customers/{customerId}")]
        public IActionResult customerById(int customerId)
        {
            return Ok(CustomerDataStore.current.customersList.FirstOrDefault(x => x.customerId == customerId));
        }
        /*First, verify if a CustomerDto that needs to be added exist already by checking customer id. Then if it exists, it will return a "customer already exist" message. Now, if it doesn't exist already then it will check the largest customer id that is present and add 1 in into it to assign to new customer and it will allow us to add other details of customer likeCustomerName, address etc. and new customer will be added. At last, it will return the new custome*/
        [HttpPost("api/Customers")]
        public IActionResult addCustomer(CustomerDto customer)
        {
            if (CustomerDataStore.current.customersList.FirstOrDefault(x => x.customerId == customer.customerId) != null)
            {
                return BadRequest("Customer already exist");
            }
            else
            {
                customer.customerId = CustomerDataStore.current.customersList.Max(x => x.customerId) + 1;
                CustomerDataStore.current.customersList.Add(customer);
                return Ok(customer);
            }
        }
        /* First, verify if a CustomerDto that needs to be added exist already by checking customer id. Then if it not exists, it will return a "customer Not exist” message. Now, remove Customer from CustomerDto by their customer Id  */

        [HttpDelete("api/Customers/{customerId}")]
        public ActionResult deleteCustomer(int customerId)
        {
            if (CustomerDataStore.current.customersList.Any(x => x.customerId == customerId))
            {
                CustomerDataStore.current.customersList.Remove(CustomerDataStore.current.customersList.FirstOrDefault(x => x.customerId == customerId));
                return Ok();
            }
            else
            {
                return BadRequest("Customer Not exist");
            }
        }
        /*First, verify if a CustomerDto that needs to be updated exist already by checking customer id.Then if it not exists, it will return a "customer not exist",
        Now Update Customer to be updated by Customer Id using update function , it will return updated customer*/
        [HttpPatch("api/Customers/{customerId}")]
        public IActionResult updateCustomer(int customerld, [FromBody] JsonPatchDocument<CustomerDto> patchDoc)
        {
            if (CustomerDataStore.current.customersList.Any(x => x.customerId == customerld))
            {
                var customer = CustomerDataStore.current.customersList.FirstOrDefault(x => x.customerId == customerld);

                patchDoc.ApplyTo(customer);
                return Ok(customer);
            }

            return BadRequest("Customer not exist");
        }
        /* all customer*/
        [HttpGet("api/Custome")]

        public IActionResult allCustomer()
        {
            var Data = CustomerDataStore.current.customersList;
            return Ok(Data);

        }
    }
}