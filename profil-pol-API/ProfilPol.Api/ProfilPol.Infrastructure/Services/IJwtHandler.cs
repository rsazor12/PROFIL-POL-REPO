using ProfilPol.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Services
{
    interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
