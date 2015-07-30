using CRMLite.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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