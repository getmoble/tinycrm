using Common.Data;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        readonly DataContext _dataContext;
        public AccountRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Account> GetAllAccountsByUserId(long userId, long agentId)
        {
            return _dataContext.Accounts.Include(a => a.CommunicationDetail)
                                        .Include(a => a.Agent)
                                        .Where(i => !i.DeletedOn.HasValue && i.CreatedBy == userId || i.AgentId == agentId)
                                        .ToList();
        }
        public IList<Account> GetAllAccounts()
        {
            return _dataContext.Accounts
                .Include(a => a.CommunicationDetail)
                .Include(a => a.Agent)
                .Where(i => !i.DeletedOn.HasValue).ToList();
        }
        public Account GetAccount(long id)
        {
            return _dataContext.Accounts
                .Include(a => a.Agent)
                .Include(a => a.CommunicationDetail)
                .SingleOrDefault(i =>i.Id==id && !i.DeletedOn.HasValue);
        }
        public SearchResult<Account> SearchAccount(AccountSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Account>();
           // PagingInfo pagingInfo = new PagingInfo(pageSize);
            IQueryable<Account> query = _dataContext.Accounts
                                        .Include(p => p.Agent)
                                        .Include(p => p.CommunicationDetail)
                                        .Where(p => !p.DeletedOn.HasValue);

            if (filters.AgentId.HasValue)
                query = query.Where(p => p.AgentId == filters.AgentId);

            if (!String.IsNullOrEmpty(filters.Name))
                query = query.Where(p => p.Name.Contains(filters.Name));

            if (!String.IsNullOrEmpty(filters.Address))
                query = query.Where(p => p.CommunicationDetail.Address.Contains(filters.Address));

            if (!String.IsNullOrEmpty(filters.Comments))
                query = query.Where(p => p.Comments.Contains(filters.Comments));

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.CommunicationDetail.Email.Contains(filters.Email));

            if (!String.IsNullOrEmpty(filters.Industry))
                query = query.Where(p => p.Industry.Contains(filters.Industry));

            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.CommunicationDetail.Phone.Contains(filters.Phone));

            if (!String.IsNullOrEmpty(filters.Website))
                query = query.Where(p => p.CommunicationDetail.Website.Contains(filters.Website));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedBy == filters.UserId);
            if (pageSize == 0 || page == 0)
                result.Items = query.OrderBy(p => p.Name).ToList();
            else
                result.Items = query.OrderBy(p => p.Name)
                                .Skip(pageSize * page).Take(page).ToList();

            result.Items = query.ToList();

            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());

            return result;

        }

        public int GetAccountCountByUser(long userId)
        {
            return _dataContext.Accounts.Count(c => c.CreatedBy == userId);
        }
        public bool CheckAccountExist(string accountname)
        {
            return _dataContext.Accounts.Any(a => a.Name == accountname);
        }
    }
}