using ProfilPol.Core.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain
{
    public class Order: Entity
    {
        public User User { get; protected set; }
        public Garage Garage { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public double Price { get; protected set; }
        public ProductionStatus ProductionStatus { get; protected set; }

        public double XLength { get; protected set; }
        public double YLength { get; protected set; }
        public double ZLength { get; protected set; }
        public SheetColor SheetColor { get; protected set; }


        public Order()
        {
        }

        public Order(User user, Garage garage, DateTime orderDate, double Price, ProductionStatus productionStatus, double XLength, double YLength, double ZLength, SheetColor sheetColor)
        {
            this.User = user;
            this.Garage = garage;
            this.OrderDate = orderDate;
            this.Price = Price;
            this.ProductionStatus = ProductionStatus;
            this.XLength = XLength;
            this.YLength = YLength;
            this.ZLength = ZLength;
            this.SheetColor = sheetColor;
        }
    }
}
