using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface IGeneralExpenseRepository : IGenericRepository<GeneralExpense>
    {
        IList<GeneralExpense> GetAllAccounts(long customerId);
        GeneralExpense GetAccountById(long expenseHeadId);
    }
}