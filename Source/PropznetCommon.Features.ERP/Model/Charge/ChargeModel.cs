using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Model.Charge
{
   public class ChargeModel
    {
        public long Id { get; set; }
        public string ChargeName { get; set; }
        public ChargeType ChargeType { get; set; }
        public string GLAccount { get; set; }
        public ChargeModel(ChargeViewModel vm)
        {
            Id = vm.Id;
            ChargeName = vm.ChargeName;
            GLAccount = vm.GLAccount;
            if (!string.IsNullOrEmpty(vm.ChargeType))
                ChargeType = (ChargeType)Enum.Parse(typeof(ChargeType), vm.ChargeType);
        }
    }
}
