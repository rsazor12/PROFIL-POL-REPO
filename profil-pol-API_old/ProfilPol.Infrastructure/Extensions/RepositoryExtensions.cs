﻿using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProfilPol.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Garage> GetOrFailAsync(this IGarageRepository repository, Guid id)
        {
            var garage = await repository.GetAsync(id);

            if (garage == null)
            {
                throw new Exception($"Garage {id} not exists");
            }

            return garage;
        }
    }
}
