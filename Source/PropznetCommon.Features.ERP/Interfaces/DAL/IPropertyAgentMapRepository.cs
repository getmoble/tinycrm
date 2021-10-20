using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyAgentMapRepository
    {
        bool CreatePropertyAgentMap(PropertyAgentMap propertyAgentMap);
        IList<long> GetAllAgentIdByPropertyId(long propertyId);
        IList<PropertyAgentMap> GetAllPropertyAgentMapByPropertyId(long propertyId);
        long GetPropertyIdByAgentId(long agentId);
        bool DeletePropertyAgentMap(long propertyId);
    }
}
