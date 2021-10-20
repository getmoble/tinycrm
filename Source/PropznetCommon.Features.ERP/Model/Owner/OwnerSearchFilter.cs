using System;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Model.Owner
{
   public class OwnerSearchFilter
    {
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public OwnerType? OwnerType { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public bool TaxEligible { get; set; }
       public DateTime? CreatedFrom { get; set; }
       public DateTime? CreatedTo { get; set; }
       
    }
}
