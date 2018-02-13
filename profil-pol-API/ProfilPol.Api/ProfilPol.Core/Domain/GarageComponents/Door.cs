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
        public Position Position{ get; protected set;}
        public double XLength;
        public double YLength;
        public double ZLength;

    }
}
