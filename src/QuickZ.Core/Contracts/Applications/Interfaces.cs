using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Applications
{


    public interface IBusinessEngine
    {        
        void Start();
        /// <summary>
        /// Creates the database (XML or SQLite) for the local settings
        /// </summary>
        /// <param name="isAutoCreateMainDatabase"></param>
        /// <param name="localConnectionString"></param>
        /// <param name="mainConnectionString"></param>
        void InitDataStorage(bool isAutoCreateMainDatabase, string localConnectionString, string mainConnectionString);        
        void CreateDeafultSettingsFile();
        string GetSettingsFile();
        string GetDataFolder();
        string GetAccountDataFolder(string dataFolder, string accountName);
        string GetAccountWorspaceFolder(string dataFolder, string accountName);
        string GetSettingsHubsFile(string dataFolder, string settingsFilename);
        string GetWorkspaceFilePath(string dataFolder, string accountName);

        Guid ActiveEnterpriseAccountId { get; set; }
        Guid ActiveEnterpriseWorkspaceId { get; set; }
        object ActiveWorkspace { get; set; }
        string ActiveWorkspaceCaption { get; set; }
        string CurrentUserName { get; }
        string DefaultAccountsFile { get; set; }
        string DefaultAccountsFolder { get; set; }
        string DefaultDataFolder { get; }
        string DefaultLocalAccountFolder { get; set; }
        string DefaultLocalWorkspaceId { get; set; }
        string DefaultLocalWorkspaceName { get; set; }
        string DefaultWorkspaceFolder { get; set; }
        string DefaultWorkspaceSessionId { get; set; }
        string EnterpriseSuperAdminId { get; set; }
        string EnterpriseSuperAdminUser { get; set; }        
        string LocalAccountId { get; set; }
        string LocalAccountName { get; set; }
        string LocalAccountSettingsFile { get; set; }
        object LocalDataLayer { get; set; }
        string MainDatabaseConnectionString { get; set; }
        string LocalDataConnectionString { get; set; }
        string SettingsHubsExtName { get; set; }
        ISharedLocation ShareLocation { get; set; }
        bool IsAutoCreateMainDatabase { get; set; }
        string WorkspaceExtName { get; set; }
        object Workspaces { get; set; }
    }

    public interface IBusinessEngineComponent
    {
        IBusinessEngine ActiveBusinessEngine { get; set; }
    }

    
    public interface IQuickZApplication
    {
        // object LocalDataLayer { get; set; }
    }

    public interface IQuickZWinApplication : IQuickZApplication
    {
        void StartBusinessEngine(IBusinessEngine businessEngine);
        void CreateLocalAccount(IBusinessEngine businessEngine);        

        //XpoDataStoreProxy DataStoreProxy { get; set; }
        //XpoDataStoreProxyProvider DataStoreProxyProvider { get; set; }
    }

    public interface IQuickZApplicationWithCustomSecurity
    {
        void ForceLogon();
        bool IsApplicationExit { get; set; }
    }

    /// <summary>
    /// This should be the default Location (Id) for all globally accessible object. (e.g. List of Customers, List of Cities, etc.)
    /// </summary>
    public interface ISharedLocation
    {

    }
}
