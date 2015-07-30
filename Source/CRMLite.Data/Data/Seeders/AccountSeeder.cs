using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Data.Data.Seeders
{
    public class AccountSeeder
    {
        public static void Seed(DataContext context)
        {
            var account = new List<Account>
            {
                new Account{AgentId=1,Comments="no comments",CommunicationDetailId=1,Industry="Private",Name="Ac123",RefId="AT01",CreatedBy=1,UpdatedBy=1},
                new Account{AgentId=2,Comments="no comments",CommunicationDetailId=2,Industry="Private",Name="Ac103",RefId="AT02",CreatedBy=1,UpdatedBy=1},
                new Account{AgentId=3,Comments="no comments",CommunicationDetailId=3,Industry="Private",Name="Ac113",RefId="AT03",CreatedBy=2,UpdatedBy=2}
            };
            account.ForEach(s => context.Accounts.Add(s));
            context.SaveChanges();
        }
    }
}
