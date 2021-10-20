using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;

namespace PropznetCommon.Features.CRM.Services
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