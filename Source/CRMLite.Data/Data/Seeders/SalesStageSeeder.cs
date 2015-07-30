using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Data.Data.Seeders
{
    public class SalesStageSeeder
    {
        public static void Seed(DataContext context)
        {
            var salesstage = new List<SalesStage>
            {
               new SalesStage{ Name = "Prospecting",Status=SaleStatus.Prospecting},
               new SalesStage{ Name = "Need Analysis",Status=SaleStatus.Prospecting},
               new SalesStage{ Name = "Qualified",Status=SaleStatus.Won},
               new SalesStage{ Name = "Closed Won",Status=SaleStatus.Won},
               new SalesStage{ Name = "Closed Lost ",Status=SaleStatus.Lost},
               new SalesStage{ Name = "Quotation",Status=SaleStatus.Prospecting},
               new SalesStage{ Name = "Negotiation",Status=SaleStatus.Prospecting}
            };
            salesstage.ForEach(s => context.SalesStageMaster.Add(s));
            context.SaveChanges();
        }
    }
}
