using PropznetCommon.Features.CRM.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Model.Potential
{
    public class PropertyPotentialSearchFilter
    {
            public string Name { get; set; }
            public string Account { get; set; }
            public string SalesStage { get; set; }
            public string PropertyType { get; set; }
            public double ExpectedAmount { get; set; }
            public DateTime ExpectedCloseDate { get; set; }
            public string LeadSource { get; set; }
            public string Comments { get; set; }
            public long? SalesStageId { get; set; }
            public CRMPropertyType? PropertyTypeId { get; set; }
            public long? LeadSourceId { get; set; }
            public long? AgentId { get; set; }
            public long? UserId { get; set; }
    }
}