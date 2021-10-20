using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IOpeningBalanceService
    {
        OpeningBalance CreateAccount(string description, double amount, long transactionId);
        OpeningBalance UpdateAccount(string description, double amount, long? id, long transactionId);
        IList<OpeningBalance> GetAllAccounts();
        IList<AccountHead> AssetAndLiabilityAccount();
        OpeningBalance Get(long? id);
        bool Delete(long id);
    }
}