using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface ILeadStatusRepository
    {
        IList<LeadStatus> GetAllLeadStatuses();
    }
}
