using QuickZ.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Core
{
    public interface IQuickZDomainContext
    {
        void Start(object targetApplication);

        object ActiveApplication { get; set; }
        object ActiveBusinessEngine { get; set; }
        string ApplicationName { get; set; }
        /// <summary>
        /// Indicates that the CurrentUser can manage System Objects (e.g. Permission Roles, Edit Model, Delete Access, more... )
        /// A System Object is set in the IsSystemObject property
        /// </summary>
        bool CurrentUserHasSystemAccess { get; set; }
        /// <summary>
        /// Indicates that the CurrentUser can do absolutely everything from top-to-bottom
        /// Should only be granted to Developers
        /// </summary>
        bool CurrentUserHasUniversalAccess { get; set; }
        string DefaultAccountsFolder { get; set; }
        string DefaultLocalWorkspaceId { get; set; }
        string DefaultLocalWorkspaceName { get; set; }
        string DefaultWorkspaceFolder { get; set; }
        string DefaultWorkspaceSessionId { get; set; }
        string EnterpriseSuperAdminId { get; set; }
        string EnterpriseSuperAdminUser { get; set; }
        string LocalAccountId { get; set; }
        string LocalAccountName { get; set; }
        string LocalAccountSettingsFile { get; set; }
        string SettingsHubsExtName { get; set; }
        string WorkspaceExtName { get; set; }

        /// <summary>
        /// Refers to the Current Customer being served by the Application.
        /// This is applicable primarily to Mutli-Tenant architecture.
        /// Otherwise, this will be a fixed value reference to the name of the client paying for the software.
        /// This must be set during startup or before calling XafApplication.Setup()
        /// </summary>
        string TenantName { get; set; }
    }
    public class QuickZDomainContext : IQuickZDomainContext
    {
        public QuickZDomainContext()
        {
            currentUserHasSystemAccess = false;
            currentUserHasUniversalAccess = false;
        }

        public QuickZDomainContext(object targetApplication)
            : this()
        {
            activeApplication = targetApplication;
        }

        public void Start(object targetApplication)
        {
            if (Instance == null)
                Instance = new QuickZDomainContext(targetApplication);
            else
                Instance = this;
        }

        public static QuickZDomainContext Instance = null;

        string applicationName;
        public string ApplicationName
        {
            get { return applicationName; }
            set
            {
                applicationName = value;
            }
        }

        object activeApplication;
        public object ActiveApplication
        {
            get { return activeApplication; }
            set
            {
                activeApplication = value;
            }
        }

        object activeBusinessEngine;
        public object ActiveBusinessEngine
        {
            get { return activeBusinessEngine; }
            set
            {
                activeBusinessEngine = value;
            }
        }

        string tenantName;
        /// <summary>
        /// Refers to the Current Customer being served by the Application.
        /// This is applicable primarily to Mutli-Tenant architecture.
        /// Otherwise, this will be a fixed value reference to the name of the client paying for the software.
        /// This must be set during startup or before calling XafApplication.Setup()
        /// </summary>
        public string TenantName
        {
            get { return tenantName; }
            set
            {
                tenantName = value;
            }
        }

        bool currentUserHasUniversalAccess;
        /// <summary>
        /// Indicates that the CurrentUser can do absolutely everything from top-to-bottom
        /// Should only be granted to Developers
        /// </summary>
        public bool CurrentUserHasUniversalAccess
        {
            get { return currentUserHasUniversalAccess; }
            set
            {
                currentUserHasUniversalAccess = value;
            }
        }

        bool currentUserHasSystemAccess;
        /// <summary>
        /// Indicates that the CurrentUser can manage System Objects (e.g. Permission Roles, Edit Model, Delete Access, more... )
        /// A System Object is set in the IsSystemObject property
        /// </summary>
        public bool CurrentUserHasSystemAccess
        {
            get { return currentUserHasSystemAccess; }
            set
            {
                currentUserHasSystemAccess = value;
            }
        }

        bool currentUserHasTechSupportAccess;
        public bool CurrentUserHasTechSupportAccess
        {
            get { return currentUserHasTechSupportAccess; }
            set
            {
                currentUserHasTechSupportAccess = value;
            }
        }

        private string defaultWorkspaceFolder = "Workspaces";
        public string DefaultWorkspaceFolder { get => defaultWorkspaceFolder; set => defaultWorkspaceFolder = value; }

        private string workspaceExtName = ".qws";
        public string WorkspaceExtName { get => workspaceExtName; set => workspaceExtName = value; }

        private string enterpriseSuperAdminId = "55268A27-70C1-431B-9BEB-2FC34F52A201";
        public string EnterpriseSuperAdminId { get => enterpriseSuperAdminId; set => enterpriseSuperAdminId = value; }

        private string enterpriseSuperAdminUser = "SuperAdmin";
        public string EnterpriseSuperAdminUser { get => enterpriseSuperAdminUser; set => enterpriseSuperAdminUser = value; }

        private string localAccountSettingsFile = "Settings";
        public string LocalAccountSettingsFile { get => localAccountSettingsFile; set => localAccountSettingsFile = value; }

        private string defaultAccountsFolder = "Accounts";
        public string DefaultAccountsFolder { get => defaultAccountsFolder; set => defaultAccountsFolder = value; }

        private string defaultWorkspaceSessionId = "33149715-B0DF-4A47-A749-076D58387D2A";
        public string DefaultWorkspaceSessionId { get => defaultWorkspaceSessionId; set => defaultWorkspaceSessionId = value; }

        private string defaultLocalWorkspaceName = "My Business Workspace";
        public string DefaultLocalWorkspaceName { get => defaultLocalWorkspaceName; set => defaultLocalWorkspaceName = value; }

        private string settingsHubsExtName = ".qonfig";
        public string SettingsHubsExtName { get => settingsHubsExtName; set => settingsHubsExtName = value; }

        private string localAccountId = "031E82E6-7CDB-48F6-807D-54B227BB3D40";
        public string LocalAccountId { get => localAccountId; set => localAccountId = value; }

        private string localAccountName = "MyAccount";
        public string LocalAccountName { get => localAccountName; set => localAccountName = value; }

        private string defaultLocalWorkspaceId = "5658CBC3-2D19-4A38-B373-E89DDD2C93E9";
        public string DefaultLocalWorkspaceId { get => defaultLocalWorkspaceId; set => defaultLocalWorkspaceId = value; }

        object securityLogonParameters;
        public object SecurityLogonParameters
        {
            get { return securityLogonParameters; }
            set
            {
                securityLogonParameters = value;
            }
        }
        object securityAuthentication;
        public object SecurityAuthentication
        {
            get { return securityAuthentication; }
            set
            {
                securityAuthentication = value;
            }
        }
        
    }
}
