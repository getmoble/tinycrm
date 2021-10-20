using System.Collections.Generic;
using Common.Data.Entities;
using Common.Data.Interfaces;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface ICityRepository : IGenericRepository<City>
    {
        IList<City> GetAllCitiesByState(long stateId);
    }
}
