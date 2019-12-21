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
using DevExpress.ExpressApp.Win;
using System.Windows.Forms;
using QuickZ.Core;
using QuickZ.ExpressApp;
using QuickZ.Persistent.Common.Security;
using QuickZ.Applications;

namespace QuickZ.Security.BasicWin
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class QuickZSecurityBasicWinModule : QuickZModuleBase
    {
        private WinApplication currentApplication = null;
        private QuickZAuthentication authentication;
        private SecurityStrategyComplex basicSecurityStategy;
        public QuickZSecurityBasicWinModule()
        {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;

            currentApplication = (WinApplication)QuickZ.Core.QuickZDomainContext.Instance.ActiveApplication;

            // --- Setup Authentication			
            // Init default Security Strategy
            basicSecurityStategy = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            basicSecurityStategy.Authentication = new QuickZAuthentication();            
            basicSecurityStategy.RoleType = typeof(QuickZPermissionRole);
            basicSecurityStategy.UserType = typeof(QuickZUser);            

#if DEBUG
            CurrentAuthentication.SetPassword("");
#endif
            currentApplication.LogonFailed += Application_LogonFailed;
            currentApplication.LoggingOn += CurrentApplication_LoggingOn;
            currentApplication.LoggedOn += CurrentApplication_LoggedOn;
            currentApplication.LoggedOff += CurrentApplication_LoggedOff;
            currentApplication.SetupComplete += CurrentApplication_SetupComplete;
        }


        public QuickZAuthentication CurrentAuthentication
        {
            get
            {
                return basicSecurityStategy != null
                    ? basicSecurityStategy.Authentication as QuickZAuthentication
                    : null;
            }
            set
            {

                basicSecurityStategy.Authentication = value;
            }
        }


        public override void Setup(XafApplication application)
        {
            //application.CreateCustomLogonWindowObjectSpace += application_CreateCustomLogonWindowObjectSpace;
            base.Setup(application);

            currentApplication.Security = BasicSecurityStategy;

            //// --- Setup Authentication
            //var basicSecurityStategy = application.Security as SecurityStrategyComplex;
            //(basicSecurityStategy.Authentication as QuickZAuthentication).UserType = typeof(PersistentBase.XPO.Security.QuickZUserBase);

        }
        //void application_CreateCustomLogonWindowObjectSpace(object sender, CreateCustomLogonWindowObjectSpaceEventArgs e)
        //{
        //    IObjectSpace objectSpace = ((XafApplication)sender).CreateObjectSpace();
        //    // ((QuickZLogonParameter)e.LogonParameters).ObjectSpace = objectSpace;
        //    e.ObjectSpace = objectSpace;
        //}

        private void CurrentApplication_LoggedOff(object sender, EventArgs e)
        {
            // TODO: Verify if this is just a plain Logoff() or an Application Exit
            //if (!((IQuickZApplicationWithCustomSecurity)BusinessEngine.Instance.ActiveApplication).IsApplicationExit)
            //    ShowLogonForm();
        }

        private void CurrentApplication_LoggedOn(object sender, LogonEventArgs e)
        {
            CurrentAuthentication.HideWarning();
        }

        private void CurrentApplication_LoggingOn(object sender, LogonEventArgs e)
        {
            CurrentAuthentication.HideWarning();
        }

        //public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        //{
        //    ModuleUpdater updater = new Updater(objectSpace, versionFromDB);
        //    return new ModuleUpdater[] { updater };
        //}

        public SecurityStrategyComplex BasicSecurityStategy
        {
            get
            {
                return basicSecurityStategy;
            }

            set
            {
                basicSecurityStategy = value;
            }
        }

        private void CurrentApplication_SetupComplete(object sender, EventArgs e)
        {
            // TODO: Verify if Logon Parameters are being updated
            // CurrentAuthentication.UpdateLogonParameters();

            ((QuickZLogonParameter)basicSecurityStategy.Authentication.LogonParameters).UserName = CurrentAuthentication.UserName;
            ((QuickZLogonParameter)basicSecurityStategy.Authentication.LogonParameters).Password = CurrentAuthentication.Password;
        }


        private void Application_LogonFailed(object sender, LogonFailedEventArgs e)
        {
            if (CurrentAuthentication.ShowLogonForm(true, true) == DialogResult.OK)
            {
                (currentApplication as IQuickZApplicationWithCustomSecurity).ForceLogon();
            }
            e.Handled = true;
        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

    }
}
