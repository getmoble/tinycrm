using System.Collections.Generic;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Potential;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IPotentialService
    {
        IList<Potential> GetAllPotentials(long userId, IList<int> permissionCodes);
        bool DeletePotential(long id);
        Potential GetPotential(long id);
        SearchResult<Potential> Search(PotentialSearchFilter filters, int pageSize, int page);
        Potential CreatePotential(PotentialModel potentialModel);
        IList<Potential> GetAllPotentials(IList<int> permissionCodes);
        bool UpdatePotential(PotentialModel potentialModel);
    }
}
