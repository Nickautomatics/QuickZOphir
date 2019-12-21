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
using DevExpress.ExpressApp.Win;
using DevExpress.LookAndFeel;
using QuickZ.Themes.SlackifyWin.Controllers;
using DevExpress.ExpressApp.SystemModule;
using QuickZ.ExpressApp;

namespace QuickZ.Themes.SlackifyWin {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed class QuickZSlackifyModule : QuickZModuleBase {
        public QuickZSlackifyModule() {

            // --- Set Bezier as default style
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Bezier);
        }         

        public override void Setup(XafApplication application) {
            base.Setup(application);

            // --- Enable Light Style
            ((WinApplication)application).UseLightStyle = true;

            // application.ObjectSpaceCreated += new EventHandler<ObjectSpaceCreatedEventArgs>(application_ObjectSpaceCreated);
            application.CreateCustomTemplate += Application_CreateCustomTemplate;
        }

        private void Application_CreateCustomTemplate(object sender, CreateCustomTemplateEventArgs e)
        {
            if (e.Context == TemplateContext.ApplicationWindow)
                e.Template = new Templates.SlackifyLightStyleMainRibbonForm();
                //e.Template = new Templates.LightStyleMainRibbonForm1();
            if (e.Context == TemplateContext.View)
                e.Template = new Templates.SlackifyLightStyleDetailRibbonForm();
            if (e.Context == TemplateContext.PopupWindow)
                e.Template = new Templates.SlackifyLighStylePopupForm();
            if (e.Context == TemplateContext.LookupControl)
                e.Template = new Templates.SlackifyLookupControlTemplate();
            if (e.Context == TemplateContext.NestedFrame)
                e.Template = new Templates.SlackifyNestedFrameTemplate();
        }

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
            return new Type[] {
                typeof(CustomLightStyleLayoutController),
                typeof(CustomizeMasterDetailViewController),
                typeof(SyncNavigationGroupCaptionController),
                typeof(SwitchViewContainerController)
            };
        }

        //void application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
        //{
        //    e.ObjectSpace.Committed += new EventHandler(ObjectSpace_Committed);
        //    e.ObjectSpace.Disposed += new EventHandler(ObjectSpace_Disposed);
        //}

        //void ObjectSpace_Committed(object sender, EventArgs e)
        //{
        //    ShowNavigationItemController controller = this.Application.MainWindow.GetController<ShowNavigationItemController>();
        //    if (controller != null)
        //        controller.RecreateNavigationItems();
        //}

        //void ObjectSpace_Disposed(object sender, EventArgs e)
        //{
        //    ((IObjectSpace)sender).Committed -= new EventHandler(ObjectSpace_Committed);
        //}

        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}
