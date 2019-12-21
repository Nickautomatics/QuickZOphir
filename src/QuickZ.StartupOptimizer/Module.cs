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
using QuickZ.ExpressApp;
using DevExpress.ExpressApp.Security;

namespace QuickZ.StartupOptimizer {
    
    public sealed partial class QuickZStartupOptimizerModule : QuickZModuleBase {
        public QuickZStartupOptimizerModule() {
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;

            // --- This significantly improves Security System performance when using Integrated Security
            // See: https://www.devexpress.com/Support/Center/Question/Details/T381322/security-how-to-reduce-the-number-of-permission-requests-and-improve-overall-performance
            SecurityAdapterHelper.Enable(DevExpress.ExpressApp.Security.Adapters.ReloadPermissionStrategy.CacheOnFirstAccess);

            ModelCacheManager.UseMultithreadedLoading = true;
            ModelCacheManager.SkipEmptyNodes = true;
        }
    }
}
