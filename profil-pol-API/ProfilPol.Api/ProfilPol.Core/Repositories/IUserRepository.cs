using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Core.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User oldUser, User newUser);
        Task DeleteAsync(User user);
    }
}
