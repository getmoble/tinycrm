using System.Collections.Generic;
using System.Linq;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Services;

namespace PropznetCommon.Features.Accounting.Services
{
    public class AccountCategoryService : IAccountCategoryService
    {

        readonly IAccountCategoryRepository _categoryRepository;
        readonly IUnitOfWork _unitOfWork;

        public AccountCategoryService(IAccountCategoryRepository accountCategoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = accountCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public AccountCategory Create(string name, AccountTypes accountType, long parentId, string remarks)
        {
            var newAccountCategory = new AccountCategory
            {
                Name = name,
                AccountType = accountType,
                ParentId = parentId,
                Remarks = remarks
            };
            newAccountCategory = _categoryRepository.Create(newAccountCategory);
            _unitOfWork.Commit();
            return newAccountCategory;
        }

        public AccountCategory Get(long accountId)
        {
            return _categoryRepository.GetBy(p => p.Id == accountId);
        }

        public List<AccountCategory> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }
        public AccountCategory Update(string name, long parentId, string remarks, long id)
        {
            var accountCategory = _categoryRepository.GetBy(i => i.Id == id);
            accountCategory.Name = name;
            accountCategory.ParentId = parentId;
            accountCategory.Remarks = remarks;
            _categoryRepository.Update(accountCategory);
            _unitOfWork.Commit();
            return accountCategory;
        }
    }
}
