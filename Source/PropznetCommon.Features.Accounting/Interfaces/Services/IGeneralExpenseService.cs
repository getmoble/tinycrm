using System;
using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IGeneralExpenseService
    {
        GeneralExpense CreateAccount(DateTimeOffset dateOfPay, string party, string reference, string description, long expenseHeadId, long payingAccountId, double amount, string chequeOrDDNo, DateTimeOffset? chequeOrDDDate, EntryType entryType);

        GeneralExpense UpdateAccount(DateTimeOffset dateOfPay, string party, string reference, string description, long expenseHeadId, long payingAccountId, double amount, string chequeDdNo, DateTimeOffset? chequeDdDate, EntryType entryType, long id);

        IList<GeneralExpense> GetAllAccounts();
        List<AccountHead> GetAllExpenseHead();
        List<AccountHead> GetAllPayingAccountList();
        GeneralExpense Get(long id);
        bool Delete(long id);
    }
}