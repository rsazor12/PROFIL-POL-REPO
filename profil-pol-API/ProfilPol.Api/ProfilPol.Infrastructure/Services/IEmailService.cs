using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Services
{
    public interface IEmailService
    {
        void SendEmailFromWebsite(string receiver, string subject, string messageBody);
    }
}
