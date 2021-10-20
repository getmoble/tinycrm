using System;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface ITransactionService
    {
        void Delete(long transactionId);
        Transaction Create(DateTimeOffset dateOfTransaction, string title, string description, EntryType entryType);
        void Update(long transactionId);
        void UpdateLineItem(long transactionId);
        void LineItemCreate(long transactionId, long debitAccount, long creditAccount, double amount, CancelFlag flag);
    }
}