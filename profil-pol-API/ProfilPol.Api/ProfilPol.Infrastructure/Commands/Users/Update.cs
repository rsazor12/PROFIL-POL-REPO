using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Commands.Users
{
    public class Update
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Role { get; set; }
    }
}
