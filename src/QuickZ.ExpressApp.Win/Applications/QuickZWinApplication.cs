using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using System;
using System.IO;
using System.Linq;
using DevExpress.ExpressApp.Win;
using DevExpress.Xpo.DB;
using System.Threading;
using System.Diagnostics;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;

using QuickZ.Core;
using QuickZ.Applications;

namespace QuickZ.ExpressApp.Win.Applications
{
    public class QuickZWinApplication : WinApplication, IQuickZApplication, IQuickZApplicationWithCustomSecurity
    {
        // public IBusinessEngine ActiveBusinessEngine { get; set; }
        public static QuickZWinApplication intanceClient = null;

        // --- Enable this contructor only when there's a need to load the Model Editor or Application Designer from within Visual Studio
        // NOTE: You will also need to do this to all of its descendants
        public QuickZWinApplication()
        {
            DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = true;
            DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = false;            

            InitializeDefaults();

            DatabaseVersionMismatch += QuickZWinApplication_DatabaseVersionMismatch;
        }

        protected override void OnSetupStarted()
        {
            DevExpress.ExpressApp.ReportsV2.Win.WinReportServiceController.UseNewWizard = true;

            base.OnSetupStarted();
        }

        private void InitializeDefaults()
        {
            // --- Setup default Global Settings here
            UseOldTemplates = false;

            LinkNewObjectToParentImmediately = false;
            OptimizedControllersCreation = true;      
        }

        public QuickZWinApplication(IBusinessEngine businessEngine)
            : this()
        {
            StartBusinessEngine(businessEngine);
        }

        public virtual void StartBusinessEngine(IBusinessEngine businessEngine)
        {
        }

       protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProviders.Add(new SecuredObjectSpaceProvider((SecurityStrategyComplex)Security, args.ConnectionString, args.Connection, false));
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }

        private void QuickZWinApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e)
        {
            string userLanguageName = Thread.CurrentThread.CurrentUICulture.Name;
            if (userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1)
                e.Languages.Add(userLanguageName);
        }

        private void QuickZWinApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e)
        {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if (Debugger.IsAttached)
            {
                e.Updater.Update();
                e.Handled = true;
            }
            else {
                //string message = "The application cannot connect to the specified database, " +
                //    "because the database doesn't exist, its version is older " +
                //    "than that of the application or its schema does not match " +
                //    "the ORM data model structure. To avoid this error, use one " +
                //    "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

                string message = "Incompatible database version. Please check for updates to fix this issue.";

                if (e.CompatibilityError != null && e.CompatibilityError.Exception != null)
                    message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
                throw new InvalidOperationException(message);
            }
#endif
        }
        
        protected override void OnLoggedOn(LogonEventArgs args)
        {
            base.OnLoggedOn(args);
            IsApplicationExit = false;
        }

        void IQuickZApplicationWithCustomSecurity.ForceLogon()
        {
            Logon(null);
        }

        bool isApplicationExit;
        public bool IsApplicationExit
        {
            get { return isApplicationExit; }
            set
            {
                if (isApplicationExit == value)
                    return;
                isApplicationExit = value;
                OnPropertyChanged(nameof(IsApplicationExit));
            }
        }       
    }
}