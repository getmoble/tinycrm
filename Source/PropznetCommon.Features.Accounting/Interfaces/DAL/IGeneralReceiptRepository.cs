using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface IGeneralReceiptRepository : IGenericRepository<GeneralReceipt>
    {
        IList<GeneralReceipt> GetAllAccounts(long customerId);
        GeneralReceipt GetAccountById(long incomeHeadId);
    }
}