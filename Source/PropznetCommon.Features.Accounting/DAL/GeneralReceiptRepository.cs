using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class GeneralReceiptRepository : GenericRepository<GeneralReceipt>, IGeneralReceiptRepository
    {
        readonly IAccountingDataContext _dataContext;
        public GeneralReceiptRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<GeneralReceipt> GetAllAccounts(long customerId)
        {
            return _dataContext.GeneralReceipts.Include("IncomeAccount").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();

        }
        public GeneralReceipt GetAccountById(long incomeHeadId)
        {
            return _dataContext.GeneralReceipts.Include("IncomeAccount").Include("PayingAccount").FirstOrDefault(r => r.Id == incomeHeadId && r.DeletedOn == null);
        }

    }
}
