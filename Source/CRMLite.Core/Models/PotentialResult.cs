using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Core.Models
{
    public class PotentialResult
    {
        public string Potential { get; set; }
        public IList<LeadStatus> LeadStatus { get; set; }
        public IList<LeadSource> LeadSource { get; set; }
        public IList<SalesStage> SalesStage { get; set; }
        public IList<Contact> Contacts { get; set; }
        public IList<User> Users { get; set; }
        public IList<Country> Countries { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
