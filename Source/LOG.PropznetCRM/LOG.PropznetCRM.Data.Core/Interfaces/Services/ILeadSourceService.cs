using System.Collections.Generic;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface ILeadSourceService
    {
        IList<LeadSource> GetAllLeadSources();
    }
}
