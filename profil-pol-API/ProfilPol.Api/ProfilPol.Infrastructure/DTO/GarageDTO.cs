using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain.GarageComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.DTO
{
    public class GarageDto
    {
        public OfferDetails OfferDetails { get; set; }
        public Guid Id { get; set; }
        public bool IsCustom { get;  set; }
        public GarageType Type { get;  set; }

        public SheetColor SheetColor { get;  set; }

        public SheetType SheetType { get;  set; }

        public List<Window> Windows { get;  set; }

        public List<Door> Doors { get;  set; }

        public List<Roof> Roofs { get;  set; }
        public double XLength { get;  set; }
        public double YLength { get;  set; }
        public double ZLength { get;  set; }

    }
}
