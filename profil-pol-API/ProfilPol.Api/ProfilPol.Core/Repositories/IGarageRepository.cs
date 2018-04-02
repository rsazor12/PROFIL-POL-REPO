using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Core.Domain.Repositories
{
    public interface IGarageRepository
    {
        Task<Garage> GetAsync(Guid id);
        Task<List<Garage>> GetAllAsync();
        Task<Garage> AddAsync(Garage garage);
        Task UpdateAsync(Garage garage);
        Task DeleteAsync(Garage garage);
    }
}
