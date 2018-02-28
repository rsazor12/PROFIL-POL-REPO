using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.DTO
{
    public class OrderDto
    {
        public UserDto User { get; protected set; }
        public GarageDto Garage { get; protected set; }
        public double Price { get; protected set; }
        public DateTime OrderDate { get; protected set; }
    }
}
