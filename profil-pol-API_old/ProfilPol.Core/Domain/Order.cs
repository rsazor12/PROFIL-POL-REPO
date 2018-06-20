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
    }
}
