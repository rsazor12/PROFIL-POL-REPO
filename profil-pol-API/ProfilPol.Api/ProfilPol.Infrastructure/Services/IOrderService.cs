using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.GarageComponents;
using ProfilPol.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Infrastructure.Services
{
    public interface IOrderService
    {
        Task<OrderDto> GetAsync(Guid id);

        Task<List<GetOrderInfoDto>> GetAsync();

        Task<List<GetOrderInfoDto>> BrowseAsync(Guid userId);

        Task<OrderDto> CreateAsync(Guid garageId,
            DateTime createdAt, SheetColor sheetColor, double garageXLength,
            double garageYLength, double garageZLength, string email, string name, string surname,
            string password, string address, string city, string location);

        Task AddOrderAsync(Order order);

        Task UpdateAsync(Order order);

        Task DeleteAsync(Guid id);
    }
}
