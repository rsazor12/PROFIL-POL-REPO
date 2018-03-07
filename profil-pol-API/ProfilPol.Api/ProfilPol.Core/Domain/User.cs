using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain
{
    public class User : Entity
    {
        public string Role { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Adress { get; protected set; }
        public string City { get; protected set; }
        public string Location { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User(Guid id, string Role, string name, string surname, string email, string password, string adress, string city, string location)
        {
            this.Id = id;
            this.Role = Role;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Adress = adress;
            this.City = city;
            this.Location = location;
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
