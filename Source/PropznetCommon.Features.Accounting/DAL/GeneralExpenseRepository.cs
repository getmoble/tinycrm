using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class GeneralExpenseRepository : GenericRepository<GeneralExpense>, IGeneralExpenseRepository
    {
        readonly IAccountingDataContext _dataContext;
        public GeneralExpenseRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<GeneralExpense> GetAllAccounts(long customerId)
        {
            return _dataContext.GeneralExpenses.Include("ExpenseAccount").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();

        }
        public GeneralExpense GetAccountById(long expenseHeadId)
        {
            return _dataContext.GeneralExpenses.Include("ExpenseAccount").Include("PayingAccount").FirstOrDefault(r => r.Id == expenseHeadId && r.DeletedOn == null);
        }
    }
}
