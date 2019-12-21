using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraNavBar;

namespace QuickZ.Themes.SlackifyWin.Controllers
{
    public class SyncNavigationGroupCaptionController : WindowController
    {
        private ShowNavigationItemController navigationController;

        public SyncNavigationGroupCaptionController()
        {
            TargetWindowType = WindowType.Main;
        }

        protected override void SubscribeToViewEvents(View view)
        {
            base.SubscribeToViewEvents(view);
        }

        protected override void OnFrameAssigned()
        {
            base.OnFrameAssigned();
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            navigationController = Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null)
            {
                navigationController.ShowNavigationItemAction.CustomizeControl += ShowNavigationItemAction_CustomizeControl;
            }
        }

        private void ShowNavigationItemAction_CustomizeControl(object sender, CustomizeControlEventArgs e)
        {
            NavBarControl navBar = e.Control as NavBarControl;

            if (navBar != null)
            {
                navBar.HideGroupCaptions = true;
                navBar.OptionsNavPane.ShowHeaderText = false;
                navBar.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                navBar.OptionsNavPane.ExpandedWidth = navBar.Parent.Width;
                System.Windows.Forms.Application.DoEvents();
                navBar.Size = new System.Drawing.Size(200, navBar.Size.Height);
                navBar.Location = new System.Drawing.Point(navBar.Location.X, -48); //  navBar.Location.Y - navBar.NavigationPaneGroupClientHeight);
            }

        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
