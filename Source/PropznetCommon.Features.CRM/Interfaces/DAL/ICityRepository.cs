using Common.Data.Entities;
using Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface ICityRepository: IGenericRepository<City>
    {
        IList<City> GetAllCitiesByState(long stateId);
    }
}