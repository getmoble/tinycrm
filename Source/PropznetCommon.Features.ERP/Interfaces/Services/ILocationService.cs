using System.Collections.Generic;
using Common.Data.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface ILocationService
    {
        IList<Country> GetAllCountries();
        IList<State> GetAllStatesByCountry(long countryId);
        IList<City> GetAllCitiesByState(long stateId);
    }
}
