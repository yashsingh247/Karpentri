using KarpentriAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KarpentriAPI.Controllers
{
    [ApiController]

    public class InvoiceController : ControllerBase
    {
        [HttpGet("api/GetAllInvoices")]
        public IActionResult GetAllInvoices()
        {
            return Ok(InvoiceDataStore.current.invoiceList);
        }

        [HttpGet("api/GetInvoiceById/{id}", Name = "Get Invoice")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = InvoiceDataStore.current.invoiceList.FirstOrDefault(i => i.invoiceId == id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPost("api/AddInvoice/{id}")]
        public IActionResult AddInvoice(int id, [FromBody] InvoiceForCreationDto newInvoice)
        {
            var invoice = InvoiceDataStore.current.invoiceList.FirstOrDefault(i => i.invoiceId == id);

            if (invoice != null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "invoice already exist" });
            }

            var maxInvoiceId = InvoiceDataStore.current.invoiceList.Max(i => i.invoiceId);

            var invoiceToBeAdded = new InvoiceDto()
            {
                invoiceId = ++maxInvoiceId,
                discount = newInvoice.discount,
                totalAmount = newInvoice.totalAmount,
                customers = newInvoice.customers.Select(c => new CustomerDto
                {
                    customerId = c.customerId,
                    customerName = c.customerName,
                    address = c.address,
                    email = c.email,
                    phone = c.phone
                }).ToList(),
                services = newInvoice.services.Select(s => new ServiceDto
                {
                    serviceId = s.serviceId,
                    serviceName = s.serviceName,
                    catalogId = s.catalogId,
                    serviceDescription = s.serviceDescription,
                    price = s.price
                }).ToList()
            };

            InvoiceDataStore.current.invoiceList.Add(invoiceToBeAdded);

            return CreatedAtRoute("Get Invoice",
                new
                {
                    id = invoiceToBeAdded.invoiceId
                }, invoiceToBeAdded);
        }

        [HttpPatch("api/UpdateInvoice/{invoiceId}")]
        public IActionResult PatchCustomer(int invoiceId, [FromBody] JsonPatchDocument<InvoiceForUpdationDto> patchDocument)
        {
            var invoice = InvoiceDataStore.current.invoiceList.FirstOrDefault(i => i.invoiceId == invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }

            var invoiceToPatch = new InvoiceForUpdationDto()
            {
                discount = invoice.discount,
                totalAmount = invoice.totalAmount
            };

            patchDocument.ApplyTo(invoiceToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            invoice.discount = invoiceToPatch.discount;
            invoice.totalAmount = invoiceToPatch.totalAmount;

            return NoContent();
        }

        [HttpDelete("api/DeleteInvoice/{invoiceId}")]
        public IActionResult DeleteCustomer(int invoiceId)
        {
            var invoiceToDelete = InvoiceDataStore.current.invoiceList.FirstOrDefault(c => c.invoiceId == invoiceId);
            if (invoiceToDelete != null)
            {
                InvoiceDataStore.current.invoiceList.Remove(invoiceToDelete);
            }
            return NoContent();
        }
       
    }
}
