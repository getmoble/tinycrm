using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitTypeRepository : IUnitTypeRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitTypeRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Create(UnitType unitType)
        {
            _dataContext.UnitTypes.Add(unitType);
        }
        public IList<UnitType> GetAll()
        {
            return _dataContext.UnitTypes.ToList();
        }
    }
}