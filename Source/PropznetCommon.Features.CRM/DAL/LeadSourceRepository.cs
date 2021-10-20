using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using Common.Data;

namespace PropznetCommon.Features.CRM.DAL
{
    public class LeadSourceRepository : GenericRepository<LeadSource>, ILeadSourceRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public LeadSourceRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<LeadSource> GetAllLeadSources()
        {
            return _dataContext.LeadSourceMaster.ToList();
        }
    }
}
