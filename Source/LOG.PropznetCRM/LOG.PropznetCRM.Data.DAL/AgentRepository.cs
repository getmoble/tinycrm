using Common.Data;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Agent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class AgentRepository : GenericRepository<Agent>, IAgentRepository
    {
        readonly DataContext _dataContext;
        public AgentRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Agent> GetAllAgentsByUserId(long userId)
        {
            return _dataContext.Agents
                .Include(p => p.CommunicationDetail)
                .Where(i => !i.DeletedOn.HasValue && i.CreatedBy == userId).ToList();
        }
        public IList<Agent> GetAllAgents()
        {
            return _dataContext.Agents
                .Include(p => p.CommunicationDetail)
                .Where(i => !i.DeletedOn.HasValue).ToList();
        }
        public Agent GetAgent(long id)
        {
            return _dataContext.Agents
                .Include(p => p.CommunicationDetail)
                                      .SingleOrDefault(i=>i.Id==id);
        }
        public Agent GetAgentByUserId(long userId)
        {
            return _dataContext.Agents
                .Include(p => p.CommunicationDetail)
                                        .SingleOrDefault(i => i.UserId == userId);
        }


        public SearchResult<Agent> SearchAgent(AgentSearchFilter filters, int pagesize, int count)
        {
            var result = new SearchResult<Agent>();
            IQueryable<Agent> query = _dataContext.Agents
                                        .Include(p => p.User)
                                        .Include(p => p.CommunicationDetail)
                                        .Where(p => !p.DeletedOn.HasValue);

            if (filters.CommunicationDetailId.HasValue)
                query=query.Where(p => p.CommunicationDetailId.Equals(filters.CommunicationDetailId));
            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.CommunicationDetail.Email.Equals(filters.Email));
            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.CommunicationDetail.Phone.Equals(filters.Phone));
            if (!String.IsNullOrEmpty(filters.DEDLicenseNumber))
                query = query.Where(p => p.DEDLicenseNumber.Equals(filters.DEDLicenseNumber));

            if (!String.IsNullOrEmpty(filters.FirstName))
                query = query.Where(p => p.FirstName.Equals(filters.FirstName));

            if (filters.IsListingMember)
                query = query.Where(p => p.IsListingMember.Equals(filters.IsListingMember));

            if (!String.IsNullOrEmpty(filters.LastName))
                query = query.Where(p => p.LastName.Equals(filters.LastName));

            if (!String.IsNullOrEmpty(filters.RERARegistrationNumber))
                query = query.Where(p => p.RERARegistrationNumber.Equals(filters.RERARegistrationNumber));

            if (filters.UserId.HasValue)
                query = query.Where(p => p.UserId==filters.UserId);

            result.Items = query.OrderBy(p => p.FirstName)
                .Skip(pagesize * count).Take(1).ToList();
            
            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pagesize, 1, query.Count());
            return result;
        }

        public int GetAgentCountByUser(long userId)
        {
            return _dataContext.Agents
                .Count(c => c.CreatedBy == userId);
        }
    }
}
