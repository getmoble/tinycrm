using System.Data.Entity;
using PropznetCommon.Features.Common.Interfaces.Data;

namespace PropznetCommon.Features.Common.DAL.Data
{
    public partial class CommonDataContext : DbContext, ICommonDataContext
    {
        public CommonDataContext()
            : base("Common")
        {
            Database.SetInitializer(new DataSeeder());
            Database.Initialize(true);
            Configuration.ProxyCreationEnabled = false;
        }

    }
}