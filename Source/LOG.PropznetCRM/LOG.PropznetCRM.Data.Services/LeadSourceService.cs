using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.Services
{
    public class LeadSourceService:ILeadSourceService
    {
        readonly ILeadSourceRepository _leadSourceRepository;

        public LeadSourceService(ILeadSourceRepository leadSourceRepository)
        {
            _leadSourceRepository = leadSourceRepository;
        }
        public IList<LeadSource> GetAllLeadSources()
        {
            return _leadSourceRepository.GetAllLeadSources().ToList();
        }
    }
}