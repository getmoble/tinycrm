using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Lead;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface ILeadService
    {
        IList<Lead> GetAllLeadsByUserId(long userId, IList<int> permissionCodes);
        bool DeleteLead(long id);
        Lead CreateLead(LeadModel leadModel);
        bool UpdateLead(LeadModel leadModel);
        Lead GetLead(long id);
        SearchResult<Lead> SearchLeads(LeadSearchFilter searchargument, int pagesize, int count);
    }
}
