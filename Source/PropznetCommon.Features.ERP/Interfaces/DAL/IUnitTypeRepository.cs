using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitTypeRepository
    {
        void Create(UnitType unitType);
        IList<UnitType> GetAll();
    }
}