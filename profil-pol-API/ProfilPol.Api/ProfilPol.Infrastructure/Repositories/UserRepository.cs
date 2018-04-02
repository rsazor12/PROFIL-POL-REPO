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
            new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "normal", "testName3", "testSurname3", "test3@mail", "test3", "adres1", "city1", "location"),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "normal", "testName1", "test1", "test1", "", "", "", ""),
            new User(Guid.Parse("00000000-0000-0000-0000-000000000003"), "admin", "testName2", "test2", "test2", "", "", "", "")

        };
        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(u => u.Id == id));
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(u => u.Email == email));
        }

        public async Task<User> AddAsync(User user)
        {
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<User> UpdateAsync(User oldUser, User newUser)
        {

            // delete old user
             _users.Remove(oldUser);

            // add new to list
            _users.Add(newUser);

            return await Task.FromResult(newUser);

        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }

    }
}
