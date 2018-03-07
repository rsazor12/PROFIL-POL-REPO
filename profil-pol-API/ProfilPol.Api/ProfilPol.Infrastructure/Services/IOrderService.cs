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

        Task<OrderDto> CreateAsync(Guid garageId, DateTime createdAt, string email, string name, string surname, string password, string address, string city, string location);

        Task AddOrderAsync(Order order);

        Task UpdateAsync(Order order);

        Task DeleteAsync(Guid id);
    }
}
