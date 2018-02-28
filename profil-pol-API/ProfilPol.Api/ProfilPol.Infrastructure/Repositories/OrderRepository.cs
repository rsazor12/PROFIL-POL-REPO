using ProfilPol.Core.Domain;
using ProfilPol.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static readonly ISet<Order> _orders = new HashSet<Order>();

        public async Task<Order> GetAsync(Guid id)
        {
            return await Task.FromResult(_orders.SingleOrDefault(g => g.Id == id));
        }

        public async Task AddAsync(Order order)
        {
            _orders.Add(order);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Order order)
        {
            _orders.Remove(order);

            await Task.CompletedTask;
        }

    }
}
