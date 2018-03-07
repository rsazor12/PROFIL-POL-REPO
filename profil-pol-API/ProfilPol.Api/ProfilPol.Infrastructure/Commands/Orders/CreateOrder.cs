using ProfilPol.Core.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Commands.Garages
{
    public class CreateOrder
    {
        public Guid GarageId { get; set; }

        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Password { get; set; }

        public double Price { get; set; }
        public SheetColor SheetColor{ get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Location { get; set; }

    }
}
