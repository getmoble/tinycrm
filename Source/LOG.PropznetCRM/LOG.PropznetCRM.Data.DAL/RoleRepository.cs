using LOG.PropznetCRM.Data.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Data;

namespace LOG.PropznetCRM.Data.DAL
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        readonly DataContext _context;
        public RoleRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}