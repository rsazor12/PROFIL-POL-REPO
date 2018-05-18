using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using ProfilPol.Infrastructure.Commands.Users;
using ProfilPol.Infrastructure.Services;

namespace ProfilPol.Api.Controllers
{
    [Produces("application/json")]
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public IConfiguration Configuration { get; }

        public AccountController(
            IUserService userService,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _userService = userService;
            _emailService = emailService;
            Configuration = configuration;
        }

        // To sending mail
        [HttpPost("SendEmail"), AllowAnonymous]
        public async Task<IActionResult> SendEmail([FromBody]SendEmail command)
        {
            var subject = $"Pytanie: Uzytkownik {command.UserName} ({command.UserAddress})";
            var messageBody = $"Uzytkownik: {command.UserAddress} wyslal wiadomosc: \n\n\n" + command.MessageContent;

            _emailService.SendEmailFromWebsite(
                command.UserAddress,
                subject,
                messageBody
                );



            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress(Configuration["Email:SenderAddress"]));

            //message.To.Add(new MailboxAddress(Configuration["Email:ReceiverAddress"]));
            //message.Subject = $"Pytanie: Uzytkownik {command.UserName} ({command.UserAddress})";
            //message.Body = new TextPart("plain")
            //{
            //    Text = $"Uzytkownik: {command.UserAddress} wyslal wiadomosc: \n\n\n"
            //           + command.MessageContent
            //};

            //using (var client = new SmtpClient())
            //{
            //    try
            //    {
            //        client.Connect("smtp.gmail.com", 587, false);
            //        client.Authenticate(Configuration["Email:SenderAddress"], Configuration["Email:SenderPassword"]);

            //        client.Send(message);
            //        client.Disconnect(true);
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
                
            //}

            return Ok();
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