using ProfilPol.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(Guid id);
        Task AddAsync(Order garage);
        Task UpdateAsync(Order garage);
        Task DeleteAsync(Order garage);
    }
}
