using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Layout;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickZ.Themes.SlackifyWin.Controllers
{
    public class CustomLightStyleLayoutController : ViewController
    {
        private void SetBorderStyle(object control)
        {
            ISupportBorderStyle supportBorderStyle = control as ISupportBorderStyle;
            if (supportBorderStyle != null)
            {
                supportBorderStyle.BorderStyle = BorderStyles.Default;
            }
        }
        private bool UseLightStyle
        {
            get { return ((WinApplication)Application).UseLightStyle; }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            if (!UseLightStyle) return;

            LayoutControl layoutControl = View.Control as LayoutControl;
            if (layoutControl != null && layoutControl.Items != null)
            {
                foreach (LayoutControlGroup group in layoutControl.Items.OfType<LayoutControlGroup>())
                {
                    if (!group.IsInTabbedGroup && (group.Items.Count == 1) && (group.Items[0] is XafLayoutControlItem))
                    {
                        XafLayoutControlItem layoutItem = group.Items[0] as XafLayoutControlItem;
                        SetBorderStyle(layoutItem.Control);
                    }
                }
            }
        }
    }
}
