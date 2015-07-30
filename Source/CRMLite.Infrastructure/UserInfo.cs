using System.Collections.Generic;
using Common.Auth.SingleTenant.Entities;

namespace CRMLite.Infrastructure
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RefId { get; set; }
        public string Role { get; set; }
        public long[] RoleId { get; set; }
        public string Email { get; set; }
        public IList<int> PermissionCodes { get; set; }
        public string Image { get; set; }
        public UserInfo()
        { }
        public static UserInfo GetInstance(User user)
        {
            var info = new UserInfo
            {
                Id = user.Id,
                RefId = user.RefId,
                Email = user.Username,
                Name = user.Person.FirstName
            };
            return info;
        }
    }
}