using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyAgentMapService
    {
        long GetPropertyIdByAgentId(long agentId);
        IList<long> GetAllAgentIdByPropertyId(long propertyId);
        IList<User> GetAllAgentsByPropertyId(long propertyId);
        bool CreatePropertyAgentMap(PropertyAgentMapModel propertyAgentMapModel);
        bool UpdatePropertyAgentMap(PropertyAgentMapModel propertyAgentMapModel);
        bool Delete(long propertyId);
    }
}
