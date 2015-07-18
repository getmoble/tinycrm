using Common.Data;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class LocationRepository: GenericRepository<Location>, ILocationRepository
    {
        readonly DataContext _dataContext;
        public LocationRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Location> GetAllLocations(long id)
        {
            return _dataContext.Locations
                .Where(i => i.StateId == id).ToList();
        }
    }
}
