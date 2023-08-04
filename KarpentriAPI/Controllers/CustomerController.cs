using KarpentriAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        