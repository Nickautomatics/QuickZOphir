using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Persistent.BaseImpl;
using QuickZ.Core;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Validation.Win;
using System.Diagnostics;

namespace QuickZ.ExpressApp.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class QuickZWinFormsModule : QuickZModuleWinBase
    {

        public QuickZWinFormsModule() : base()
        {
            InitializeComponent();

            //if (!DevExpress.Utils.Design.DesignTimeTools.IsDesignMode)
            //    LoadXafBuiltinWinFormsModules(BusinessEngineBase.Instance.ActiveApplication as XafApplication);
        }

        private void Application_CreateCustomModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, "Win");
            e.Handled = true;
        }

        private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e)
        {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, "Win");
            e.Handled = true;
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return ModuleUpdater.EmptyModuleUpdaters;
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);

            application.SettingUp += Application_SettingUp;

            application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
            application.CreateCustomUserModelDifferenceStore += Application_CreateCustomUserModelDifferenceStore;
            // Manage various aspects of the application UI and behavior at the module level.
        }

        private void Application_SettingUp(object sender, SetupEventArgs e)
        {
            LoadQuickZWinFormsModules(QuickZDomainContext.Instance.ActiveApplication as XafApplication);
        }
        void LoadQuickZWinFormsModules(XafApplication application)
        {
            //QuickZ_DashboardWinFormsModule = new Dashboards.WinForms.QuickZDashboardWinFormsModule();
            //application.Modules.Add(QuickZ_DashboardWinFormsModule);
        }

        void LoadXafBuiltinWinFormsModules(XafApplication application)
        {

        }

    }
}
