using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface IAccountHeadRepository : IGenericRepository<AccountHead>
    {
        IList<AccountHead> GetAllAccounts(long customerId);
        IList<AccountHead> GetAllAccountHeads(long customerId);
        AccountHead GetAccountById(long accountHeadId);
        IList<AccountHead> GetAllExpenseHead(long customerId);
        IList<AccountHead> GetAllIncomeHead(long customerId);
        IList<AccountHead> GetAllPayingAccounts(long customerId);
        IList<AccountHead> NonTransactionAccounts(long customerId);
        IList<AccountHead> AssetAndLiabilityAccount(long customerId);
        IList<AccountHead> GetAllRecieveAccounts(long customerId);
    }
}