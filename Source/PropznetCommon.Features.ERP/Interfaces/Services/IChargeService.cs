using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IChargeService
    {
        Charge CreateCharge(ChargeModel chargeModel);
        IList<Charge> GetAllCharge();
        Charge GetChargeById(long chargeId);
        bool DeleteCharge(long id);
    }
}