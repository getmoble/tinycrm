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
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public CountryRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
