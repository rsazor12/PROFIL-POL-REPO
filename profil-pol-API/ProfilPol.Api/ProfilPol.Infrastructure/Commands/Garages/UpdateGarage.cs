using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Commands.Garages
{
    public class UpdateGarage
    {
        public Guid GarageId { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }
        public double ZLength { get; set; }
    }
}
