using ProfilPol.Infrastructure.Commands.Users;
using ProfilPol.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Infrastructure.Services
{
    public interface IUserService
    {
        Task<AccountDto> GetAccountAsync(Guid userId);
        Task<UserDto> GetUserDetails(string email);

        Task RegisterAsync(Guid userId, string email, string name, string surname, string password, string adress, string city, string location, string role);

        Task<TokenDto> LoginAsync(Login login);
    }
}
