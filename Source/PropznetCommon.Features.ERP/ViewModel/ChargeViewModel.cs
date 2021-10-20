using Common.Utilities;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class ChargeViewModel
    {
        public long Id { get; set; }
        public string ChargeName { get; set; }
        public string GLAccount { get; set; }
        public string ChargeType { get; set; }
        public ChargeViewModel()
        {

        }
        //public ChargeViewModel(IList<Charge> charges)
        //{
        //    foreach(var charge in charges)
        //    {
        //        Id = charge.Id;
        //        ChargeName=charge.ChargeName;
        //        ChargeType = EnumUtils.GetEnumDescription(charge.ChargeType);
        //    }
        //}
        public ChargeViewModel(Charge charge)
        {
            Id = charge.Id;
            ChargeName = charge.Name;
            ChargeType = EnumUtils.GetEnumDescription(charge.Type);
        }
    }
}
