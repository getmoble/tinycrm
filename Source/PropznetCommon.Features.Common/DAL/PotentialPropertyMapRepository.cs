using PropznetCommon.Features.Common.Interfaces.DAL;
using PropznetCommon.Features.Common.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PropznetCommon.Features.Common.Entities;

namespace PropznetCommon.Features.Common.DAL
{
    public class PotentialPropertyMapRepository : IPotentialPropertyMapRepository
    {
        readonly ICommonDataContext _dataContext;
        public PotentialPropertyMapRepository(ICommonDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePotentialPropertyMap(PotentialPropertyMap potentialPropertyMap)
        {
            _dataContext.PotentialPropertyMaps.Add(potentialPropertyMap);
            return true;
        }

        public IList<long> GetAllPropertyIdByPotentialId(long potentialId)
        {
            return _dataContext.PotentialPropertyMaps
                .Where(i => i.PotentialId == potentialId)
                .Select(i => i.PropertyId).Distinct().ToList();
        }

        public IList<PotentialPropertyMap> GetAllPropertyMapByPotentialId(long potentialId)
        {
            return _dataContext.PotentialPropertyMaps
              .Where(u => u.PotentialId == potentialId)
              .Include(i => i.Potential)
              .Include(p => p.Property).ToList();
        }

        public long GetPotentialIdByPropertyId(long PropertyId)
        {
            var potentialPropertyMap = _dataContext.PotentialPropertyMaps
                .SingleOrDefault(i => i.PropertyId == PropertyId);
                return potentialPropertyMap.PotentialId;
        }

        public bool DeletePotentialPropertyMap(long id)
        {
            var potentialPropertyMap = _dataContext.PotentialPropertyMaps
                                    .Where(i => i.Id == id).ToList();
            foreach (PotentialPropertyMap item in potentialPropertyMap)
            {
                _dataContext.PotentialPropertyMaps.Remove(item);
            }
            return true;
        }
    }
}
