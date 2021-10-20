using System;
using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IContraService
    {
        Contra CreateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType);
        Contra UpdateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType, long id);
        IList<Contra> GetAllAccounts();
        IList<AccountHead> GetAllPayingAccountList();
        Contra Get(long id);
        bool Delete(long id);
    }
}