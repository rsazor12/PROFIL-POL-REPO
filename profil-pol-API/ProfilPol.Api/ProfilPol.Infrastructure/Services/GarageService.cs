using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProfilPol.Core.Dictionaries;
using ProfilPol.Core.Domain;
using ProfilPol.Core.Domain.GarageComponents;
using ProfilPol.Core.Domain.Repositories;
using ProfilPol.Infrastructure.DTO;
using ProfilPol.Infrastructure.Extensions;

namespace ProfilPol.Infrastructure.Services
{
    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;
        private readonly IMapper _mapper;
        public GarageService(IGarageRepository garageRepository, IMapper mapper)
        {
            _garageRepository = garageRepository;
            _mapper = mapper;
        }

        public async Task<GarageDto> getAsync(Guid id)
        {
            var @garage = await _garageRepository.GetOrFailAsync(id);

            return _mapper.Map<GarageDto>(@garage);
        }

        public async Task<List<GarageDto>> getAllAsync()
        {
            var garageList = await _garageRepository.GetAllAsync();

            return _mapper.Map<List<GarageDto>>(garageList);
        }


        public async Task CreateAsync(Guid id, OfferDetails offerDetails)
        {
            var @garage = new Garage(id, offerDetails);
            await _garageRepository.AddAsync(@garage);
        }

        public async Task AddGarageAsync(GarageDto garage)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateAsync(Guid id, double xLength, double yLength, double zLength)
        {
            // TODO reimplement
            var @garage = await _garageRepository.GetOrFailAsync(id);

            // garage.SetSize(xLength, yLength, zLength);

            await _garageRepository.UpdateAsync(@garage);

        }
        public async Task DeleteAsync(Guid id)
        {
            // TODO reimplement
            var @garage = await _garageRepository.GetOrFailAsync(id);
            _garageRepository.DeleteAsync(@garage);
        }
    }
}
