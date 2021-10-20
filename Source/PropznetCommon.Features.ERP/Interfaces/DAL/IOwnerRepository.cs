using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Owner;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        IList<Owner> GetAllOwners();
        IList<Owner> GetAllOwnersById(IList<long> ownersId);
        Owner GetOwner(long id);
        Owner GetOwnerByUserId(long userId);
        bool DeleteOwner(long id);
        SearchResult<Owner> SearchOwners(OwnerSearchFilter searchFilter, int pagesize, int count);
    }
}
