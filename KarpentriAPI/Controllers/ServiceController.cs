using KarpentriAPI.Models;
using KarpentriAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KarpentriAPI.Controllers
{
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        // private readonly LocalMailService _mailService;

        private readonly IMailService _mailService;
        private readonly CatalogDataStore _catalogDataStore;

        public ServiceController(ILogger<ServiceController> logger, IMailService mailService, CatalogDataStore catalogDataStore)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentException(nameof(logger));
            this._catalogDataStore = catalogDataStore ?? throw new ArgumentNullException(nameof(catalogDataStore));
        }


        [HttpGet("api/GetAllServicesById/{catalogId}")]
        public IActionResult GetAllServicesByCatalog(string catalogId)
        {
            int count = 0;
            List<ServiceDto> output = new List<ServiceDto>();
            foreach (var i in _catalogDataStore.catalogList)
            {
                foreach (var j in i.catalogServices)
                {
                    if (i.catalogId == catalogId)
                    {
                        output.Add(j);
                        count++;
                    }
                }

            }
            if (count == 0)
            {
                return NotFound();
            }
            return Ok(output);
        }
        [HttpGet("api/GetCatalogDetailsofService/{serviceId}")]
        public IActionResult GetCatalogDetails(int serviceId)
        {
            List<CatalogDto> output = new List<CatalogDto>();
            foreach (var i in _catalogDataStore.catalogList)
            {
                foreach (var j in i.catalogServices)
                {
                    if (j.serviceId == serviceId)
                    {
                        output.Add(i);
                    }
                }

            }
            if (output.Count == 0)
            {
                return NotFound();
            }
            return Ok(output);
        }

        //[HttpGet("api/MostExpensiveService")]
        //public ActionResult<CatalogDto> MostExpensiveService()
        //{
        //    double value = 0;
        //    ServiceDto service = null;

        //    foreach (var i in CatalogDataStore.CatalogList)
        //    {
        //        foreach (var j in i.CatalogServices)
        //        {
        //            if (j.Price > value)
        //            {
        //                value = j.Price;
        //                service = j;
        //            }
        //        }
        //    }

        //    if (service == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(service);
        //    }

        //}

        //[HttpGet("api/TotalServices")]
        //public ActionResult<CatalogDto> TotalServices()
        //{
        //    int totalservices = 0;

        //    foreach (var i in CatalogDataStore.CatalogList)
        //    {
        //        foreach (var j in i.CatalogServices)
        //        {
        //            if (j.Price > 0)
        //            {
        //                totalservices++;
        //            }
        //        }
        //    }
        //    return Ok($"Total services in catalog are {totalservices}");
        //}



        [HttpGet("api/GetService/{catalogId}/{serviceId}", Name = "GetService")]
        public ActionResult<ServiceDto> GetService(string catalogId, int serviceId)
        {
            try
            {
                var catalog = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);

                if (catalog == null)
                {
                    return NotFound();
                }

                var service = catalog.catalogServices.FirstOrDefault(c => c.serviceId == serviceId);

                if (service == null)
                {
                    _logger.LogInformation($"Karpentri: Service with Id = {serviceId} was not found");
                    return NotFound();
                }
                return Ok(service);
            }

            catch (Exception ex)
            {
                _logger.LogCritical($"Service with Id = {serviceId} was not found", ex);
                return StatusCode(500, "Internal Server error");
            }
        }



        [HttpPost("api/AddService/{catalogId}/serviceId")]
        public ActionResult<ServiceDto> CreateService([FromHeader] string catalogId, [FromBody] ServiceForCreationDto newService)
        {
            var catalog = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);
            if (catalog == null)
            {
                return NotFound();
            }

            var maxServiceId = _catalogDataStore.catalogList.SelectMany(c => c.catalogServices).Max(p => p.serviceId);


            var serviceToBeAdded = new ServiceDto()
            {

                serviceId = ++maxServiceId,
                serviceName = newService.serviceName,
                catalogId = catalogId,
                serviceDescription = newService.serviceDescription,
                price = newService.price,
            };

            catalog.catalogServices.Add(serviceToBeAdded);

            return CreatedAtRoute("GetService",
                new
                {
                    CatalogId = catalogId,
                    ServiceId = serviceToBeAdded.serviceId,
                }, serviceToBeAdded);


        }

        [HttpPut("api/Catalogs/{catalogId}/{serviceId}")]
        public ActionResult UpdateService(string catalogId, int serviceId, [FromBody] ServiceForUpdationDto updateService)
        {
            var catalog = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);
            if (catalog == null) { return NotFound(); }

            var serviceToBeUpdated = catalog.catalogServices.FirstOrDefault(s => s.serviceId == serviceId);
            if (serviceToBeUpdated == null) { return NotFound(); }

            serviceToBeUpdated.serviceName = updateService.serviceName;
            serviceToBeUpdated.catalogId = catalogId;
            serviceToBeUpdated.serviceDescription = updateService.serviceDescription;
            serviceToBeUpdated.price = updateService.price;

            return NoContent();
        }

        [HttpPatch("api/UpdateService/{catalogId}/{serviceId}")]
        public ActionResult PatchService(string catalogId, int serviceId, [FromBody] JsonPatchDocument<ServiceForUpdationDto> patchDocument)
        {

            var catalog = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);
            if (catalog == null) { return NotFound(); }

            var serviceFromStore = catalog.catalogServices.FirstOrDefault(s => s.serviceId == serviceId);
            if (serviceFromStore == null) { return NotFound(); }

            var serviceToPatch = new ServiceForUpdationDto()
            {
                serviceName = serviceFromStore.serviceName,
                catalogId = catalogId,
                serviceDescription = serviceFromStore.serviceDescription,
                price = serviceFromStore.price
            };

            patchDocument.ApplyTo(serviceToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            serviceFromStore.serviceName = serviceToPatch.serviceName;
            serviceFromStore.catalogId = catalogId;
            serviceFromStore.serviceDescription = serviceToPatch.serviceDescription;
            serviceFromStore.price = serviceToPatch.price;

            return NoContent();
        }

        [HttpDelete("api/DeleteService/{catalogId}/{serviceId}")]
        public IActionResult DeleteCustomer(string catalogId, int serviceId)
        {
            var catalog = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);

            if (catalog == null)
            {
                return NotFound();
            }

            var serviceToDelete = catalog.catalogServices.FirstOrDefault(c => c.serviceId == serviceId);
            if (serviceToDelete == null)
            {
                return NotFound();
            }

            if (serviceToDelete != null)
            {
                catalog.catalogServices.Remove(serviceToDelete);
                _mailService.Send("Service deleted.", $"Service with name {serviceToDelete.serviceName} was deleted ");
                return NoContent();
            }
            return NoContent();
        }
       
    }
}
