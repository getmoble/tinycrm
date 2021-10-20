using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IAccountCategoryService
    {
        AccountCategory Create(string name, AccountTypes accountType, long parentId, string remarks);
        AccountCategory Get(long accountId);
        List<AccountCategory> GetAll();
        AccountCategory Update(string name, long parentId, string remarks, long id);
    }
}