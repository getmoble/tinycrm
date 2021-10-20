using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Owner;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IOwnerService
    {
        IList<Owner> GetAllOwners();
        IList<Owner> GetAllOwnersById(IList<long> ownersId);
        Owner GetOwnerByUserId(long userId);
        Owner CreateOwner(OwnerModel OwnerModel);
        Owner EditOwner(long id);
        Owner UpdateOwner(OwnerModel ownerModel);
        bool DeleteOwner(long ownerId);
        SearchResult<Owner> SearchOwner(OwnerSearchFilter searchargument, int pagesize, int count);
    }
}
