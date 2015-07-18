using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Services
{
    public class LocationService : ILocationService
    {
        readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public IList<Location> GetAllLocations(long id)
        {
            return _locationRepository.GetAllLocations(id);
        }
    }
}
