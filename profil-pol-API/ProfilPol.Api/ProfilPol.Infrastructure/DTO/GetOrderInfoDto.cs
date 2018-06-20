using ProfilPol.Core.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.DTO
{
    public class GetOrderInfoDto
    {
        public Guid OrderId { get; set; }
        public Guid GarageId { get; set; }
        public string GarageName { get; set; }
        public double GarageSizeX { get; set; }
        public double GarageSizeY { get; set; }
        public double GarageSizeZ { get; set; }
        public double Price { get; set; }
        public SheetColor SheetColor { get; set; }
        public ProductionStatus ProductionStatus { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        // user details
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Location { get; set; }

        public GetOrderInfoDto(Guid orderId, Guid garageId, string garageName, double garageSizeX, double garageSizeY, double garageSizeZ, double price, SheetColor sheetColor, ProductionStatus productionStatus, string imagePath, string description, DateTime orderDate, string userName, string userSurname, string userEmail, string adress, string city, string location)
        {
            OrderId = orderId;
            GarageId = garageId;
            GarageName = garageName;
            GarageSizeX = garageSizeX;
            GarageSizeY = garageSizeY;
            GarageSizeZ = garageSizeZ;
            Price = price;
            SheetColor = sheetColor;
            ProductionStatus = productionStatus;
            ImagePath = imagePath;
            Description = description;
            OrderDate = orderDate;
            UserName = userName;
            UserSurname = userSurname;
            UserEmail = userEmail;
            Adress = adress;
            City = city;
            Location = location;
        }
    }
}
