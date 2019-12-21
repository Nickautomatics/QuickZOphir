using DevExpress.Xpo;
using QuickZ.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QuickZ.Core.Helpers;
using System.Collections;
using QuickZ.Core.Models;
using QuickZ.Applications;
using QuickZ.Core;
using DevExpress.ExpressApp;
using QuickZ.Data.Models;
using QuickZ.Data.Helpers;

namespace QuickZ.ExpressApp
{
    /// <summary>
    /// This class serves as a global instance for most-commonly used variables.
    /// It must be referenced by all projects related to the QuickZ enterprise.
    /// </summary>
    public abstract class BusinessEngine : IBusinessEngine
    {
        public static IBusinessEngine Instance = null;
        private string localAccountId = "3F7D7C55-21AE-4035-B2C9-0D78AB086401";
        private string defaultLocalWorkspaceId = "A0800003-C0E8-4B4F-B256-A1A9BEDFC1FD";
        private string defaultWorkspaceSessionId = "1CEB2394-00F0-4B40-9DC3-A7320DBACBA0";
        private string enterpriseSuperAdminId = "5110A48F-086F-4C7F-9FCC-A5D3E967966B";

        private string defaultLocalAccountFolder = "Local";
        private string localAccountName = "My Account";
        private string defaultLocalWorkspaceName = "My Workspace";

        private string defaultAccountsFolder = "Accounts";
        private string defaultWorkspaceFolder = "Workspaces";

        private string localAccountSettingsFile = "Settings";
        private string settingsHubsExtName = ".qcfg";
        private string workspaceExtName = ".qw";
        private string enterpriseSuperAdminUser = "SuperAdministrator";
        private string defaultAccountsFile = "LocalAccount.qza";

        public BusinessEngine()
        {

        }

        //public BusinessEngine(bool isAutoCreateMainDatabase)
        //{
        //    InitDataStorage(isAutoCreateMainDatabase, "", "");
        //}

        public string GetSettingsFile()
        {
            var dataFolder = GetDataFolder();
            var accountsFolder = GetAccountDataFolder(dataFolder, LocalAccountName);

            // --- Let's override this so that we distinguish settings by the Username from AD
            var settingsName = LocalAccountSettingsFile; // (Environment.UserDomainName + "-" + Environment.UserName).Replace(" ", "");

            return GetSettingsHubsFile(dataFolder, settingsName);
        }

        public virtual void InitDataStorage(bool isAutoCreateMainDatabase, string localConnectionString, string mainConnectionString)
        {
            IsAutoCreateMainDatabase = isAutoCreateMainDatabase;

            if (String.IsNullOrEmpty(localConnectionString))
            {
                LocalDataConnectionString = @"
                        XpoProvider = XmlDataSet; 
                        Data Source = " + GetSettingsFile() + @";
                        Read Only = false";

                // --- Make sure Local Settings File folder is created            
                CreateDeafultSettingsFile();
            }
            else
                // --- 
                LocalDataConnectionString = localConnectionString;

            if (String.IsNullOrEmpty(mainConnectionString))
                // MainDatabaseConnectionString = @"XpoProvider = MyMSAccess; Provider = Microsoft.Jet.OLEDB.4.0; Mode = Share Deny None; data source = WinSolution.mdb; user id = Admin; password =;"
                MainDatabaseConnectionString = @"
                    Data Source=(localdb)\mssqllocaldb;
                    Initial Catalog=QuickZ;
                    Integrated Security=SSPI;
                    Pooling=false;
                    Connection Timeout=60";
            else
                MainDatabaseConnectionString = mainConnectionString;

            // --- Initialize Workspace Collection
            workspaces = new List<WorkspaceBase>();
            activeWorkspace = null;
        }

        public abstract void Start();

        public string GetDataFolder()
        {
            // --- Make sure the Data Folder is already created
            var dataFolder = System.IO.Directory.CreateDirectory(DefaultDataFolder);
            return dataFolder.FullName;
        }

        public void CreateDeafultSettingsFile()
        {
            // --- Let's override this so that we distinguish settings by the Username from AD
            //settingsName = (Environment.UserDomainName + "-" + Environment.UserName).Replace(" ", "");

            var settingsFile = GetSettingsFile(); // GetSettingsHubsFile(dataFolder, settingsName);
            if (!File.Exists(settingsFile))
            {
                DatabaseHelper.CreateEmptyXpoDatasetFile(settingsFile);
            }
        }

