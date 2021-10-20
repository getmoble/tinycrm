using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.LeadSource;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface ILeadSourceService
    {
        IList<LeadSource> GetAllLeadSources();
        LeadSource CreateLeadSource(LeadSourceModel leadSourceModel);
        bool UpdateLeadSource(LeadSourceModel leadSourceModel);
        bool DeleteLeadSource(long id);
    }
}
