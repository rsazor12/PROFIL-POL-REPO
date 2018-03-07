using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.Repositories;
using ProfilPol.Infrastructure.Commands.Users;
using ProfilPol.Infrastructure.DTO;
using ProfilPol.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task<AccountDto> GetAccountAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);

            return _mapper.Map<AccountDto>(user);

        }

        public async Task<UserDto> GetUserDetails(string email)
        {
            var user = await _userRepository.GetOrFailAsync(email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task RegisterAsync(Guid userId,  string email, string name, string surname, string password, string adress, string city, string location, string role = "user")
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: '{email}' already exists.");
            }
            // TODO - here should be used hash function
            user = new User(userId, role, name, surname, email, password, adress, city, location);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(Guid userId, string email, string name, string surname, string password, string adress, string city, string location, string role = "user")
        {
            var user = new User(userId, role, name, surname, email, password, adress, city, location);
     
            await _userRepository.UpdateAsync(user);
        }

        //// TODO old method
        //public async Task<string> LoginAsync(Login login)
        //{
        //    // todo remove
        //    //var user = await Authenticate(login);
        //    //string tokenString = String.Empty;

        //    //if (user != null)
        //    //{
        //    //    tokenString = BuildToken(user);
        //    //}

        //    //return tokenString;

        //    return Task.CompletedTask;
        //}

        public async Task<TokenDto> LoginAsync(Login login)
        {
            var user = await Authenticate(login);
            var token = BuildToken(user);

            return new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = token.ValidTo,
                Role = user.Role
            };
        }

        private JwtSecurityToken BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                // uniqe identifier
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Issued at (kiedy wydany)
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())


            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);


            return token;
            // return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> Authenticate(Login login)
        {
            User user = await _userRepository.GetAsync(login.Email);


            if (user == null)
            {
                throw new Exception($"Invalid Credentials.");
            }

            // TODO - here should be used hash function
            if (user.Password != login.Password)
            {
                throw new Exception("Invalid credentials");
            }

            return user;
        }

    }
}
