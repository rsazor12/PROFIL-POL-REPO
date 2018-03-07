using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain.GarageParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain.GarageComponents
{
    public class Door : Entity
    {
        public DoorType Type { get; protected set; }
        public Position Position { get; protected set;}
        public double XLength { get; protected set; }
        public double YLength { get; protected set; }
        public double ZLength { get; protected set; }

    }
}
