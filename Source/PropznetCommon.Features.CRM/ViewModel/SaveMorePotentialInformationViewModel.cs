using System.Collections.Generic;

namespace PropznetCommon.Features.CRM.ViewModel
{
    public class SaveMorePotentialInformationViewModel
    {
        public long PotentialId { get; set; }
        public IList<long> PropertiesId { get; set; }
        public IList<long> AminityId { get; set; }
    }
}
