using Common.Data.Interfaces;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.Services
{
    class AgentPropertyMapService : IAgentPropertyMapService
    {
        public readonly IAgentPropertyMapRepository _agentPropertyMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public AgentPropertyMapService(IAgentPropertyMapRepository agentPropertyMapRepository, IUnitOfWork iUnitOfWork)
        {
            _agentPropertyMapRepository = agentPropertyMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public AgentPropertyMap CreateAgentPropertyMap(long agentId, long propertyId)
        {
            var agentPropertyMap = new AgentPropertyMap { 
            AgentId=agentId,
            PropertyId=propertyId
            };
           var newAgentPropertyMap= _agentPropertyMapRepository.Create(agentPropertyMap);
            _iUnitOfWork.Commit();
            return newAgentPropertyMap;
        }

        public bool UpdateAgentPropertyMap(long agentId, long propertyId, long agentPropertyMapId)
        {
            var agentPropertyMap = new AgentPropertyMap
            {
                AgentId = agentId,
                PropertyId = propertyId,
                Id=agentPropertyMapId
            };
            _agentPropertyMapRepository.Update(agentPropertyMap);
            _iUnitOfWork.Commit();
            return true;
        }

        public bool DeleteAgentPropertyMap(long agentPropertyMapId)
        {
            _agentPropertyMapRepository.Delete(agentPropertyMapId);
            return true;
        }
        public IList<AgentPropertyMap> GetAllAgentPropertyMap()
        {
            return _agentPropertyMapRepository.GetAll().ToList();
        }

        public IList<AgentPropertyMap> GetAllAgentPropertyMapByUserId(long userId)
        {
            return _agentPropertyMapRepository.GetAllAgentPropertyMapByUserId(userId);
        }

        public AgentPropertyMap GetAgentPropertyMap(long id)
        {
            return _agentPropertyMapRepository.GetAgentPropertyMap(id);
        }
    }
}