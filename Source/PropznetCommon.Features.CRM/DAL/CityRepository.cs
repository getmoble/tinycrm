using Common.Data;
using Common.Data.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.DAL
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public CityRepository(ICRMLiteDataContext context)
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
