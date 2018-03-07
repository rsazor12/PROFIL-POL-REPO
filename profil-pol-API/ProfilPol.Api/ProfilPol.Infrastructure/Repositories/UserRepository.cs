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

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User oldUser, User newUser)
        {

            // _users.FirstOrDefault(u => u.Id == user.Id).

            // delete old user
             _users.Remove(oldUser);

            // add new to list
            _users.Add(newUser);


            //// crete new one   
            //var newUser = new User(user.Id, user.Role, user.Name, user.Surname, user.Email, user.Password, user.Adress, user.City, user.Location);

            //// add to list
            //_users.Add(user);

            await Task.CompletedTask;

        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }

    }
}
