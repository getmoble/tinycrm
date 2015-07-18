using Common.Auth.SingleTenant.Entities;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Infrastructure
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RefId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public IList<int> PermissionCodes { get; set; }
        public string Image { get; set; }

        public static UserInfo GetInstance(User user)
        {
            var info = new UserInfo
            {
                Id = user.Id,
                RefId = user.RefId,
                Email = user.Username,
                Name=user.Person.FirstName
            };
            return info;
        }
    }
}