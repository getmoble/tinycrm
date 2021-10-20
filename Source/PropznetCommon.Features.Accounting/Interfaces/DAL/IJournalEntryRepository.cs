using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface IJournalEntryRepository : IGenericRepository<Journal>
    {
        IList<Journal> GetAllAccounts(long customerId);
        Journal GetAccountById(long contraId);
    }
}