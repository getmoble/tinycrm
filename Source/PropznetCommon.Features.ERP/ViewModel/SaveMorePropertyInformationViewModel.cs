using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class SaveMorePropertyInformationViewModel
    {
        public long PropertyId { get; set; }
        public MarketingInformationViewModel MarketingInformationViewModel { get; set; }
        public SalesCommissionViewModel SalesCommissionViewModel { get; set; }
        public IList<long> UnitsId { get; set; }
        public IList<long> OwnersId { get; set; }
        public IList<long> ManagersId { get; set; }
        public IList<long> AgentsId { get; set; }
        public IList<long> AminityId { get; set; }
        public IList<PropertyRentalCommissionViewModel> PropertyRentalCommission { get; set; }
    }
}
