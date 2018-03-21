using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.GarageComponents;
using ProfilPol.Core.Domain.Repositories;

namespace ProfilPol.Infrastructure.Repositories
{
    public class GarageRepository : IGarageRepository
    {
        private static readonly ISet<Garage> _garages = new HashSet<Garage>
        {
            new Garage(
                Guid.Parse("00000000000000000000000000000001"),
                new OfferDetails("../../assets/images/garages/20160602_085134_HDR.jpg", "testNameBD", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1000),
                true,
                GarageType.Dwuspad,
                SheetColor.Ocynk,
                SheetType.IGatunek,
                null,null,null,
                10,20,30),
            new Garage(
                Guid.Parse("00000000000000000000000000000002"),
                new OfferDetails("../../assets/images/garages/20160603_084340_HDR.jpg", "testNameBD", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1500),
                true,
                GarageType.Jednospad,
                SheetColor.ZlotyDab,
                SheetType.IIGatunek,
                null,null,null,
                20,20,50),
            new Garage(
                Guid.Parse("00000000000000000000000000000003"),
                new OfferDetails("../../assets/images/garages/DSC_0255.jpg", "testNameBD", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1000),
                true,
                GarageType.Dwuspad,
                SheetColor.Ocynk,
                SheetType.IGatunek,
                null,null,null,
                10,20,30),
            new Garage(
                Guid.Parse("00000000000000000000000000000004"),
                new OfferDetails("../../assets/images/garages/DSC_0406.jpg", "testNameBD", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1500),
                true,
                GarageType.Jednospad,
                SheetColor.ZlotyDab,
                SheetType.IIGatunek,
                null,null,null,
                20,20,50),
                        new Garage(
                Guid.Parse("00000000000000000000000000000005"),
                new OfferDetails("../../assets/images/garages/20160602_085134_HDR.jpg", "testNameBD", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1000),
                true,
                GarageType.Dwuspad,
                SheetColor.Ocynk,
                SheetType.IGatunek,
                null,null,null,
                10,20,30),
            new Garage(
                Guid.Parse("00000000000000000000000000000006"),
                new OfferDetails("../../assets/images/garages/20160603_084340_HDR.jpg", "testNameBD", true, "4", "destDescription", "Nowosc z BD", new string[]{"1x2","2x3"}, 1500),
                true,
                GarageType.Jednospad,
                SheetColor.ZlotyDab,
                SheetType.IIGatunek,
                null,null,null,
                20,20,50)
        };

        public async Task<List<Garage>> GetAllAsync()
        {
            // TODO remove later
            var garageList = new List<Garage>(_garages);

            return await Task.FromResult(garageList);
        }

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
