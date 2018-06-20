using ProfilPol.Core.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.DTO
{
    public class UpdateOrderDto
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
    }
}
