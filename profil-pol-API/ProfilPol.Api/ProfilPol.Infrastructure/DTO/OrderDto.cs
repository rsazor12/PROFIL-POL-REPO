using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public GarageDto Garage { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
