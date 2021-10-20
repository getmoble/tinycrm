using Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface ICountryService
    {
        IList<Country> GetAllCountries();
    }
}
