using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Entities
{
    public class AgentInfo:CRMEntityBase
    {
        public bool IsListingMember { get; set; }
        public string DEDLicenseNumber { get; set; }
        public string RERARegistrationNumber { get; set; }
        public AgentType AgentType { get; set; }
        public CRMCommisionType CommisionType { get; set; }
        public decimal Commission { get; set; }

        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}