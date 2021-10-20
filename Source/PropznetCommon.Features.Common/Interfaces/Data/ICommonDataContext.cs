using System.Data.Entity;
using Common.Data.Interfaces;
using PropznetCommon.Features.Common.Entities;

namespace PropznetCommon.Features.Common.Interfaces.Data
{
    public interface ICommonDataContext : IDbContext
    {
        DbSet<PotentialAmenityMap> PotentialAmenityMaps { get; set; }
        DbSet<PotentialPropertyMap> PotentialPropertyMaps { get; set; }
    }
}
