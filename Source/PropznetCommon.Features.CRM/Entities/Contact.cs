using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.CRM.Entities
{
    public class Contact : CRMEntityBase
    {
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
        public string SecondaryEmail { get; set; }
        public string OfficePhone { get; set; }
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}