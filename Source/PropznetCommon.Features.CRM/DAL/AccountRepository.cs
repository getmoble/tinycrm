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
using PropznetCommon.Features.CRM.Model.Account;

namespace PropznetCommon.Features.CRM.DAL
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public AccountRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Account> GetAllAccountsByUserId(long userId)
        {
            return _dataContext.Accounts
                                .Where(i => (i.CreatedByUserId == userId || i.AssignedToUserId == userId) && !i.DeletedOn.HasValue)
                                .Include(a => a.Person)
                                .Include(a => a.AssignedToUser)
                                .Include(p => p.AssignedToUser.Person)
                                .OrderByDescending(x => x.CreatedOn)
                                .ToList();
        }
        public IList<Account> GetAllAccounts()
        {
            return _dataContext.Accounts
                            .Where(i => !i.DeletedOn.HasValue)
                            .Include(a => a.Person)
                            .Include(a => a.AssignedToUser)
                            .Include(p => p.AssignedToUser.Person)
                            .OrderByDescending(x => x.CreatedOn)
                            .ToList();
        }
        public Account GetAccount(long id)
        {
            return _dataContext.Accounts
                .Where(i => i.Id == id && !i.DeletedOn.HasValue)
                .Include(a => a.AssignedToUser)
                .Include(p => p.AssignedToUser.Person)
                .Include(a => a.Person)
                .SingleOrDefault();
        }
        public SearchResult<Account> SearchAccount(AccountSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Account>();
            // PagingInfo pagingInfo = new PagingInfo(pageSize);
            IQueryable<Account> query = _dataContext.Accounts
                                        .Where(p => !p.DeletedOn.HasValue)
                                        .Include(p => p.AssignedToUser)
                                        .Include(p => p.AssignedToUser.Person)
                                        .Include(p => p.Person)
                                        .OrderByDescending(x => x.CreatedOn);

            if (filters.AgentId.HasValue)
                query = query.Where(p => p.AssignedToUserId == filters.AgentId);

            if (!String.IsNullOrEmpty(filters.Name))
                query = query.Where(p => p.Person.FirstName.Contains(filters.Name));

            if (!String.IsNullOrEmpty(filters.Address))
                query = query.Where(p => p.Person.Address.Contains(filters.Address));

            if (!String.IsNullOrEmpty(filters.Comments))
                query = query.Where(p => p.Description.Contains(filters.Comments));

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.Person.Email.Contains(filters.Email));

            if (!String.IsNullOrEmpty(filters.Industry))
                query = query.Where(p => p.Industry.Contains(filters.Industry));

            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.Person.PhoneNo.Contains(filters.Phone));

            if (!String.IsNullOrEmpty(filters.Website))
                query = query.Where(p => p.Person.Website.Contains(filters.Website));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedByUserId == filters.UserId);
            if (pageSize == 0 || page == 0)
                result.Items = query.OrderBy(p => p.Person.FirstName).ToList();
            else
                result.Items = query.OrderBy(p => p.Person.FirstName)
                                .Skip(pageSize * page).Take(page).ToList();

            result.Items = query.ToList();

            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());

            return result;

        }
        public int GetAccountCountByUser(long userId)
        {
            return _dataContext.Accounts.Count(c => c.CreatedByUserId == userId);
        }
        public bool CheckAccountExist(string accountname)
        {
            return _dataContext.Accounts.Any(a => a.Person.FirstName == accountname);
        }
        public bool DeleteAccount(long id)
        {
            var account = _dataContext.Accounts
                                    .FirstOrDefault(i => i.Id == id);
            account.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}