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
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;

namespace QuickZ.Themes.SlackifyWin.Controllers
{
    /// <summary>
    /// Transfer 
    /// </summary>
    public class SwitchViewContainerController : WindowController
    {
        public SwitchViewContainerController()
        {
            TargetWindowType = WindowType.Main;
        }

        protected override void SubscribeToViewEvents(View view)
        {
            base.SubscribeToViewEvents(view);

            if (view is ListView)
            {
                var listView = view as ListView;

                //var newGrid = (DevExpress.XtraGrid.GridControl)(listView).Editor.Control;
                //if (newGrid.Parent is SidePanel)
                //{
                //    var gridContainer = new SidePanel();
                //    gridContainer = (SidePanel)newGrid.Parent;
                //    gridContainer.Visible = false;

                //    Templates.SlackifyLightStyleMainRibbonForm.SettingsContainer.Controls.Add(newGrid);
                //    newGrid.Dock = System.Windows.Forms.DockStyle.Fill;
                //}

            }
        }
    }
}
