﻿using ProfilPol.Core.Dictionaries;
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
