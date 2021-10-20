using Common.Data;
using Common.Data.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        readonly IERPDataContext _dataContext;
        public CountryRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}