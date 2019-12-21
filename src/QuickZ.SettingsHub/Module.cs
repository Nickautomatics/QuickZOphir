using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using QuickZ.Core.Helpers;
using QuickZ.Core.SettingsHub;
using QuickZ.SettingsHub.XML;
using System;
using System.Collections.Generic;
using System.IO;

namespace QuickZ.SettingsHub
{
    /// <summary>
    /// Manages the QuickZ.xml configuration file
    /// </summary>
    public sealed partial class SettingsHubModule : ModuleBase, ISettingsHubModule
    {
        public const string DefaultSettingsFile = "Default.xml";
        SettingsHubXmlData settingsHub = null;
        public SettingsHubXmlData SettingsHub
        {
            get
            {
                return settingsHub;
            }

            set
            {
                settingsHub = value;
            }
        }
        
        //public void RefreshWorkSpaces(ISettingsHubXmlData xmlSettings)
        //{
        //    settingsHub = xmlSettings;
        //    InitWorkspaceData(settingsHub);
        //}

        ///// <summary>
        ///// Populate Workspace Dropdown
        ///// </summary>
        //public void InitWorkspaceData(ISettingsHubXmlData settings)
        //{
        //    settingsHub = settings;
        //    Workspaces = settingsHub.Container.Workspaces;
        //    lueWorkspaces.Properties.DataSource = Workspaces;
        //}

        //public IWorkspace ActiveWorkspace { get; set; }

        //IList workspaces;
        //public IList Workspaces
        //{
        //    get { return workspaces; }
        //    set
        //    {
        //        workspaces = value;
        //    }
        //}
        ISettingsHubXmlData ISettingsHubModule.SettingsHub
        {
            get
            {
                return SettingsHub;
            }
        }

        public SettingsHubModule()
        {

            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;

            var defaultSettingsFolder = DirectoryHelper.GetDefaultConfigurationFolder();
            var currentConfigFile = Path.Combine(defaultSettingsFolder, DefaultSettingsFile); 
            var configWindowsUser = Path.Combine(defaultSettingsFolder, WindowsHelper.GetWindowsCurrentUser().Replace(@"\", "_") + ".xml");

            if (File.Exists(configWindowsUser))
                currentConfigFile = configWindowsUser;

            settingsHub = new SettingsHubXmlData(new SettingsHubContainer(), currentConfigFile);
            settingsHub.Import();
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}
