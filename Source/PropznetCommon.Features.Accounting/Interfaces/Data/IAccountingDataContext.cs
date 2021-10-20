using System.Data.Entity;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.Data
{
    public interface IAccountingDataContext : IDbContext
    {
        DbSet<AccountHead> AccountHeads { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionLineItem> TransactionLineItems { get; set; }
        DbSet<AccountCategory> AccountCategory { get; set; }
        DbSet<GeneralExpense> GeneralExpenses { get; set; }
        DbSet<GeneralReceipt> GeneralReceipts { get; set; }
        DbSet<Contra> Contra { get; set; }
        DbSet<Journal> Journal { get; set; }
        DbSet<OpeningBalance> OpeningBalances { get; set; }
        DbSet<Invoice> Invoices { get; set; }
    }
}
