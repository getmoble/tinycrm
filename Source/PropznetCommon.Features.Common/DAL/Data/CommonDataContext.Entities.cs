using System.Data.Entity;
using PropznetCommon.Features.Common.Entities;

namespace PropznetCommon.Features.Common.DAL.Data
{
    public partial class CommonDataContext 
    {
        public DbSet<PotentialAmenityMap> PotentialAmenityMaps { get; set; }
        public DbSet<PotentialPropertyMap> PotentialPropertyMaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
