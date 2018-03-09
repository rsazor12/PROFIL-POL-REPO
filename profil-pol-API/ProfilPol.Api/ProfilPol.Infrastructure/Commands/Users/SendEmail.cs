using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Commands.Users
{
    public class SendEmail
    {
        public string UserAddress { get; set; }
        public string UserName { get; set; }
        public string MessageContent { get; set; }
    }
}
