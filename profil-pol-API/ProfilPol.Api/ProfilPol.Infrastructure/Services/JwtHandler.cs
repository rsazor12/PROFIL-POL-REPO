using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using ProfilPol.Infrastructure.DTO;
using ProfilPol.Infrastructure.Settings;

namespace ProfilPol.Infrastructure.Services
{
    //class JwtHandler : IJwtHandler
    //{
    //    private readonly JwtSettings _jwtSettings;

    //    public JwtHandler(IOptions<JwtSettings> jwtSettings)
    //    {
    //        _jwtSettings = jwtSettings;
    //    }

    //    public JwtDto CreateToken(Guid userId, string role)
    //    {
    //        var now = DateTime.UtcNow;

    //        var claims = new Claim[]
    //        {
    //            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
    //            new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
    //            new Claim(ClaimTypes.Role, role),
    //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //            new Claim(JwtRegisteredClaimNames.Iat, now.Ticks.ToString())
    //        };

    //        var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
    //    }
    //}
}
            
