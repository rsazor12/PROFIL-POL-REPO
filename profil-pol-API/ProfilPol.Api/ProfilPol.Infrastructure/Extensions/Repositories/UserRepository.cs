using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>
        {
            new User(Guid.NewGuid(), "normal", "testName1", "test1", "test1"),
            new User(Guid.NewGuid(), "admin", "testName2", "test2", "test2")

        };
        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(u => u.Id == id));
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(u => u.Email == email));
        }

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }

    }
}
