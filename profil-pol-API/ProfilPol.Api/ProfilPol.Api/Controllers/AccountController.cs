using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfilPol.Infrastructure.Commands.Users;
using ProfilPol.Infrastructure.Services;

namespace ProfilPol.Api.Controllers
{
    [Produces("application/json")]
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet, Authorize]
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
            => Json(await _userService.GetAccountAsync(UserId));

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Get([FromBody]GetUserDetails command)
            => Json(await _userService.GetUserDetails(command.Email.ToString()));

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Put([FromBody]Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(),
                command.Email, command.Name, command.Surname, command.Password, command.Adress, command.City, command.Location, command.Role);

            return Created("/account", null);
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public async Task<IActionResult> Put([FromBody]Update command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(),
                command.Email, command.Name, command.Surname, command.Password, command.Adress, command.City, command.Location, command.Role);

            return Created("/account", null);
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            IActionResult response = Unauthorized();

            var token = await _userService.LoginAsync(command);

            if(token != null)
            {
                response = Json(token);
            }
            
            // returns token
            //var tokenString = await _userService.LoginAsync(command);

            //if (tokenString != String.Empty)
            //{
            //    response = Ok(new { token = tokenString });
            //}



            return response;
        }

    }
}