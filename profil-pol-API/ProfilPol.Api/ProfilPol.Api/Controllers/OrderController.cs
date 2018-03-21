using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfilPol.Infrastructure.Commands.Garages;
using ProfilPol.Infrastructure.Commands.Orders;
using ProfilPol.Infrastructure.DTO;
using ProfilPol.Infrastructure.Services;

namespace ProfilPol.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(Guid orderId)
        {
            var order = await _orderService.GetAsync(orderId);

            return Json(order);
        }

        [HttpPost("GetOrdersInfo"), AllowAnonymous]
        public async Task<IActionResult> GetOrdersInfo([FromBody]GetOrdersInfo command)
        {
            var orders = await _orderService.BrowseAsync(command.UserId);

            return Json(orders);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]CreateOrder command)
        {
            var orderDto = await _orderService.CreateAsync(
                command.GarageId,
                DateTime.UtcNow,
                command.UserEmail,
                command.UserName,
                command.UserSurname,
                command.Password,
                command.Adress,
                command.City,
                command.Location
                );

            // HTTP 201 code
            return Created($"order/{orderDto.Id}", null);
        }

        [HttpPut("{garageId}")]
        public async Task<IActionResult> Put(Guid garageId, [FromBody]UpdateGarage command)
        {
            //await _garageService.UpdateAsync(garageId, command.XLength, command.YLength, command.ZLength);
            throw new NotImplementedException();
            // HTTP 204 code
            return NoContent();
        }

        [HttpDelete("{garageId}")]
        public async Task<IActionResult> Delete(Guid garageId)
        {
            throw new NotImplementedException(); 

            // await _garageService.DeleteAsync(garageId);

            // HTTP 204 code
            return NoContent();
        }
    }
}