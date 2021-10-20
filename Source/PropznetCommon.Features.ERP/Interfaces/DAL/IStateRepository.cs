using System.Collections.Generic;
using Common.Data.Entities;
using Common.Data.Interfaces;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IStateRepository : IGenericRepository<State>
    {
        IList<State> GetAllStatesByCountry(long countryId);

    }
}
