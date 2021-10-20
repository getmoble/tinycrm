using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Account;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IAccountRepository:IGenericRepository<Account>
    {
        SearchResult<Account> SearchAccount(AccountSearchFilter filter, int pageSize, int page);
        IList<Account> GetAllAccountsByUserId(long userId);
        IList<Account> GetAllAccounts();
        Account GetAccount(long id);
        int GetAccountCountByUser(long userId);
        bool CheckAccountExist(string accountname);
        bool DeleteAccount(long id);
    }
}
