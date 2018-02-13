using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.DTO
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string Role { get; set; }

        public DateTime Expires { get; set; }

    }
}
