using System;
using System.Data.Entity;
using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        readonly IAccountingDataContext _dataContext;
        public TransactionRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public void Delete(long id, long userId)
        {
            var transaction = GetBy(t => t.Id == id);
            transaction.CancelFlag = CancelFlag.Yes;
            transaction.DeletedOn = DateTime.Now;
            transaction.DeletedByUserId = userId;
            _dataContext.Entry(transaction).State = EntityState.Modified;
        }
    }
}
