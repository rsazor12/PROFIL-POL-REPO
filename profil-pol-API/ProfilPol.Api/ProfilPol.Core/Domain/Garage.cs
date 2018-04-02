using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain.GarageComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain
{
    public class Garage: Entity
    {
        public OfferDetails OfferDetails { get; protected set; }

        // TODO

        //public bool IsCustom { get; protected set; }
        //public GarageType Type { get; protected set; }

        //public SheetColor SheetColor { get; protected set; }

        //public SheetType SheetType { get; protected set; }

        //public List<Window> Windows { get; protected set; }

        //public List<Door> Doors { get; protected set; }

        //public List<Roof> Roofs { get; protected set; }
        //public double XLength { get; protected set; }
        //public double YLength { get; protected set; }
        //public double ZLength { get; protected set; }

        public Garage(Guid id, OfferDetails offerDetails)
        {
            this.Id = id;
            this.OfferDetails = offerDetails;
        }

        public Garage(OfferDetails offerDetails)
        {
            this.OfferDetails = offerDetails;
        }







        //public Garage(OfferDetails offerDetails, bool isCustom, GarageType type, SheetColor sheetColor, SheetType sheetType, List<Window> windows, List<Door> doors,
        //    List<Roof> roofs, double xLength, double yLength, double zLength
        //    )
        //{
        //    this.OfferDetails = offerDetails;
        //    this.IsCustom = isCustom;
        //    this.Type = type;
        //    this.SheetColor = sheetColor;
        //    this.SheetType = sheetType;
        //    this.Windows = windows;
        //    this.Doors = doors;
        //    this.Roofs = roofs;
        //    SetSize(xLength, yLength, zLength);

        //}

        //public Garage(Guid id, OfferDetails offerDetails, bool isCustom, GarageType type, SheetColor sheetColor, SheetType sheetType, List<Window> windows, List<Door> doors,
        //     List<Roof> roofs, double xLength, double yLength, double zLength
        //     )
        //{
        //    this.Id = id;
        //    this.OfferDetails = offerDetails;
        //    this.IsCustom = isCustom;
        //    this.Type = type;
        //    this.SheetColor = sheetColor;
        //    this.SheetType = sheetType;
        //    this.Windows = windows;
        //    this.Doors = doors;
        //    this.Roofs = roofs;
        //    SetSize(xLength, yLength, zLength);
        //}

        //public void SetSize(double xLength, double yLength, double zLength)
        //{
        //    if(xLength <0 || yLength <0 || zLength <0)
        //    {
        //        throw new Exception($"Null size for garage");
        //    }

        //    this.XLength = xLength;
        //    this.YLength = yLength;
        //    this.ZLength = zLength;
        //}


        //public Garage(Guid id, OfferDetails offerDetails, bool isCustom, GarageType type, SheetColor sheetColor, SheetType sheetType, List<Window> windows, List<Door> doors,
        //                List<Roof> roofs, double xLength, double yLength, double zLength
        //)
        //{
        //    this.Id = id;
        //    this.OfferDetails = offerDetails;
        //    this.IsCustom = isCustom;
        //    this.Type = type;
        //    this.SheetColor = sheetColor;
        //    this.SheetType = sheetType;
        //    this.Windows = windows;
        //    this.Doors = doors;
        //    this.Roofs = roofs;
        //    SetSize(xLength, yLength, zLength);
        //}


    }
}
