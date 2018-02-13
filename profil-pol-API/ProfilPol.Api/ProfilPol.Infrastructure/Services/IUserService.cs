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
        Task RegisterAsync(Guid userId, string email, string name, string password, string role ="user");

        Task<TokenDto> LoginAsync(Login login);
    }
}
