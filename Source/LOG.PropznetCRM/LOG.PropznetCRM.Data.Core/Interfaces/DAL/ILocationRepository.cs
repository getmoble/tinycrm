using System.Collections.Generic;
using Common.Data.Interfaces;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        IList<Location> GetAllLocations(long id);
    }
}
