﻿using AutoMapper;
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
            })
            .CreateMapper();
    }
}
