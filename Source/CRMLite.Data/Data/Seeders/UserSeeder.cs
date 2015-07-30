using System;
using System.Collections.Generic;
using Common.Auth.SingleTenant.Entities;
using Common.Security;

namespace CRMLite.Data.Data.Seeders
{
    public class UserSeeder
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

            var person = new Person { FirstName = "Admin", LastName = "Zeztate", PhoneNo = "9495925241", RefId = new Guid().ToString("N") };
            context.Persons.Add(person);
            context.SaveChanges();

            var newPerson = new Person { FirstName = "User", LastName = "Zeztate", PhoneNo = "9495925241", RefId = new Guid().ToString("N") };
            context.Persons.Add(newPerson);
            context.SaveChanges();


            var admin = new User { Username = "admin@logiticks.com", Name = "Admin", Password = HashHelper.Hash("admin"), PersonId = person.Id, AccessRuleId = newAdminAccessRule.Id };
            context.Users.Add(admin);
            context.SaveChanges();

            var newuser = new User { Username = "user@logiticks.com", Name = "User", Password = HashHelper.Hash("user"), PersonId = newPerson.Id, AccessRuleId = newUserAccessRule.Id, CreatedByUserId = admin.Id };
            context.Users.Add(newuser);
            context.SaveChanges();
        }
    }
}
