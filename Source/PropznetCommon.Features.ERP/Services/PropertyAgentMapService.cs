using Common.Auth.SingleTenant.Entities;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyAgentMapService : IPropertyAgentMapService
    {
        readonly IPropertyAgentMapRepository _propertyAgentMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyAgentMapService(
            IPropertyAgentMapRepository propertyAgentMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyAgentMapRepository = propertyAgentMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetPropertyIdByAgentId(long agentId)
        {
            return _propertyAgentMapRepository.GetPropertyIdByAgentId(agentId);
        }
        public IList<long> GetAllAgentIdByPropertyId(long propertyId)
        {
            return _propertyAgentMapRepository.GetAllAgentIdByPropertyId(propertyId);
        }
        public bool CreatePropertyAgentMap(PropertyAgentMapModel propertyAgentMapModel)
        {
            Delete(propertyAgentMapModel.PropertyId);
            foreach (long agentId in propertyAgentMapModel.AgentId)
            {
                var propertyAgentMap = new PropertyAgentMap
                {
                    PropertyId = propertyAgentMapModel.PropertyId,
                    AgentId = agentId,
                    CreatedOn=DateTime.UtcNow
                };
                var PropertyUnitMap = _propertyAgentMapRepository.CreatePropertyAgentMap(propertyAgentMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdatePropertyAgentMap(PropertyAgentMapModel propertyAgentMapModel)
        {
            Delete(propertyAgentMapModel.Id);
            CreatePropertyAgentMap(propertyAgentMapModel);
            return true;
        }
        public bool Delete(long propertyId)
        {
            var result = _propertyAgentMapRepository.DeletePropertyAgentMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<User> GetAllAgentsByPropertyId(long propertyId)
        {
            var propertyAgentMap = _propertyAgentMapRepository.GetAllPropertyAgentMapByPropertyId(propertyId);
            IList<User> owners = null;
            if (propertyAgentMap != null)
            {
                owners = new List<User>();
                foreach (PropertyAgentMap item in propertyAgentMap)
                {
                    owners.Add(item.Agent);
                }
            }
            return owners;
        }
    }
}