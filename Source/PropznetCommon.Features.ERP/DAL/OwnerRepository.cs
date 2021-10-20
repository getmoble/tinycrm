using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Model.Owner;

namespace PropznetCommon.Features.ERP.DAL
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        readonly IERPDataContext _dataContext;
        public OwnerRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Owner> GetAllOwnersById(IList<long> ownersId)
        {
            return _dataContext.Owners
                .Include(u=>u.User)
                .Include(p=>p.User.Person)
                .Include(p => p.User.AccessRule)
                .Where(i => ownersId.Contains(i.Id))
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }
        public IList<Owner> GetAllOwners()
        {
            return _dataContext.Owners
                .Include(u => u.User)
                .Include(p => p.User.Person)
                .Include(p => p.User.AccessRule)
                .Where(i => !i.DeletedOn.HasValue)
                .OrderByDescending(x => x.CreatedOn)
                .Include(u => u.User).ToList();
        }
        public Owner GetOwnerByUserId(long userId)
        {
            return _dataContext.Owners
                .Include(u => u.User)
                .Include(p => p.User.Person)
                .Include(p => p.User.AccessRule)
                .SingleOrDefault(i => i.UserId == userId);
        }
        public Owner GetOwner(long id)
        {
            var owner = _dataContext.Owners
                .Include(u => u.User)
                .Include(p => p.User.Person)
                .Include(p => p.User.AccessRule)
                .FirstOrDefault(i => i.Id == id);
            return owner;
        }
        public bool DeleteOwner(long id)
        {
            var owner = _dataContext.Owners.FirstOrDefault(i => i.Id == id);
            if (owner != null) 
                owner.DeletedOn = DateTime.UtcNow;
            return true;
        }
        public SearchResult<Owner> SearchOwners(OwnerSearchFilter searchargumentFilter, int pagesize, int count)
        {
            var result = new SearchResult<Owner>();
            IQueryable<Owner> query = _dataContext.Owners
                                  .Include(u => u.User)
                                  .Include(p => p.User.Person)
                                  .Include(p => p.User.AccessRule)
                                  .Where(i => !i.DeletedOn.HasValue)
                                  .OrderByDescending(x => x.CreatedOn);


            if (!String.IsNullOrEmpty(searchargumentFilter.Email))
            {
                query = query.Where(p => p.User.Person.Company == searchargumentFilter.Email);
            }


            if (!String.IsNullOrEmpty(searchargumentFilter.FirstName))
            {
                query = query.Where
                    (p => p.User.Person.FirstName == searchargumentFilter.FirstName);
            }

            if (!String.IsNullOrEmpty(searchargumentFilter.LastName))
            {
                query = query.Where
                    (p => p.User.Person.LastName == searchargumentFilter.LastName);
            }

            if (searchargumentFilter.OwnerType.HasValue)
            {
                query = query.Where
                    (p => p.OwnerType == searchargumentFilter.OwnerType.Value);
            }

            if (!String.IsNullOrEmpty(searchargumentFilter.Phone))
            {
                query = query.Where
                    (p => p.User.Person.PhoneNo == searchargumentFilter.Phone);
            }

            if (searchargumentFilter.TaxEligible)
            {
                query = query.Where
                    (p => p.TaxEligible == searchargumentFilter.TaxEligible);
            }

            if (searchargumentFilter.CreatedFrom.HasValue && searchargumentFilter.CreatedTo.HasValue)
            {
                query = query.Where(p => p.CreatedOn >= searchargumentFilter.CreatedFrom
                    && p.CreatedOn <= searchargumentFilter.CreatedTo);
            }

            result.Items = query.OrderBy(p => p.User.Person.FirstName)
              .Skip(pagesize * count).Take(count).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pagesize, count, query.Count());
            return result;
        }
    }
}