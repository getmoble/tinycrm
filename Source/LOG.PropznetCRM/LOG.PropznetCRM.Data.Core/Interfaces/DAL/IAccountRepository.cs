using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Account;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface IAccountRepository:IGenericRepository<Account>
    {
        SearchResult<Account> SearchAccount(AccountSearchFilter filter, int pageSize, int page);
        IList<Account> GetAllAccountsByUserId(long userId,long agentId);
        IList<Account> GetAllAccounts();
        Account GetAccount(long id);
        int GetAccountCountByUser(long userId);
        bool CheckAccountExist(string accountname);
    }
}
