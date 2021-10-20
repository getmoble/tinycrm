using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Common.Data.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        readonly IERPDataContext _dataContext;
        public StateRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<State> GetAllStatesByCountry(long countryId)
        {
            return _dataContext.States
                .Where(i => i.CountryId == countryId).ToList();
        }
    }
}