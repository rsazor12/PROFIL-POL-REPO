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

        private readonly IEmailService _emailService;

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

        // get all orders
        public async Task<List<GetOrderInfoDto>> GetAsync()
        {
            var orders = await _orderRepository.GetAsync();

            return _mapper.Map<List<Order>, List<GetOrderInfoDto>>(orders);
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
 

        public async Task<OrderDto> CreateAsync(Guid garageId,
            DateTime createdAt, SheetColor sheetColor, double garageXLength,
            double garageYLength, double garageZLength, string email, string name, string surname,
            string password, string address, string city, string location)
        {
            // code below because only loged in user can make on order
            var user = await _userRepository.GetAsync(email);

            bool nullPassword = password == null;

            // if user doesn't exist create it 
            if (user==null)
            {
                password = !nullPassword ? password : GenerateRandomPassword(10);

                var newUser = new User(Guid.NewGuid(), "normal", name, surname, email, password, address, city, location);
                user = await _userRepository.AddAsync(newUser);
            }
            else
            {
                // if exists update it data
                var newUser = new User(user.Id, "normal", name, surname, email, password, address, city, location);

                user =  await _userRepository.UpdateAsync(user, newUser);
            }


            // Get garage with default values
            var garage = await _garageRepository.GetAsync(garageId);

            var order = new Order(
                user,
                garage,
                createdAt,
                garage.OfferDetails.Price,
                ProductionStatus.ZamowienieZLozone,
                garageXLength,
                garageYLength,
                garageZLength,
                sheetColor
                );

            await _orderRepository.AddAsync(order);


            // After create new order notify user if he hasn't account about his new password (only if user were made by admin)
            if (nullPassword)
                SendEmailAboutNewPassword(email, password);

            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task UpdateAsync(UpdateOrderDto order)
        {
            // TODO mapper workarround
            var garage = _garageRepository.GetAsync(order.GarageId).Result;
            var user = _userRepository.GetAsync(order.UserEmail).Result;

            var orderToUpdate = _mapper.Map<UpdateOrderDto, Order>(order, opt =>
            opt.AfterMap((src, dest) => {
                dest.Id = order.OrderId;
                dest.Garage = garage;
                dest.User = user;
                dest.XLength = order.GarageSizeX;
                dest.YLength = order.GarageSizeY;
                dest.ZLength = order.GarageSizeZ;
            }));

            await _orderRepository.UpdateAsync(orderToUpdate);
        }

        public async Task UpdateAsync(List<UpdateOrderDto> orders)
        {
            orders.ForEach(async order => await this.UpdateAsync(order));

            //var orderToUpdate = _mapper.Map<List<UpdateOrderDto>, List<Order>>(orders, opt =>
            //opt.AfterMap((src, dest) => ((Order)dest).Garage = ));


            //await _orderRepository.UpdateAsync(orderToUpdate);
        }

        


        public async Task<List<GetOrderInfoDto>> DeleteAsync(List<Guid> ids)
        {
            var orders = await _orderRepository.DeleteAsync(ids);

            return _mapper.Map<List<Order>, List<GetOrderInfoDto>>(orders);
        }



        /** Private methods */
        private string GenerateRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private void SendEmailAboutNewPassword(string receiver, string password)
        {
            var subject = $"Profil-pol twoje nowe haslo.";
            var messageBody = $"Twoje nowe haslo do strony Profil-pol.pl to {password}. Serdecznie pozdrawiamy i zyczymy udanych zakupow.";
            _emailService.SendEmailFromWebsite(receiver, subject, messageBody);
        }

        //private string GeneratePasswordAndNotifyUser(int passwordLength, string userEmail)
        //{
        //    var password = GenerateRandomPassword(passwordLength);
        //    SendEmailAboutNewPassword(userEmail, password);
        //}

    }
}