        #region Shared Location
        ISharedLocation shareLocation = null;
        public ISharedLocation ShareLocation
        {
            get
            {
                return shareLocation;
            }
            set
            {

                shareLocation = value;
            }
        }
        #endregion

        #region Default Data Folders and Files
        public string GetSettingsHubsFile(string dataFolder, string settingsFilename)
        {
            // return Path.Combine(DefaultDataFolder, DefaultAccountsFolder, accountSettingsFile);
            return Path.Combine(dataFolder, settingsFilename + SettingsHubsExtName);
        }
        public string GetAccountDataFolder(string dataFolder, string accountName)
        {
            //return Path.Combine(DefaultDataFolder, DefaultAccountsFolder, accountName);
            return Path.Combine(dataFolder, DefaultAccountsFolder, accountName);
        }

        public string GetAccountWorspaceFolder(string dataFolder, string accountName)
        {
            return Path.Combine(GetAccountDataFolder(dataFolder, accountName), DefaultWorkspaceFolder);
        }
        public string GetWorkspaceFilePath(string dataFolder, string accountName)
        {

            return Path.Combine(GetAccountWorspaceFolder(dataFolder, accountName), DefaultLocalWorkspaceName) + WorkspaceExtName;
        }

        public string DefaultDataFolder
        {
            get
            {
#if DEBUG
                var appName = (QuickZDomainContext.Instance.ApplicationName);
                return Path.Combine(DirectoryHelper.GetCommonApplicationDataFolder(), $@"{appName}\Data", Environment.UserName);
#else
                //return Path.Combine(DirectoryHelper.GetApplicationPath(), @"Data");
                return Path.Combine(DirectoryHelper.GetCommonApplicationDataFolder(), @"QuickZ\Data", Environment.UserName);
#endif
            }
        }
        #endregion


        string localDataConnectionString;
        public string LocalDataConnectionString
        {
            get { return localDataConnectionString; }
            set
            {
                localDataConnectionString = value;
            }
        }

        string mainDatabaseConnectionString;
        public string MainDatabaseConnectionString
        {
            get { return mainDatabaseConnectionString; }
            set
            {
                mainDatabaseConnectionString = value;
            }
        }

        public object LocalDataLayer { get; set; } = null;
        public object ActiveApplication { get; set; } = null;
        public bool IsAutoCreateMainDatabase { get; set; } = false;
        public Guid ActiveEnterpriseAccountId { get; set; } = Guid.Empty;
        public Guid ActiveEnterpriseWorkspaceId { get; set; } = Guid.Empty;

        public string ActiveWorkspaceCaption { get; set; }


        private object workspaces;
        public object Workspaces
        {
            get
            {
                return workspaces;
            }
            set
            {
                workspaces = value;
            }
        }

        private object activeWorkspace;
        public object ActiveWorkspace
        {
            get
            {
                return activeWorkspace;
            }
            set
            {
                activeWorkspace = value;
            }
        }
        public string CurrentUserName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string LocalAccountId { get => localAccountId; set => localAccountId = value; }
        public string DefaultLocalWorkspaceId { get => defaultLocalWorkspaceId; set => defaultLocalWorkspaceId = value; }
        public string DefaultWorkspaceSessionId { get => defaultWorkspaceSessionId; set => defaultWorkspaceSessionId = value; }
        public string EnterpriseSuperAdminId { get => enterpriseSuperAdminId; set => enterpriseSuperAdminId = value; }
        public string DefaultLocalAccountFolder { get => defaultLocalAccountFolder; set => defaultLocalAccountFolder = value; }
        public string LocalAccountName { get => localAccountName; set => localAccountName = value; }
        public string DefaultLocalWorkspaceName { get => defaultLocalWorkspaceName; set => defaultLocalWorkspaceName = value; }
        public string DefaultAccountsFolder { get => defaultAccountsFolder; set => defaultAccountsFolder = value; }
        public string DefaultWorkspaceFolder { get => defaultWorkspaceFolder; set => defaultWorkspaceFolder = value; }
        public string LocalAccountSettingsFile { get => localAccountSettingsFile; set => localAccountSettingsFile = value; }
        public string SettingsHubsExtName { get => settingsHubsExtName; set => settingsHubsExtName = value; }
        public string WorkspaceExtName { get => workspaceExtName; set => workspaceExtName = value; }
        public string EnterpriseSuperAdminUser { get => enterpriseSuperAdminUser; set => enterpriseSuperAdminUser = value; }
        public string DefaultAccountsFile { get => defaultAccountsFile; set => defaultAccountsFile = value; }
    }
}
