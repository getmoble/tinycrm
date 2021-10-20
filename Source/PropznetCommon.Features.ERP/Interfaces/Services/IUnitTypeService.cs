using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitTypeService
    {
        UnitType CreateUnitType(string name);
        IList<UnitType> GetAllUnitType();
    }
}
