using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IChargeRepository : IGenericRepository<Charge>
    {
        IList<Charge> GetAllCharges();
        Charge GetChargeById(long chargeId);
        bool DeleteCharge(long chargeId);
    }
}
