using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using Common.Data.Models;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Model.Agent;

namespace PropznetCommon.Features.CRM.DAL
{
    public class AgentInfoRepository : GenericRepository<AgentInfo>, IAgentInfoRepository
    {
        readonly ICRMDataContext _dataContext;
        public AgentInfoRepository(ICRMDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<AgentInfo> GetAllAgentInfoByUserId(long userId)
        {
            return _dataContext.AgentInfos
                .Where(i => i.UserId == userId && !i.DeletedOn.HasValue)
                .Include(u => u.User)
                .Include(u => u.User.Person)
                .ToList();
        }
        public IList<AgentInfo> GetAllAgentInfo()
        {
            return _dataContext.AgentInfos
                .Where(i => !i.DeletedOn.HasValue)
                .Include(u => u.User)
                .Include(u => u.User.Person)
                .ToList();
        }
        public AgentInfo GetAgentInfo(long id)
        {
            return _dataContext.AgentInfos
                               .Include(u => u.User)
                               .Include(u => u.User.Person)
                               .SingleOrDefault(i => i.Id == id);
        }
        public AgentInfo GetAgentInfoByUserId(long userId)
        {
            return _dataContext.AgentInfos
                               .Include(u => u.User)
                               .Include(u => u.User.Person)
                               .SingleOrDefault(i => i.UserId == userId);
        }
        public SearchResult<AgentInfo> SearchAgentInfo(AgentSearchFilter filters, int pagesize, int count)
        {
            var result = new SearchResult<AgentInfo>();
            IQueryable<AgentInfo> query = _dataContext.AgentInfos
                                        .Where(p => !p.DeletedOn.HasValue)
                                        .Include(p => p.User)
                                        .Include(u => u.User.Person)
                                        .OrderByDescending(x => x.CreatedOn);

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.User.Person.Email.Equals(filters.Email));
            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.User.Person.PhoneNo.Equals(filters.Phone));
            if (!String.IsNullOrEmpty(filters.DEDLicenseNumber))
                query = query.Where(p => p.DEDLicenseNumber.Equals(filters.DEDLicenseNumber));

            if (!String.IsNullOrEmpty(filters.FirstName))
                query = query.Where(p => p.User.Person.Equals(filters.FirstName));

            if (filters.IsListingMember)
                query = query.Where(p => p.IsListingMember.Equals(filters.IsListingMember));

            if (!String.IsNullOrEmpty(filters.LastName))
                query = query.Where(p => p.User.Person.LastName.Equals(filters.LastName));

            if (!String.IsNullOrEmpty(filters.RERARegistrationNumber))
                query = query.Where(p => p.RERARegistrationNumber.Equals(filters.RERARegistrationNumber));

            if (filters.UserId.HasValue)
                query = query.Where(p => p.UserId == filters.UserId);

            result.Items = query.OrderBy(p => p.User.Person.FirstName)
                .Skip(pagesize * count).Take(1).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pagesize, 1, query.Count());
            return result;
        }
        public int GetAgentInfoCountByUser(long userId)
        {
            return _dataContext.AgentInfos
                .Count(c => c.CreatedByUserId == userId);
        }
        public bool DeleteAgentInfo(long id)
        {
            var agent = _dataContext.AgentInfos
                        .FirstOrDefault(i => i.Id == id);
            agent.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}