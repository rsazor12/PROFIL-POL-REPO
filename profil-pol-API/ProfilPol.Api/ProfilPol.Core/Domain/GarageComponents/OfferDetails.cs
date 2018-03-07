using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Core.Domain.GarageComponents
{
    public class OfferDetails: Entity
    {
        public string ImagePath { get; protected set; }
        public string Name { get; protected set; }
        public bool Available { get; protected set; }
        public string DeliveryTime { get; protected set; }
        public string Description { get; protected set; }
        public string BadgeContent { get; protected set; }
        public string[] Sizes { get; protected set; }

        public double Price { get; protected set; }

        public OfferDetails(string imagePath, string name, bool available, string deliveryTime, string description, string badgeContent, string[] sizes, double price)
        {
            this.ImagePath = imagePath;
            this.Name = name;
            this.Available = available;
            this.DeliveryTime = deliveryTime;
            this.Description = description;
            this.BadgeContent = badgeContent;
            this.Sizes = sizes;
            this.Price = price;
        }
    }
}
