using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilPol.Infrastructure.Commands.Garages;
using ProfilPol.Infrastructure.DTO;
using ProfilPol.Infrastructure.Services;

namespace ProfilPol.Api.Controllers
{
    [Route("[controller]")] // or i.e. [Route("garages")] itd.
    public class GaragesController: ApiControllerBase
    {
        private readonly IGarageService _garageService;
        public GaragesController(IGarageService garageService)
        {
            _garageService = garageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var garageList = await _garageService.getAllAsync();

            return Json(garageList);
        }

        [HttpGet("{garageId}")]
        public async Task<IActionResult> Get(Guid garageId)
        {
            var garage = await _garageService.getAsync(garageId);

            return Json(garage);
        }

        [HttpGet("GetGarageOfferDetails")]
        public async Task<IActionResult> GetGarageOfferDetails()
        {
            var garageList = await _garageService.getAllAsync();

            var garageListOfferDetails = garageList.Select(garage => 
                    new OfferDetailsDto(
                        garage.Id,
                        garage.OfferDetails.ImagePath,
                        garage.OfferDetails.Name,
                        garage.OfferDetails.Available,
                        garage.OfferDetails.DeliveryTime,
                        garage.OfferDetails.Description,
                        garage.OfferDetails.BadgeContent,
                        garage.OfferDetails.Sizes,
                        garage.OfferDetails.Price
                    )
            ).ToList();

            return Json(garageListOfferDetails);
        }

        [HttpGet("GetItemDetails/{garageId}")]
        public async Task<IActionResult> GetItemDetails(Guid garageId)
        {
            var garage = await _garageService.getAsync(garageId);

            var garageItemDetails = new GarageItemDetailsDto(
                garage.Id,
                garage.OfferDetails.Name,
                garage.OfferDetails.ImagePath,
                garage.OfferDetails.Price,
                garage.OfferDetails.Available,
                garage.OfferDetails.DeliveryTime,
                garage.SheetColor,
                garage.SheetType,
                garage.OfferDetails.Sizes
                );

            var json = Json(garageItemDetails);

            return json;
        }

        [HttpPost]
        [Authorize(Policy = "HasAdminRole")]
        public async Task<IActionResult> Post([FromBody]CreateGarage command)
        {
            command.GarageId = Guid.NewGuid();
            await _garageService.CreateAsync(command.GarageId, command.offerDetails);

            // HTTP 201 code
            return Created($"garages/{command.GarageId}", null);
        }

        [HttpPut("{garageId}")]
        [Authorize(Policy = "HasAdminRole")]
        public async Task<IActionResult> Put(Guid garageId, [FromBody]UpdateGarage command)
        {
            await _garageService.UpdateAsync(garageId, command.XLength, command.YLength, command.ZLength);

            // HTTP 204 code
            return NoContent();
        }

        [HttpDelete("{garageId}")]
        [Authorize(Policy = "HasAdminRole")]
        public async Task<IActionResult> Delete(Guid garageId)
        {
            await _garageService.DeleteAsync(garageId);

            // HTTP 204 code
            return NoContent();
        }
    }
}