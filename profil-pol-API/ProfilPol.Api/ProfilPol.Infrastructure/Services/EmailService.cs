using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Text;
using Microsoft.Extensions.Configuration;
using  MimeKit;

namespace ProfilPol.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public IConfiguration Configuration { get; }

        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Sends email from webiste uses mail credentials hardcoded in configuration
        /// </summary>
        public void SendEmailFromWebsite(string receiver, string subject, string messageBody )
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Configuration["Email:SenderAddress"]));

            message.To.Add(new MailboxAddress(receiver));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = messageBody
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(Configuration["Email:SenderAddress"], Configuration["Email:SenderPassword"]);

                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
