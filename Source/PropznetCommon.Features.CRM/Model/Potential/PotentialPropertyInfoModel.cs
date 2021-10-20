using PropznetCommon.Features.CRM.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Model.Potential
{
    public class PotentialPropertyInfoModel : ModelBase
    {//
        public long selectedState { get; set; }
        public string City { get; set; }
        public short Floor { get; set; }
        public float Area { get; set; }
        public decimal BudgetFrom { get; set; }
        public decimal BudgetTo { get; set; }
        public CRMPropertyType selectedProperty { get; set; }
        public long selectedPropertyCategory { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public long? PropertyId { get; set; }
        public DateTime ExpectedMoveInDate { get; set; }
        public short Beds { get; set; }
        public short Baths { get; set; }
        public long CountryId { get; set; }
    }
}
