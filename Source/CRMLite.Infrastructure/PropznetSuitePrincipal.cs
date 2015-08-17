using System.Collections.Generic;
using System.Security.Principal;

namespace CRMLite.Infrastructure
{
    public class CRMLitePrincipal: IPrincipal
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Key { get; set; }
        //public long CustomerId { get; set; }
        public string Email { get; set; }
        public IList<int> PermissionCodes { get; set; }
        public long[] RoleId { get; set; }
        public string Image { get; set; }
        public CRMLitePrincipal()
        { }
        public CRMLitePrincipal(string name)
        {
            PermissionCodes = new List<int>();
            Name = name;
            Identity = new GenericIdentity(name);
        }

        public bool IsInRole(string role)
        {
            if (Role == role)
                return true;
            else
                return false;
        }
        public IIdentity Identity { get; private set; }
    }
}