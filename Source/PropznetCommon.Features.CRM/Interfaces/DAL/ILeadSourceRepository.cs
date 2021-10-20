using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;
using Common.Data.Interfaces;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface ILeadSourceRepository : IGenericRepository<LeadSource>
    {
        IList<LeadSource> GetAllLeadSources();
    }
}
