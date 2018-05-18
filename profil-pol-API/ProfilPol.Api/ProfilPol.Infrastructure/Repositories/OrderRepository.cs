using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.GarageComponents;
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
        private static readonly ISet<Order> _orders = new HashSet<Order>()
        {
            // TODO refactor this, every DDD object should store id not objects
            new Order(
                new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "normal", "testName3", "testSurname3", "test3@mail", "test3", "adres1", "city1", "location"),
                new Garage(
                Guid.Parse("00000000000000000000000000000001"),
                new OfferDetails("../../assets/images/garages/20160602_085134_HDR.jpg", "testNameBD", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1000)
                ),
                DateTime.UtcNow,
                1000,
                ProductionStatus.ZamowienieZLozone,
                2,2,2,SheetColor.CiemnyDab),
            new Order(
                new User(Guid.Parse("00000000-0000-0000-0000-000000000002"), "normal", "testName3", "testSurname3", "test3@mail", "test3", "adres1", "city1", "location"),
                new Garage(
                Guid.Parse("00000000000000000000000000000001"),
                new OfferDetails("../../assets/images/garages/20160602_085134_HDR.jpg", "testNameBD2", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1000)
                ),
                DateTime.UtcNow,
                1000,
                ProductionStatus.ZamowienieZLozone,
                3,3,3,
                SheetColor.Ocynk
               )                
        };

        public async Task<Order> GetAsync(Guid id)
        {
            return await Task.FromResult(_orders.SingleOrDefault(g => g.Id == id));
        }

        //get all orders
        public async Task<List<Order>> GetAsync()
        {
            return await Task.FromResult(_orders.ToList());
        }

        public async Task<List<Order>> BrowseAsync(Guid userId)
        {
            return await Task.FromResult(_orders.Where(order => order.User.Id == userId).ToList());
        }

        public async Task AddAsync(Order order)
        {
            _orders.Add(order);
            await Task.CompletedTask;
        }

        // update by id
        public async Task UpdateAsync(Order srcOrder)
        {
            // List<Order> ordersToUpdate = new List<Order>();

                var destOrder = _orders.Where(order => srcOrder.Id == order.Id).FirstOrDefault();

                if (destOrder != null)
                {
                    updateOrder(srcOrder, destOrder);
                }

        }

        // update by id from list
        public async Task UpdateAsync(List<Order> orders)
        {
            // List<Order> ordersToUpdate = new List<Order>();

            orders.ToList().ForEach(srcOrder =>
            {
                var destOrder = _orders.Where(order => srcOrder.Id == order.Id).FirstOrDefault();

                if (destOrder != null)
                {
                    updateOrder(srcOrder, destOrder);
                }

            });
        }

        private void updateOrder(Order source, Order destination)
        {
            destination.Garage = source.Garage;
            destination.OrderDate = source.OrderDate;
            destination.Price = source.Price;
            destination.ProductionStatus = source.ProductionStatus;
            destination.SheetColor = source.SheetColor;
            destination.User = source.User;
            destination.XLength = source.XLength;
            destination.YLength = source.YLength;
            destination.ZLength = source.ZLength;
        }

        public async Task<List<Order>> DeleteAsync(List<Guid> ids)
        {
            List<Order> ordersToDelete = new List<Order>();

            // get all orders to delete and remove from repository
            ids.ToList().ForEach(id =>
            {
                var orderToDelete = _orders.Where(order => order.Id == id).FirstOrDefault();

                if (orderToDelete != null)
                {
                    ordersToDelete.Add(orderToDelete);
                    _orders.Remove(orderToDelete);
                }
               
            });

            return await Task.FromResult(ordersToDelete);
        }

    }
}
