using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        readonly IAccountingDataContext _dataContext;
        public InvoiceRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<Invoice> GetAllAccounts(long customerId)
        {
            return _dataContext.Invoices.Include("IncomeAccount").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();

        }
        public Invoice GetAccountById(long incomeHeadId)
        {
            return _dataContext.Invoices.Include("IncomeAccount").Include("PayingAccount").FirstOrDefault(r => r.Id == incomeHeadId && r.DeletedOn == null);
        }
    }
}
