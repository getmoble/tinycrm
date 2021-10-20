using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitRentalCommissionRepository : IGenericRepository<UnitRentalCommission>
    {
        IList<UnitRentalCommission> GetAllUnitRentalCommissions();
        IList<UnitRentalCommission> GetAllUnitRentalCommissionsById(IList<long> unitRentalCommissionsId);
        UnitRentalCommission GetUnitRentalCommission(long id);
        bool DeleteUnitRentalCommission(long id);
    }
}