using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface IOpeningBalanceRepository : IGenericRepository<OpeningBalance>
    {
        IList<OpeningBalance> GetAllAccounts(long customerId);
        OpeningBalance GetAccountById(long? id);
    }
}