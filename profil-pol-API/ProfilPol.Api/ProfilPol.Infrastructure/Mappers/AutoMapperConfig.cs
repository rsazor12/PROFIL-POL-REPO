using AutoMapper;
using ProfilPol.Core.Domain;
using ProfilPol.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfilPol.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Garage, GarageDto>();
                cfg.CreateMap<User, AccountDto>();
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<Order, GetOrderInfoDto>()
                .ConvertUsing(
                                src => new GetOrderInfoDto(
                                src.Garage.Id,
                                src.Garage.OfferDetails.Name,
                                src.XLength,
                                src.YLength,
                                src.ZLength,
                                src.Price,
                                src.SheetColor,
                                src.ProductionStatus,
                                src.Garage.OfferDetails.ImagePath,
                                src.Garage.OfferDetails.Description,
                                src.OrderDate,
                                src.User.Name,
                                src.User.Surname,
                                src.User.Email,
                                src.User.Adress,
                                src.User.City,
                                src.User.Location

                                )
                 );
                //cfg.CreateMap<GarageDto, Garage>();
                //cfg.CreateMap<UserDto, UserDto>();
                //cfg.CreateMap<OrderDto, Order>();
            })
            .CreateMapper();
    }
}
