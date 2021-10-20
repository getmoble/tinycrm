using System;
using System.Collections.Generic;
using System.Data.Entity;
using Common.Auth.SingleTenant.Entities;
using Common.Security;
using Common.Settings.Entities;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.DAL.Data
{
    public class DataSeeder : DropCreateDatabaseIfModelChanges<ERPDataContext>
    {
        protected override void Seed(ERPDataContext context)
        {
            //List<UnitType> unitTypeList = new List<UnitType>();
            //var unitType = new UnitType
            //{
            //    Name = "Apartment"
            //};
            //unitTypeList.Add(unitType);
            //var unitType1 = new UnitType
            //{
            //    Name = "Villa"
            //};
            //unitTypeList.Add(unitType1);
            //var unitType2 = new UnitType
            //{
            //    Name = "Land"
            //};
            //unitTypeList.Add(unitType2);
            //var unitType3 = new UnitType
            //{
            //    Name = "Office"
            //};
            //unitTypeList.Add(unitType3);
            //var unitType4 = new UnitType
            //{
            //    Name = "Retail"
            //};
            //unitTypeList.Add(unitType4);
            //var unitType5 = new UnitType
            //{
            //    Name = "Hotel Apartment"
            //};
            //unitTypeList.Add(unitType5);
            //var unitType6 = new UnitType
            //{
            //    Name = "Warehouse"
            //};
            //unitTypeList.Add(unitType6);
            //var unitType7 = new UnitType
            //{
            //    Name = "Land commercial"
            //};
            //unitTypeList.Add(unitType7);
            //var unitType8 = new UnitType
            //{
            //    Name = "Labour Camp"
            //};
            //unitTypeList.Add(unitType8);
            //var unitType9 = new UnitType
            //{
            //    Name = "Residential Building"
            //};
            //unitTypeList.Add(unitType9);
            //var unitType10 = new UnitType
            //{
            //    Name = "Multiple Sale Units"
            //};
            //unitTypeList.Add(unitType10);
            //var unitType11 = new UnitType
            //{
            //    Name = "Land Residential"
            //};
            //unitTypeList.Add(unitType11);
            //var unitType12 = new UnitType
            //{
            //    Name = "Commercial Full Building"
            //};
            //unitTypeList.Add(unitType12);
            //var unitType13 = new UnitType
            //{
            //    Name = "Penthouse"
            //};
            //unitTypeList.Add(unitType13);
            //var unitType14 = new UnitType
            //{
            //    Name = "Duplex"
            //};
            //unitTypeList.Add(unitType14);
            //var unitType15 = new UnitType
            //{
            //    Name = "Loft Apartment"
            //};
            //unitTypeList.Add(unitType15);
            //var unitType16 = new UnitType
            //{
            //    Name = "Town House"
            //};
            //unitTypeList.Add(unitType16);
            //var unitType17 = new UnitType
            //{
            //    Name = "Hotel"
            //};
            //unitTypeList.Add(unitType17);
            //var unitType18 = new UnitType
            //{
            //    Name = "Land Mixed use"
            //};
            //unitTypeList.Add(unitType18);
            //var unitType19 = new UnitType
            //{
            //    Name = "Compound"
            //};
            //unitTypeList.Add(unitType19);
            //var unitType20 = new UnitType
            //{
            //    Name = "Half Floor"
            //};
            //unitTypeList.Add(unitType20);
            //var unitType21 = new UnitType
            //{
            //    Name = "Full Floor"
            //};
            //unitTypeList.Add(unitType21);
            //var unitType22 = new UnitType
            //{
            //    Name = "Commercial Villa"
            //};
            //unitTypeList.Add(unitType22);

            //foreach (UnitType ut in unitTypeList)
            //{
            //    context.UnitTypes.Add(ut);
            //    context.SaveChanges();
            //}

            //var logoSetting = new Setting { Key = "logo", Value = "logo.png", CreatedOn = DateTime.UtcNow, DefaultValue = "props-logo.png" };
            //context.Settings.Add(logoSetting);
            //context.SaveChanges();

            //var pagingSetting = new Setting { Key = "pagingsize", Value = "20", CreatedOn = DateTime.UtcNow, DefaultValue = "20" };
            //context.Settings.Add(pagingSetting);
            //context.SaveChanges();

            //var newAdminAccessRule = AccessRule.CreateNewUserAccessRule(true);
            //context.AccessRules.Add(newAdminAccessRule);
            //context.SaveChanges();

            //var newUserAccessRule = AccessRule.CreateNewUserAccessRule(true);
            //context.AccessRules.Add(newUserAccessRule);
            //context.SaveChanges();

            //var adminRole = new Role { Name = "Admin" };
            //context.Roles.Add(adminRole);
            //context.SaveChanges();

            //var userRole = new Role { Name = "User" };
            //context.Roles.Add(userRole);
            //context.SaveChanges();


            //var person = new Person { FirstName = "Admin", LastName = "Zeztate", PhoneNo = "9495925241", RefId = new Guid().ToString("N") };
            //context.Persons.Add(person);
            //context.SaveChanges();

            //var newPerson = new Person { FirstName = "User", LastName = "Zeztate", PhoneNo = "9495925241", RefId = new Guid().ToString("N") };
            //context.Persons.Add(newPerson);
            //context.SaveChanges();


            //var admin = new User { Username = "admin@zeztate.com", Name = "Admin", Password = HashHelper.Hash("admin"), PersonId = person.Id, AccessRuleId = newAdminAccessRule.Id };
            //context.Users.Add(admin);
            //context.SaveChanges();

            //var newuser = new User { Username = "user@zeztate.com", Name = "User", Password = HashHelper.Hash("user"), PersonId = newPerson.Id, AccessRuleId = newUserAccessRule.Id, CreatedByUserId = admin.Id };
            //context.Users.Add(newuser);
            //context.SaveChanges();

            //var owner = new Owner
            //{
            //    Address = "Kalavath Rd, NH Bye Pass, Near Medical Centre, Chakkalakkal, Palarivattom, Kochi, Kerala",
            //    FirstName = "Admin",
            //    LastName = "Zeztate",
            //    SecondaryEmail = "admin@zeztate.com",
            //    Company = "Zeztate",
            //    Phone = "04844000044",
            //    OfficePhone = "04844000044",
            //    Mobile = "04844000044",
            //    TaxEligible = true,
            //    CityId = 612,
            //    Zip = 682028,
            //    Ownership = 100,
            //    EmailAlerts = true,
            //    EmailStatements = true,
            //    EnableOwnerPortal = true,
            //    OwnerType = OwnerType.Company,
            //    UserId=admin.Id
            //};
            //context.Owners.Add(owner);
            //context.SaveChanges();

            ////property
            //var propertyViewPermission = new RolePermission
            //{
            //    PermissionId = 100,
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(propertyViewPermission);
            //context.SaveChanges();

            //var propertyAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 100,
            //    Title = "ViewProperty",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(propertyAdminViewPermission);
            //context.SaveChanges();

            //var propertyManagePermission = new RolePermission
            //{
            //    PermissionCode = 101,
            //    Title = "ManageProperty",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(propertyManagePermission);
            //context.SaveChanges();


            ////unit
            //var unitViewPermission = new RolePermission
            //{
            //    PermissionCode = 102,
            //    Title = "ViewUnit",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(unitViewPermission);
            //context.SaveChanges();

            //var unitAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 102,
            //    Title = "ViewUnit",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(unitAdminViewPermission);
            //context.SaveChanges();

            //var unitManagePermission = new RolePermission
            //{
            //    PermissionCode = 103,
            //    Title = "ManageUnit",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(unitManagePermission);
            //context.SaveChanges();

            ////portfolio
            //var portfolioViewPermission = new RolePermission
            //{
            //    PermissionCode = 104,
            //    Title = "ViewPortfolio",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(portfolioViewPermission);
            //context.SaveChanges();

            //var portfolioAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 104,
            //    Title = "ViewPortfolio",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(portfolioAdminViewPermission);
            //context.SaveChanges();

            //var portfolioManagePermission = new RolePermission
            //{
            //    PermissionCode = 105,
            //    Title = "ManagePortfolio",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(portfolioManagePermission);
            //context.SaveChanges();

            ////owner
            //var ownerViewPermission = new RolePermission
            //{
            //    PermissionCode = 106,
            //    Title = "ViewOwner",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(ownerViewPermission);
            //context.SaveChanges();

            //var ownerAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 106,
            //    Title = "ViewOwner",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(ownerAdminViewPermission);
            //context.SaveChanges();

            //var ownerManagePermission = new RolePermission
            //{
            //    PermissionCode = 107,
            //    Title = "ManageOwner",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(ownerManagePermission);
            //context.SaveChanges();

            ////manager
            //var managerViewPermission = new RolePermission
            //{
            //    PermissionCode = 108,
            //    Title = "ViewManager",
            //    RoleId = userRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(managerViewPermission);
            //context.SaveChanges();

            //var managerAdminViewPermission = new RolePermission
            //{
            //    PermissionCode = 108,
            //    Title = "ViewManager",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(managerAdminViewPermission);
            //context.SaveChanges();

            //var managerManagePermission = new RolePermission
            //{
            //    PermissionCode = 109,
            //    Title = "ManageManager",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};
            //context.RolePermissions.Add(managerManagePermission);
            //context.SaveChanges();

            //var settingsPermission = new RolePermission
            //{
            //    PermissionCode = 110,
            //    Title = "settings",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};

            //context.RolePermissions.Add(settingsPermission);
            //context.SaveChanges();

            //var dashBoardPermission = new RolePermission
            //{
            //    PermissionCode = 111,
            //    Title = "Dashboard",
            //    RoleId = adminRole.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow
            //};

            //context.RolePermissions.Add(dashBoardPermission);
            //context.SaveChanges();

            //var adminRoleMember = new RoleMember
            //{
            //    RoleId = adminRole.Id,
            //    UserId = admin.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow,
            //};
            //context.RoleMembers.Add(adminRoleMember);
            //context.SaveChanges();

            //var userRoleMember = new RoleMember
            //{
            //    RoleId = userRole.Id,
            //    UserId = newuser.Id,
            //    CreatedByUserId = admin.Id,
            //    CreatedOn = DateTime.UtcNow,
            //};
            //context.RoleMembers.Add(userRoleMember);
            //context.SaveChanges();

            //Common.Data.Seeders.CountrySeeder.Seed(context);
            //context.SaveChanges();

            //var managerRole = new List<ManagerRole>
            //{
            //    new ManagerRole{Name="Property Manager"},
            //    new ManagerRole{Name="Sales Contact"}
            //};
            //managerRole.ForEach(s => context.ManagerRoles.Add(s));
            //context.SaveChanges();
        }
    }
}
