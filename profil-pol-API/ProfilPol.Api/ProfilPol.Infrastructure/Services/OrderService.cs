using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain.GarageComponents;
using ProfilPol.Core.Repositories;
using ProfilPol.Infrastructure.DTO;

namespace ProfilPol.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGarageService _garageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public OrderService(IOrderRepository orderRepository, IGarageService garageService, IUserService userService, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._garageService = garageService;
            this._userService = userService;
            this._mapper = mapper;
        }


        public Task<OrderDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task AddOrderAsync(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Guid id, bool isCustom, GarageType type, SheetColor sheetColor, SheetType sheetType, List<Window> windows, List<Door> doors, List<Roof> roofs, double xLength, double yLength, double zLength)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, double xLength, double yLength, double zLength)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
