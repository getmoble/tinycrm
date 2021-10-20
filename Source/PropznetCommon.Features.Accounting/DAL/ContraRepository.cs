using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class ContraRepository : GenericRepository<Contra>, IContraRepository
    {
        readonly IAccountingDataContext _dataContext;
        public ContraRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<Contra> GetAllAccounts(long customerId)
        {
            return _dataContext.Contra.Include("FromAccount").Include("ToAccount").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();

        }
        public Contra GetAccountById(long contraId)
        {
            return _dataContext.Contra.Include("FromAccount").Include("ToAccount").FirstOrDefault(r => r.Id == contraId && r.DeletedOn == null);
        }

    }
}
