using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IAccountHeadService
    {
        AccountHead CreateAccount(string name, long accountCategoryId, string description, double openingBalance, bool isTransaction);
        IList<AccountHead> GetAllAccounts();
        AccountHead Get(long id);
        AccountHead GetAllAccountId(long accountHeadId);
        List<AccountHead> GetAllReceivingAccountList();
        AccountHead UpdateAccountHead(string name, long accountCategoryId, string description, double openingBalance, bool isTransaction, long customerId, long id);
        bool Delete(long id);
    }
}