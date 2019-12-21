using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using QuickZ.Persistent.Common.Security;

namespace QuickZ.Security.DatabaseUpdate {
    /// <summary>
    /// 
    /// </summary>
    public class QuickZSecuritySeedDataUpdater : ModuleUpdater {
        public QuickZSecuritySeedDataUpdater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            QuickZUser sampleUser = ObjectSpace.FindObject<QuickZUser>(new BinaryOperator("UserName", QuickZSecurityModule.DefaultGuestUserName));
            if (sampleUser == null)
            {
                sampleUser = ObjectSpace.CreateObject<QuickZUser>();
                sampleUser.UserName = QuickZSecurityModule.DefaultGuestUserName;
                sampleUser.SetPassword(QuickZSecurityModule.DefaultGuestPwd);

                QuickZPermissionRole defaultRole = CreateDefaultRole();
                sampleUser.Roles.Add(defaultRole);
                ObjectSpace.CommitChanges(); //This line persists created object(s).
            }

            QuickZUser userAdmin = ObjectSpace.FindObject<QuickZUser>(new BinaryOperator("UserName", QuickZSecurityModule.DefaultAdministratorUserName));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<QuickZUser>();
                userAdmin.UserName = QuickZSecurityModule.DefaultAdministratorUserName;

                // Set a password if the standard authentication type is used
                userAdmin.SetPassword(QuickZSecurityModule.DefaultAdministratorPwd);
                ObjectSpace.CommitChanges(); //This line persists created object(s).
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            QuickZPermissionRole adminRole = ObjectSpace.FindObject<QuickZPermissionRole>(new BinaryOperator("Name", QuickZSecurityModule.DefaultAdministratorRoleName));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<QuickZPermissionRole>();
                adminRole.Name = QuickZSecurityModule.DefaultAdministratorRoleName;
                adminRole.IsAdministrative = true;
                userAdmin.Roles.Add(adminRole);
                ObjectSpace.CommitChanges(); //This line persists created object(s).
            }
            
        }

        private QuickZPermissionRole CreateDefaultRole()
        {
            QuickZPermissionRole defaultRole = ObjectSpace.FindObject<QuickZPermissionRole>(new BinaryOperator("Name", QuickZSecurityModule.DefaultGuestRoleName));
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<QuickZPermissionRole>();
                defaultRole.Name = QuickZSecurityModule.DefaultGuestRoleName;

                defaultRole.AddObjectPermission<QuickZUser>(SecurityOperations.ReadOnlyAccess, "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddMemberPermission<QuickZUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddMemberPermission<QuickZUser>(SecurityOperations.Write, "StoredPassword", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<QuickZPermissionRole>(SecurityOperations.Read, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
            }
            return defaultRole;
        }
    }
}
