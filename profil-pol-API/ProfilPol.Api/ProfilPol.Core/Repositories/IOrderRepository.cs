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
        Task<List<Order>> GetAsync();
        Task<List<Order>> BrowseAsync(Guid userId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task UpdateAsync(List<Order> order);
        Task<List<Order>> DeleteAsync(List<Guid> ids);
    }
}
