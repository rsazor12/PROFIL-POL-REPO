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
    public interface IGarageService
    {
        Task<GarageDto> getAsync(Guid id);

        Task<List<GarageDto>> getAllAsync();

        Task CreateAsync(
            Guid id, OfferDetails offerDetails);

        Task AddGarageAsync(GarageDto garage);

        Task UpdateAsync(Guid id, double xLength, double yLength, double zLength);

        Task DeleteAsync(Guid id);
    }
}
