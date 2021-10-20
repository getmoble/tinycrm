using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Account;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IAccountService
    {
        Account CreateAccount(AccountModel accountModel);
        bool UpdateAccount(AccountModel accountModel);
        Account GetAccount(long id);
        IList<Account> GetAllAccountsByUserId(long userId, IList<int> permissionCodes);
        IList<Account> GetAllAccounts();
        SearchResult<Account> Search(AccountSearchFilter filters, int pageSize, int page);
        bool DeleteAccount(long id);
        bool CheckAccountExist(string accountname);
    }
}
