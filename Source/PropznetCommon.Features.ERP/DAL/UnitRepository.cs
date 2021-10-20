using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public Unit GetUnitById(long id)
        {
            return _dataContext.Units
                 .Include(i => i.Property)
                 .Include(l => l.Sale)
                 .Include(p => p.CommunicationDetails)
                 .Include(p => p.CommunicationDetails.Country)
                 .FirstOrDefault(i => i.Id == id && !i.DeletedOn.HasValue);
        }
        public IList<Unit> GetAllUnits()
        {
            return _dataContext.Units
                     .Where(u => !u.DeletedOn.HasValue)
                     .OrderByDescending(x => x.CreatedOn)
                     .Include(i => i.Property)
                     .Include(l => l.Sale)
                     .ToList();
        }
        public IList<Unit> GetAllUnits(IList<long> unitId)
        {
            return _dataContext.Units
                .Where(p => unitId.Contains(p.Id))
                .OrderByDescending(x => x.CreatedOn)
                .Include(i => i.CommunicationDetails)
                .Include(p => p.CommunicationDetails.City)
                .Include(k => k.Sale)
                .ToList();
        }
        public bool DeleteUnit(long id)
        {
            var unit= _dataContext.Units.FirstOrDefault(i => i.Id == id);
            unit.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}