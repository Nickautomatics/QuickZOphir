using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.SystemModule;

namespace QuickZ.ExpressApp.Win
{
    public abstract class QuickZModuleWinBase : QuickZModuleBase
    {
        public QuickZModuleWinBase() : base()
        { }

        protected override ModuleTypeList GetRequiredModuleTypesCore()
                    => base.GetRequiredModuleTypesCore()
                        .AddModuleTypes(typeof(SystemWindowsFormsModule));
    }
}
