using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class SaveMoreUnitInformationViewModel
    {
        public long UnitId { get; set; }
        public SalesCommissionViewModel SalesCommissionViewModel { get; set; }
        public IList<long> OwnersId { get; set; }
        public IList<long> ManagersId { get; set; }
        public IList<long> AminityId { get; set; }
        public IList<UnitRentalCommissionViewModel> PropertyRentalCommission { get; set; }
    }
}
