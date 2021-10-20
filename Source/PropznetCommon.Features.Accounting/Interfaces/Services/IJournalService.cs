using System;
using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IJournalService
    {
        Journal CreateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType);

        Journal UpdateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType, long id);

        IList<Journal> GetAllAccounts();
        IList<AccountHead> NonTransactionAccount();
        Journal Get(long id);
        bool Delete(long id);
    }
}