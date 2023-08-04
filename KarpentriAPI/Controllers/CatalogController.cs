using KarpentriAPI.Models;
using KarpentriAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KarpentriAPI.Controllers
{
    public class CatalogController:ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly CatalogDataStore _catalogDataStore;

        public CatalogController(IMailService mailService, CatalogDataStore catalogDataStore)
        {
            this._mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            this._catalogDataStore = catalogDataStore ?? throw new ArgumentNullException(nameof(catalogDataStore));
        }
        //Dhawaj

        [HttpGet("api/GetCatalogs")]
        public ActionResult<IEnumerable<CatalogDto>> GetCatalogList()
        {
            return Ok(_catalogDataStore.catalogList);
        }
        //public JsonResult catalog()
        //{
        //    return new JsonResult(CatalogDataStore.CatalogList);
        //}
        

        [HttpGet("api/GetCatalogById/{catalogId}", Name = "Get Catalog")]
        public ActionResult<CatalogDto> GetCatalog(string catalogId)
        {
            var catalog = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);
            if (catalog == null)
            {
                return NotFound();
            }
            _mailService.Send("Test from catalog controller ", "body from controller");
            return Ok(catalog);
        }

        [HttpPost("api/AddCatalog/{catalogId}")]
        public IActionResult AddCatalog(string catalogId,  [FromBody] CatalogForCreationDto newCatalog) 
        {
            var catalog = _catalogDataStore.catalogList.FirstOrDefault(i => i.catalogId == catalogId);

            if (catalog != null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "catalog already exist" });
            }

           // var maxIId = InvoiceDataStore.invoiceList.Max(i => i.invoiceId);

            var catalogToBeAdded = new CatalogDto()
            {
                catalogId = catalogId,
                catalogDescription = newCatalog.catalogDescription,
                catalogServices = newCatalog.catalogServices.Select(s => new ServiceDto
                {
                    serviceId = s.serviceId,
                    serviceName = s.serviceName,
                    catalogId = catalogId,
                    serviceDescription = s.serviceDescription,
                    price = s.price
                }).ToList()
            };

            _catalogDataStore.catalogList.Add(catalogToBeAdded);

            return CreatedAtRoute("Get Catalog",
                new
                {
                    catalogId = catalogToBeAdded.catalogId
                }, catalogToBeAdded);
        }

        [HttpPatch("api/UpdateCatalog/{catalogId}/{serviceId}")]
        public ActionResult PatchService(string catalogId, int serviceId, [FromBody] JsonPatchDocument<CatalogForUpdationDto> patchDocument)
        {

            var catalog = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);
            if (catalog == null) { return NotFound(); }

            var serviceFromStore = catalog.catalogServices.FirstOrDefault(s => s.serviceId == serviceId);
            if (serviceFromStore == null) { return NotFound(); }

            var catalogToPatch = new CatalogForUpdationDto()
            {
                catalogDescription = catalog.catalogDescription,
                //catalogServices = catalog.catalogServices.Select(s => new ServiceDto
                //{
                //    serviceId = serviceFromStore.serviceId,
                //    serviceName = serviceFromStore.serviceName,
                //    catalogId = catalog.catalogId,
                //    serviceDescription = serviceFromStore.serviceDescription,
                //    price = s.price
                //}).ToList()
            };

            patchDocument.ApplyTo(catalogToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            catalog.catalogDescription = catalogToPatch.catalogDescription;

            //serviceFromStore.serviceName = patchDocument.serviceName;
            //serviceFromStore.catalogId = catalogId;
            //serviceFromStore.serviceDescription = catalogToPatch.serviceDescription;
            //serviceFromStore.price = catalogToPatch.price;

            return NoContent();
        }

        //[HttpPatch("api/UpdateCatalog/{catalogId}/{serviceId}")]
        //public ActionResult PatchService(string catalogId, int serviceId, [FromBody] JsonPatchDocument<CatalogForUpdationDto> patchDocument)
        //{
        //    var catalog = CatalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);
        //    if (catalog == null) { return NotFound(); }

        //    var serviceToUpdate = catalog.catalogServices.FirstOrDefault(s => s.serviceId == serviceId);
        //    if (serviceToUpdate == null) { return NotFound(); }

        //    var serviceForUpdateDto = new ServiceDto
        //    {
        //        serviceId = serviceToUpdate.serviceId,
        //        serviceName = serviceToUpdate.serviceName,
        //        catalogId = serviceToUpdate.catalogId,
        //        serviceDescription = serviceToUpdate.serviceDescription,
        //        price = serviceToUpdate.price
        //    };

        //    var catalogToUpdateDto = new CatalogForUpdationDto
        //    {
        //        catalogDescription = catalog.catalogDescription,
        //        catalogServices = new List<ServiceDto> { serviceForUpdateDto }
        //    };

        //    patchDocument.ApplyTo(catalogToUpdateDto, ModelState);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    serviceToUpdate.serviceName = serviceForUpdateDto.serviceName;
        //    serviceToUpdate.serviceDescription = serviceForUpdateDto.serviceDescription;
        //    serviceToUpdate.price = serviceForUpdateDto.price;

        //    return NoContent();
        //}



        [HttpDelete("api/DeleteCatalog/{catalogId}")]
        public IActionResult DeleteCatalog(string catalogId)
        {
            var catalogToDelete = _catalogDataStore.catalogList.FirstOrDefault(c => c.catalogId == catalogId);
            if (catalogToDelete != null)
            {
                _catalogDataStore.catalogList.Remove(catalogToDelete);
            }
            return NoContent();
        }

    }
}
