using System.Collections.Generic;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Lead;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface ILeadService
    {
        IList<Lead> GetAllLeadsByUserId(long userId, IList<int> permissionCodes);
        bool DeleteLead(long id);
        bool CreateLead(LeadModel leadModel);
        bool UpdateLead(LeadModel leadModel);
        Lead GetLead(long id);
        SearchResult<Lead> SearchLeads(LeadSearchFilter searchargument, int pagesize, int count);
    }
}
