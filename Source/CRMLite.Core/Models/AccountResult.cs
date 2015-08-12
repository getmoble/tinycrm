using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Core.Models
{
    public class AccountResult
    {
        public IList<Account> Account { get; set; }
        public IList<User> User { get; set; }
    }
}
