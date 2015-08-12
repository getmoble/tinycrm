using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Core.Models
{
    public class LeadResult
    {
        public IList<User> User { get; set; }
        public IList<LeadStatus> LeadStatus { get; set; }
        public IList<LeadSource> LeadSource { get; set; }
        public IList<SalesStage> SalesStage { get; set; }
    }
}
