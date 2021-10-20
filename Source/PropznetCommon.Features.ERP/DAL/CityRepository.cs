using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Common.Data.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        readonly IERPDataContext _dataContext;
        public CityRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<City> GetAllCitiesByState(long stateId)
        {
            return _dataContext.Cities
                .Where(i => i.StateId == stateId).ToList();
        }
    }
}