using ProfilPol.Core.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.DTO
{
    public class GarageItemDetailsDto
    {
        public Guid GarageId { get; set; }
        public string ItemName { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public string DeliveryDays { get; set; }
        public SheetColor SheetColor { get; set; }
        public SheetType SheetType { get; set; }
        public string Sizes { get; set; }

        public GarageItemDetailsDto(
            Guid garageId,
            string itemName,
            string imagePath,
            double price,
            bool available,
            string deliveryDays,
            SheetColor sheetColor,
            SheetType sheetType,
            string[] sizes
        )
        {
            this.GarageId = garageId;
            this.ItemName = itemName;
            this.ImagePath = imagePath;
            this.Price = price;
            this.Available = available;
            this.DeliveryDays = deliveryDays;
            this.SheetColor = sheetColor;
            this.SheetType = sheetType;

        }
    }
}
