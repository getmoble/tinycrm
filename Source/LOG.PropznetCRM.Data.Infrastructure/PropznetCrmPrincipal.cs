using System.Collections.Generic;
using System.Security.Principal;

namespace LOG.PropznetCRM.Data.Infrastructure
{
    public class CRMPrincipal : IPrincipal
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Key { get; set; }
        public long CustomerId { get; set; }
        public string Email { get; set; }
        public IList<int> PermissionCodes { get; set; }
        public string Image { get; set; }
        public CRMPrincipal()
        { }
        public CRMPrincipal(string name)
        {
            PermissionCodes = new List<int>();

            Name = name;
            Identity = new GenericIdentity(name);
        }

        public bool IsInRole(string role)
        {
            return Role == role;
        }

        public IIdentity Identity { get; private set; }
    }
}