using System;
using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IGeneralReceiptService
    {
        GeneralReceipt CreateAccount(DateTimeOffset dateOfReceipt, string party, string reference, string description, long incomeHeadId, long payingAccountId, double amount, string chequeOrDDNo, DateTimeOffset? chequeOrDDDate, EntryType entryType);

        GeneralReceipt UpdateAccount(DateTimeOffset dateOfReceipt, string party, string reference, string description, long incomeHeadId, long payingAccountId, double amount, string chequeDdNo, DateTimeOffset? chequeDdDate, EntryType entryType, long id);

        IList<GeneralReceipt> GetAllAccounts();
        List<AccountHead> GetAllIncomeHead();
        List<AccountHead> GetAllPayingAccountList();
        GeneralReceipt Get(long id);
        bool Delete(long id);
    }
}