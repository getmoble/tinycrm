using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface IContraRepository : IGenericRepository<Contra>
    {
        IList<Contra> GetAllAccounts(long customerId);
        Contra GetAccountById(long contraId);
    }
}