using CRMLite.Infrastructure.Enum;
using System.Linq;

namespace CRMLite.Infrastructure
{
    public class RoleChecker
    {
        public static bool CheckRole(long[] roleId, RoleIds role)
        {
            if (roleId != null)
            {
                int roleid = (int)role;
                if (roleId.Contains(roleid))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}