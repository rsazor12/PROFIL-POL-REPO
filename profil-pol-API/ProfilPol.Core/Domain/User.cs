using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain
{
    public class User : Entity
    {
        public string Role { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User(Guid id, string Role, string name, string email, string password)
        {
            this.Id = id;
            this.Role = Role;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
