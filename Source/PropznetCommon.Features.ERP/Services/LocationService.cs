using System.Collections.Generic;
using System.Linq;
using Common.Data.Entities;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;

namespace PropznetCommon.Features.ERP.Services
{
    public class LocationService : ILocationService
    {
        public readonly ICountryRepository _countryRepository;
        public readonly IStateRepository _stateRepository;
        public readonly ICityRepository _cityRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public LocationService(ICountryRepository countryRepository,
            IStateRepository stateRepository,
            ICityRepository cityRepository,
            IUnitOfWork iUnitOfWork)
        {
            _countryRepository = countryRepository;
            _stateRepository=stateRepository;
            _cityRepository = cityRepository;
            _iUnitOfWork=iUnitOfWork;
        }
        public IList<Country> GetAllCountries()
        {
            return _countryRepository.GetAll().ToList();
        }

        public IList<State> GetAllStatesByCountry(long countryId)
        {
            return _stateRepository.GetAllStatesByCountry(countryId);
        }

        public IList<City> GetAllCitiesByState(long stateId)
        {
            return _cityRepository.GetAllCitiesByState(stateId);
        }
    }
}
