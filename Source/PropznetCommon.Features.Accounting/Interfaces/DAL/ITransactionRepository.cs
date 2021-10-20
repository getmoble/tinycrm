using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        void Delete(long id, long userId);
    }
}