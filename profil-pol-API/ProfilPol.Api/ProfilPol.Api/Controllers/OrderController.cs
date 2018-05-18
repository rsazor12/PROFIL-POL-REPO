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

        // create order
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]CreateOrder command)
        {
            var orderDto = await _orderService.CreateAsync(
                command.GarageId,
                DateTime.UtcNow,
                command.SheetColor,
                command.XLength,
                command.YLength,
                command.ZLength,
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

        // create orders
        [HttpPost("CreateOrders"), AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]List<CreateOrder> ordersToCreate)
        {

            ordersToCreate.ForEach(async order => 
                await _orderService.CreateAsync(
                order.GarageId,
                DateTime.UtcNow,
                order.SheetColor,
                order.XLength,
                order.YLength,
                order.ZLength,
                order.UserEmail,
                order.UserName,
                order.UserSurname,
                order.Password,
                order.Adress,
                order.City,
                order.Location
                ));


            // HTTP 201 code
            // return Created($"order/{orderDto.Id}", null);
            // TODO code here

            return Ok();
        }



        // update specify orders
        [HttpPost("UpdateOrders"), AllowAnonymous]
        //public async Task<IActionResult> Delete([FromBody]RemoveOrders command)
        public async Task<IActionResult> UpdateOrders([FromBody]List<UpdateOrderDto> orders)
        {


            await _orderService.UpdateAsync(orders);

            return Ok();
        }

        // delete specify order
        [HttpPost("RemoveOrders"), AllowAnonymous]
        //public async Task<IActionResult> Delete([FromBody]RemoveOrders command)
        public async Task<IActionResult> RemoveOrders([FromBody]RemoveOrders command)
        {


            var orders = await _orderService.DeleteAsync(command.OrderIds);

            return Json(orders);
        }


        // get all orders
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.GetAsync();

            return Json(orders);
        }

        // get orders for specify user
        [HttpPost("GetOrdersInfo"), AllowAnonymous]
        public async Task<IActionResult> GetOrdersInfo([FromBody]GetOrdersInfo command)
        {
            var orders = await _orderService.BrowseAsync(command.UserId);

            return Json(orders);
        }

        

        

        // get one order by id
        //[HttpGet("{orderId}")]
        //public async Task<IActionResult> Get(Guid orderId)
        //{
        //    var order = await _orderService.GetAsync(orderId);

        //    return Json(order);
        //}

        // TODO remove
        //[HttpPut("{garageId}")]
        //public async Task<IActionResult> Put(Guid garageId, [FromBody]UpdateGarage command)
        //{
        //    //await _garageService.UpdateAsync(garageId, command.XLength, command.YLength, command.ZLength);
        //    throw new NotImplementedException();
        //    // HTTP 204 code
        //    return NoContent();
        //}

        //[HttpDelete("{garageId}")]
        //public async Task<IActionResult> Delete(Guid garageId)
        //{
        //    throw new NotImplementedException(); 

        //    // await _garageService.DeleteAsync(garageId);

        //    // HTTP 204 code
        //    return NoContent();
        //}
    }
}