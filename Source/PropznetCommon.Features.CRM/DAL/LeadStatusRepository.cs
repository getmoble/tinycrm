using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;

namespace PropznetCommon.Features.CRM.DAL
{
    public class LeadStatusRepository :  ILeadStatusRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public LeadStatusRepository(ICRMLiteDataContext context)
        {
            _dataContext = context;
        }

        public IList<LeadStatus> GetAllLeadStatuses()
        {
           return _dataContext.LeadStatusMaster.ToList();
        }
    }
}
