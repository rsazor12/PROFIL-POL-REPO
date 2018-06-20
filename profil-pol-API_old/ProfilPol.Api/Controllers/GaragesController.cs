using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfilPol.Infrastructure.Commands.Garages;
using ProfilPol.Infrastructure.Services;

namespace ProfilPol.Api.Controllers
{
    [Route("[controller]")] // or i.e. [Route("garages")] itd.
    public class GaragesController : Controller
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

        [HttpGet]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var garage = await _garageService.getAsync(Guid.Parse("00000000000000000000000000000001"));

        //    return Json(garage);
        //}

        [HttpGet("{garageId}")]
        public async Task<IActionResult> Get(Guid garageId)
        {
            var garage = await _garageService.getAsync(garageId);

            return Json(garage);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateGarage command)
        {
            command.GarageId = Guid.NewGuid();
            await _garageService.CreateAsync(command.GarageId, command.IsCustom, command.Type, command.SheetColor,
                                                command.SheetType, command.Windows, command.Doors, command.Roofs, command.XLength, command.YLength, command.ZLength);

            // HTTP 201 code
            return Created($"garages/{command.GarageId}", null);
        }

        [HttpPut("{garageId}")]
        public async Task<IActionResult> Put(Guid garageId, [FromBody]UpdateGarage command)
        {
            await _garageService.UpdateAsync(garageId, command.XLength, command.YLength, command.ZLength);

            // HTTP 204 code
            return NoContent();
        }

        [HttpDelete("{garageId}")]
        public async Task<IActionResult> Delete(Guid garageId)
        {
            await _garageService.DeleteAsync(garageId);

            // HTTP 204 code
            return NoContent();
        }
    }
}