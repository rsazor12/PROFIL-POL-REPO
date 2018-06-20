using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.Repositories;

namespace ProfilPol.Infrastructure.Repositories
{
    public class GarageRepository : IGarageRepository
    {
        private static readonly ISet<Garage> _garages = new HashSet<Garage>
        {
            new Garage(
                Guid.Parse("00000000000000000000000000000001"),
                true,
                GarageType.Dwuspad,
                SheetColor.Ocynk,
                SheetType.IGatunek,
                null,null,null,
                10,20,30),
            new Garage(
                Guid.Parse("00000000000000000000000000000002"),
                true,
                GarageType.Jednospad,
                SheetColor.ZlotyDab,
                SheetType.IIGatunek,
                null,null,null,
                20,20,50)
        };

        public async Task<Garage> GetAsync(Guid id)
        {
            return await Task.FromResult(_garages.SingleOrDefault(g => g.Id == id));
        }

        public async Task AddAsync(Garage garage)
        {
            _garages.Add(garage);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Garage garage)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Garage garage)
        {
            _garages.Remove(garage);

            await Task.CompletedTask;
        }

    }
}
