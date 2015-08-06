using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.CRM.Entities;
using System.Collections.Generic;

namespace CRMLite.Data.Data.Seeders
{
    public static class UserSeeder
    {
        public static void Seed(DataContext context)
        {
            var adminUser = new User { CommunicationDetailId = 1, DEDLicenseNumber = "D7878778", FirstName = "Admin", Image = "Person-Dummy.jpg", IsListingMember = true, LastName = "Shastri", RERARegistrationNumber = "R6446464", RefId = "A01", UserId = 1 };
            context.Users.Add(adminUser);
            context.SaveChanges();

            var userUser = new User { CommunicationDetailId = 1, DEDLicenseNumber = "D7845578", FirstName = "Anu", Image = "Person-Dummy.jpg", IsListingMember = true, LastName = "Sharma", RERARegistrationNumber = "R6422264", RefId = "A02", UserId = 2 };
            context.Users.Add(userUser);
            context.SaveChanges();

            var User = new List<User>
            {
               //new User{ CommunicationDetailId=1,DEDLicenseNumber="D7878778",FirstName="Admin",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Shastri",RERARegistrationNumber="R6446464",RefId="Admin"},
               new User{ CommunicationDetailId=2,DEDLicenseNumber="D7323778",FirstName="Piya",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Sharma",RERARegistrationNumber="R6333364",RefId="A03",CreatedBy=1},
               new User{ CommunicationDetailId=1,DEDLicenseNumber="D7890908",FirstName="Lakshmi",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Anuj",RERARegistrationNumber="R6447777",RefId="A04",CreatedBy=1},
               new User{ CommunicationDetailId=3,DEDLicenseNumber="D7123228",FirstName="Ajmal",Image="Person-Dummy.jpg",IsListingMember=true,LastName="Amal",RERARegistrationNumber="R6448888",RefId="A05",CreatedBy=1},
               new User{ CommunicationDetailId=3,DEDLicenseNumber="D7333278",FirstName="Divyanka",Image="Person-Dummy.jpg",IsListingMember=true,LastName="A K",RERARegistrationNumber="R6987654",RefId="A06",CreatedBy=1},
               new User{ CommunicationDetailId=1,DEDLicenseNumber="D7675678",FirstName="Reenu",Image="Person-Dummy.jpg",IsListingMember=true,LastName="M P",RERARegistrationNumber="R6445678",RefId="A07",CreatedBy=1}
            };
            User.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}
