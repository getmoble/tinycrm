using Common.Auth.SingleTenant.Entities;
using Common.Security;
using System;

namespace CRMLite.Data.Data.Seeders
{
    public static class UserSeeder
    {
        public static void Seed(DataContext context)
        {
            var newAdminAccessRule = AccessRule.CreateNewUserAccessRule(true);
            context.AccessRules.Add(newAdminAccessRule);
            context.SaveChanges();

            var newUserAccessRule = AccessRule.CreateNewUserAccessRule(true);
            context.AccessRules.Add(newUserAccessRule);
            context.SaveChanges();

            var adminRole = new Role { Name = "Admin" };
            context.Roles.Add(adminRole);
            context.SaveChanges();

            var userRole = new Role { Name = "User" };
            context.Roles.Add(userRole);
            context.SaveChanges();

            var agentRole = new Role { Name = "Agent" };
            context.Roles.Add(agentRole);
            context.SaveChanges();

            var tenantRole = new Role { Name = "Tenant" };
            context.Roles.Add(tenantRole);
            context.SaveChanges();

            var ownerRole = new Role { Name = "Owner" };
            context.Roles.Add(ownerRole);
            context.SaveChanges();

            var person = new Person { FirstName = "Sreenath", LastName = "Kezhakkedath", PhoneNo = "+4253014269", RefId = new Guid().ToString("N") };
            context.Persons.Add(person);
            context.SaveChanges();

            var admin = new User { Username = "sreenath@logiticks.com", Name = "Sreenath", Password = HashHelper.Hash("pass@123"), PersonId = person.Id, AccessRuleId = newAdminAccessRule.Id };
            context.Users.Add(admin);
            context.SaveChanges();

            var newPerson = new Person { FirstName = "Mark", LastName = " ", PhoneNo = "", RefId = new Guid().ToString("N") };
            context.Persons.Add(newPerson);
            context.SaveChanges();

            var newuser = new User { Username = "mark@logiticks.com", Name = "Mark", Password = HashHelper.Hash("pass@123"), PersonId = newPerson.Id, AccessRuleId = newAdminAccessRule.Id, CreatedByUserId = admin.Id };
            context.Users.Add(newuser);
            context.SaveChanges();

            var newPerson2 = new Person { FirstName = "Dhanya", LastName = "Viswanadh ", PhoneNo = "", RefId = new Guid().ToString("N") };
            context.Persons.Add(newPerson2);
            context.SaveChanges();

            var newuser1 = new User { Username = "dhanya@logiticks.com", Name = "Dhanya", Password = HashHelper.Hash("pass@123"), PersonId = newPerson2.Id, AccessRuleId = newAdminAccessRule.Id, CreatedByUserId = admin.Id };
            context.Users.Add(newuser1);
            context.SaveChanges();

            var newPerson3 = new Person { FirstName = "Jithin", LastName = "Sreedhar ", PhoneNo = "9895981814", RefId = new Guid().ToString("N") };
            context.Persons.Add(newPerson3);
            context.SaveChanges();

            var newuser2 = new User { Username = "jithin@logiticks.com", Name = "Jithin", Password = HashHelper.Hash("pass@123"), PersonId = newPerson3.Id, AccessRuleId = newAdminAccessRule.Id, CreatedByUserId = admin.Id };
            context.Users.Add(newuser2);
            context.SaveChanges();
        }
    }
}
