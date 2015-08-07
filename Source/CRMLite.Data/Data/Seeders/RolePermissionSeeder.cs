using Common.Auth.SingleTenant.Entities;
using System;
using System.Collections.Generic;

namespace CRMLite.Data.Data.Seeders
{
    public static class RolePermissionSeeder
    {
        public static void Seed(DataContext context)
        {
            var permission = new List<Permission>{
                new Permission{PermissionCode=100,Title="ViewProperty",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 101,Title = "ManageProperty",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 102,Title = "ViewUnit",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 103,Title = "ManageUnit",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 104,Title = "ViewPortfolio",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 105,Title = "ManagePortfolio",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 106,Title = "ViewOwner",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 107,Title = "ManageOwner",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 108,Title = "ViewManager",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 109,Title = "ManageManager",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 110,Title = "Settings",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 111,Title = "Dashboard",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},

                new Permission{PermissionCode = 200,Title = "ViewAccount",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 201,Title = "ManageAccount",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 202,Title = "ViewLead",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 203,Title = "ManageLead",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 204,Title = "ViewContact",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 205,Title = "manageContactAccountPermission",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 206,Title = "ViewPotential",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 207,Title = "ManagePotential",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 208,Title = "ViewUser",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 209,Title = "ManageUser",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 210,Title = "ConvertLead",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 211,Title = "Dashboard",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 212,Title = "SettingsCrm",CreatedByUserId=1,CreatedOn=DateTime.UtcNow},
                new Permission{PermissionCode = 213,Title = "DefaultMenu",CreatedByUserId=1,CreatedOn=DateTime.UtcNow}
                };

            permission.ForEach(s => context.Permissions.Add(s));
            context.SaveChanges();
            //property
            var propertyViewPermission = new RolePermission
            {
                PermissionId = 1,
                RoleId = 2,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(propertyViewPermission);
            context.SaveChanges();

            var propertyAdminViewPermission = new RolePermission
            {
                PermissionId = 1,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(propertyAdminViewPermission);
            context.SaveChanges();

            var propertyManagePermission = new RolePermission
            {
                PermissionId = 2,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(propertyManagePermission);
            context.SaveChanges();


            //unit
            var unitViewPermission = new RolePermission
            {
                PermissionId = 3,
                RoleId = 2,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(unitViewPermission);
            context.SaveChanges();

            var unitAdminViewPermission = new RolePermission
            {
                PermissionId = 3,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(unitAdminViewPermission);
            context.SaveChanges();

            var unitManagePermission = new RolePermission
            {
                PermissionId = 4,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(unitManagePermission);
            context.SaveChanges();

            //portfolio
            var portfolioViewPermission = new RolePermission
            {
                PermissionId = 5,
                RoleId = 2,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(portfolioViewPermission);
            context.SaveChanges();

            var portfolioAdminViewPermission = new RolePermission
            {
                PermissionId = 5,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(portfolioAdminViewPermission);
            context.SaveChanges();

            var portfolioManagePermission = new RolePermission
            {
                PermissionId = 6,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(portfolioManagePermission);
            context.SaveChanges();

            //owner
            var ownerViewPermission = new RolePermission
            {
                PermissionId = 7,
                RoleId = 2,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(ownerViewPermission);
            context.SaveChanges();

            var ownerAdminViewPermission = new RolePermission
            {
                PermissionId = 7,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(ownerAdminViewPermission);
            context.SaveChanges();

            var ownerManagePermission = new RolePermission
            {
                PermissionId = 8,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(ownerManagePermission);
            context.SaveChanges();

            //manager
            var managerViewPermission = new RolePermission
            {
                PermissionId = 9,
                RoleId = 2,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(managerViewPermission);
            context.SaveChanges();

            var managerAdminViewPermission = new RolePermission
            {
                PermissionId = 9,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(managerAdminViewPermission);
            context.SaveChanges();

            var managerManagePermission = new RolePermission
            {
                PermissionId = 10,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(managerManagePermission);
            context.SaveChanges();

            var settingsPermission = new RolePermission
            {
                PermissionId = 11,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(settingsPermission);
            context.SaveChanges();

            var dashBoardPermission = new RolePermission
            {
                PermissionId = 12,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(dashBoardPermission);
            context.SaveChanges();

            var viewAccountPermission = new RolePermission
            {
                PermissionId = 13,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(viewAccountPermission);
            context.SaveChanges();

            var manageAccountPermission = new RolePermission
            {
                PermissionId = 14,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(manageAccountPermission);
            context.SaveChanges();

            var viewLeadAccountPermission = new RolePermission
            {
                PermissionId = 15,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(viewLeadAccountPermission);
            context.SaveChanges();

            var manageLeadAccountPermission = new RolePermission
            {
                PermissionId = 16,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(manageLeadAccountPermission);
            context.SaveChanges();

            var viewContactAccountPermission = new RolePermission
            {
                PermissionId = 17,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(viewContactAccountPermission);
            context.SaveChanges();

            var manageContactAccountPermission = new RolePermission
            {
                PermissionId = 18,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(manageContactAccountPermission);
            context.SaveChanges();

            var viewPotentialAccountPermission = new RolePermission
            {
                PermissionId = 19,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(viewPotentialAccountPermission);
            context.SaveChanges();

            var managePotentialAccountPermission = new RolePermission
            {
                PermissionId = 20,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(managePotentialAccountPermission);
            context.SaveChanges();

            var viewUserAccountPermission = new RolePermission
            {
                PermissionId = 21,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(viewUserAccountPermission);
            context.SaveChanges();

            var manageUserPermission = new RolePermission
            {
                PermissionId = 22,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(manageUserPermission);
            context.SaveChanges();

            var convertLeadPermission = new RolePermission
            {
                PermissionId = 23,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(convertLeadPermission);
            context.SaveChanges();

            var dashBoardaPermission = new RolePermission
            {
                PermissionId = 24,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };

            context.RolePermissions.Add(dashBoardaPermission);
            context.SaveChanges();

            var settingsCrmPermission = new RolePermission
            {
                PermissionId = 25,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(settingsCrmPermission);
            context.SaveChanges();

            var defaultMenuPermission = new RolePermission
            {
                PermissionId = 26,
                RoleId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(defaultMenuPermission);
            context.SaveChanges();
            var defaultMenusPermission = new RolePermission
            {
                PermissionId = 26,
                RoleId = 2,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow
            };
            context.RolePermissions.Add(defaultMenusPermission);
            context.SaveChanges();
            var adminRoleMember = new RoleMember
            {
                RoleId = 1,
                UserId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            context.RoleMembers.Add(adminRoleMember);
            context.SaveChanges();

            var adminUserRoleMember = new RoleMember
            {
                RoleId = 2,
                UserId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            context.RoleMembers.Add(adminUserRoleMember);
            context.SaveChanges();

            var adminAgentRoleMember = new RoleMember
            {
                RoleId = 3,
                UserId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            context.RoleMembers.Add(adminUserRoleMember);
            context.SaveChanges();

            var adminTenantRoleMember = new RoleMember
            {
                RoleId = 4,
                UserId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            context.RoleMembers.Add(adminTenantRoleMember);
            context.SaveChanges();

            var adminOwnerRoleMember = new RoleMember
            {
                RoleId = 5,
                UserId = 1,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            context.RoleMembers.Add(adminOwnerRoleMember);
            context.SaveChanges();

            var userRoleMember = new RoleMember
            {
                RoleId = 2,
                UserId = 2,
                CreatedByUserId = 1,
                CreatedOn = DateTime.UtcNow,
            };
            context.RoleMembers.Add(userRoleMember);
            context.SaveChanges();
        }
    }
}
