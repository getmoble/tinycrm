using System.Collections.Generic;
using CRMLite.Infrastructure.Enum;

namespace CRMLite.Infrastructure
{
    public class PermissionChecker
    {
        public static bool CheckPermission(IList<int> userPermissions, PermissionCodes permissionCode)
        {
            if (userPermissions != null)
            {
                int permissioncode = (int) permissionCode;
                if (userPermissions.Contains(permissioncode))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}