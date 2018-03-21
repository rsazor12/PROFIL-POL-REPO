using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.GarageComponents;
using ProfilPol.Core.Domain.Repositories;
using ProfilPol.Core.Repositories;
using ProfilPol.Infrastructure.DTO;

namespace ProfilPol.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        // private readonly IGarageService _garageService;
        private readonly IGarageRepository _garageRepository;
        //private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;


        public OrderService(IOrderRepository orderRepository, IGarageRepository garageRepository, IUserRepository userRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._garageRepository = garageRepository;
            this._userRepository = userRepository;
            this._mapper = mapper;
        }


        public async Task<OrderDto> GetAsync(Guid id)
        {
            var order = await _orderRepository.GetAsync(id);

            return _mapper.Map<Order,OrderDto>(order);
        }

        public async Task<List<GetOrderInfoDto>> BrowseAsync(Guid userId)
        {
            var orders = await _orderRepository.BrowseAsync(userId);


            // TODO add configuration to automapper here
            return _mapper.Map<List<Order>, List<GetOrderInfoDto>>(orders);
        }

        public async Task AddOrderAsync(Order orderDto)
        {
            await _orderRepository.AddAsync(orderDto);
        }

        public async Task<OrderDto> CreateAsync(Guid garageId, DateTime createdAt, string email, string name, string surname, string password, string address, string city, string location)
        {
            // code below because only loged in user can make on order
            var user = await _userRepository.GetAsync(email);

            // if user doesn't exist create it 
            if(user==null)
            {
                var newUser = new User(Guid.NewGuid(), "normal", name, surname, email, password, address, city, location);

                await _userRepository.AddAsync(newUser);
            }
            else
            {
                // if exists update it data
                var newUser = new User(user.Id, "normal", name, surname, email, password, address, city, location);


                await _userRepository.UpdateAsync(user, newUser);
            }

            

            var garage = await _garageRepository.GetAsync(garageId);


            var order = new Order(
                user,
                garage,
                createdAt
                );

            await _orderRepository.AddAsync(order);

            return _mapper.Map<Order, OrderDto>(order);
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
