using ProfilPol.Core.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain
{
    public class Order: Entity
    {
        public User User { get; set; }
        public Garage Garage { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get;  set; }
        public ProductionStatus ProductionStatus { get;  set; }

        public double XLength { get; set; }
        public double YLength { get; set; }
        public double ZLength { get; set; }
        public SheetColor SheetColor { get; set; }


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

        public Order(Guid id, User user, Garage garage, DateTime orderDate, double Price, ProductionStatus productionStatus, double XLength, double YLength, double ZLength, SheetColor sheetColor)
        {
            this.Id = id;
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
