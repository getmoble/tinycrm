using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyRentalCommissionRepository : IGenericRepository<PropertyRentalCommission>
    {
        IList<PropertyRentalCommission> GetAllPropertyRentalCommissions();
        IList<PropertyRentalCommission> GetAllPropertyRentalCommissionsById(IList<long> propertyRentalCommissionsId);
        PropertyRentalCommission GetPropertyRentalCommission(long id);
        bool DeletePropertyRentalCommission(long id);
    }
}