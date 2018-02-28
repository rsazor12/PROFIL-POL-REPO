using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain
{
    public class Order: Entity
    {
        public User User { get; protected set; }
        public Garage Garage { get; protected set; }
        public double Price { get; protected set; }
        public DateTime OrderDate { get; protected set; }

        public Order(User user, Garage garage, double price, DateTime orderDate)
        {
            this.User = user;
            this.Garage = garage;
            this.Price = price;
            this.OrderDate = orderDate;
        }
    }
}
