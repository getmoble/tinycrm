using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Potential;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IPotentialService
    {
        IList<Potential> GetAllPotentials(long userId, IList<int> permissionCodes);
        bool DeletePotential(long id);
        Potential GetPotential(long id);
        SearchResult<Potential> Search(PotentialSearchFilter filters, int pageSize, int page);
        Potential CreatePotential(PotentialModel potentialModel, string potentialPrefix);
        IList<Potential> GetAllPotentials(IList<int> permissionCodes);
        bool UpdatePotential(PotentialModel potentialModel);
    }
}
