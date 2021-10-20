using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        IList<Invoice> GetAllAccounts(long customerId);
        Invoice GetAccountById(long incomeHeadId);
    }
}