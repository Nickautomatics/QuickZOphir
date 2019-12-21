using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security;

using QuickZ.Core;
using QuickZ.ExpressApp;
using QuickZ.Persistent.Common.Security;

namespace QuickZ.Security
{
    /// <summary>
    /// Considerations:
    /// 1. Integration with Identity Provider (e.g. IdentityServer, etc.)
    ///     Reference: https://vimeo.com/254635632 (updated 1/7/2018)
    /// 2. Integration with Permission Provider (e.g. PolicyServer, etc.)
    ///     Reference: https://policyserver.io/
    /// 
    /// </summary>
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class QuickZSecurityModule : QuickZModuleBase        
    {
        public const string DefaultAdministratorUserName = "Admin";
        public const string DefaultAdministratorPwd = "Pass1234!";
        public const string DefaultAdministratorRoleName = "Administrators";
        public const string DefaultGuestUserName = "Guest";
        public const string DefaultGuestPwd = "guest";
        public const string DefaultGuestRoleName = "Guests";

        public static QuickZSecurityModule Instance = null;

        //private DevExpress.ExpressApp.Security.SecurityModule XafSecurityModule;

        public SecurityStrategyComplex SecurityStrategyComplexDefault { get; set; }
        public AuthenticationStandard AuthenticationStandardDefault { get; set; }

        public QuickZSecurityModule() : base()
        {
            // Init default Authentication 
            AuthenticationStandardDefault = new DevExpress.ExpressApp.Security.AuthenticationStandard();
            AuthenticationStandardDefault.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);

            // Init default Security Strategy
            SecurityStrategyComplexDefault = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            SecurityStrategyComplexDefault.Authentication = this.AuthenticationStandardDefault;
            SecurityStrategyComplexDefault.RoleType = typeof(QuickZPermissionRole);
            SecurityStrategyComplexDefault.UserType = typeof(QuickZUser);

            ((XafApplication)QuickZDomainContext.Instance.ActiveApplication).Security = SecurityStrategyComplexDefault;

            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.QuickZSecuritySeedDataUpdater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            var allTypes = base.GetDeclaredExportedTypes();
            var additionalTypes = new Type[] {
                typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRoleBase),
                typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser),
                typeof(Persistent.Common.Security.QuickZUser),
                typeof(Persistent.Common.Security.QuickZPermissionRole)
            };
            allTypes.ToList().AddRange(additionalTypes);
            return allTypes;
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);

            // Init Built-in XAF Security Module
            //XafSecurityModule = new DevExpress.ExpressApp.Security.SecurityModule();
            //application.Modules.Add(XafSecurityModule);

            InitDefaultSecuritySettings();

            // Activate QuickZ Security Module Instance so we can have global access to this module
            Instance = this;
        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        void InitDefaultSecuritySettings()
        {
            // --- Integrate Customer Permissions
            SecurityStrategyComplexDefault.CustomizeRequestProcessors += delegate (object sender, CustomizeRequestProcessorsEventArgs e)
            {
                List<IOperationPermission> result = new List<IOperationPermission>();
                SecurityStrategyComplex security = sender as SecurityStrategyComplex;
                if (security != null)
                {
                    QuickZUser user = security.User as QuickZUser;
                    if (user != null)
                    {
                        foreach (QuickZPermissionRole role in user.Roles)
                        {
                            if (role.CanExport)
                            {
                                result.Add(new ExportPermission());
                            }
                            if (role.CanPrint)
                            {
                                result.Add(new PrintPermission());
                            }
                        }
                    }
                }
                IPermissionDictionary permissionDictionary = new PermissionDictionary((IEnumerable<IOperationPermission>)result);
                e.Processors.Add(typeof(ExportPermissionRequest), new ExportPermissionRequestProcessor(permissionDictionary));
                e.Processors.Add(typeof(PrintPermissionRequest), new PrintPermissionRequestProcessor(permissionDictionary));
            };

            // We needed to wait for the QuickZ Shared Module to be added before setting this up            
            // XafSecurityModule.UserType = typeof(QuickZUserBase);
            //((XafApplication)BusinessEngine.Instance.ActiveApplication).Security.type

        }
    }
}
