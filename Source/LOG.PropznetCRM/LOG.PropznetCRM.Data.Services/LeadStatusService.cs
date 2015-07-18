using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.Services
{
    public class LeadStatusService : ILeadStatusService
    {
        readonly ILeadStatusRepository _leadStatusRepository;

        public LeadStatusService(ILeadStatusRepository leadStatusRepository)
        {
            _leadStatusRepository = leadStatusRepository;
        }
        public IList<LeadStatus> GetAllLeadStatuses()
        {
            return _leadStatusRepository.GetAllLeadStatuses().ToList();
        }
    }
}