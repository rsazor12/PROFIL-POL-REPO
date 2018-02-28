using ProfilPol.Core.Dictionaries;
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

        Task CreateAsync(
            Guid id,
            bool isCustom,
            GarageType type,
            SheetColor sheetColor,
            SheetType sheetType,
            List<Window> windows,
            List<Door> doors,
            List<Roof> roofs,
            double xLength,
            double yLength,
            double zLength);

        Task AddOrderAsync(OrderDto garage);

        Task UpdateAsync(Guid id, double xLength, double yLength, double zLength);

        Task DeleteAsync(Guid id);
    }
}
