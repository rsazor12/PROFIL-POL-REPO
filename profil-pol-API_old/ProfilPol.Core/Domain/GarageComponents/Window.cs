using ProfilPol.Core.Domain.GarageParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain.GarageComponents
{
    public class Window
    {
        public double XLength { get; protected set; }
        public double YLength { get; protected set; }

        public Position Position { get; protected set; }
    }
}
