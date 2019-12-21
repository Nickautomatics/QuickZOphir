using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.XtraEditors;
using QuickZ.Applications;
using QuickZ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickZ.Win.CommonForms.Controllers
{
    public class PromptCloseMainWindowController : WindowController
    {
        public PromptCloseMainWindowController()
        {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ((WinWindow)Frame).Closing += new System.ComponentModel.CancelEventHandler(CanCloseMainWindowController_Closing);
        }
        void CanCloseMainWindowController_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((IQuickZApplicationWithCustomSecurity)QuickZDomainContext.Instance.ActiveApplication).IsApplicationExit = true;
            if (((FormClosingEventArgs)e).CloseReason == CloseReason.UserClosing)
            {                
                if (XtraMessageBox.Show("Are you sure?", "Application Exit", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    ((IQuickZApplicationWithCustomSecurity)QuickZDomainContext.Instance.ActiveApplication).IsApplicationExit = false;
                    e.Cancel = true;
                }
            }

        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();

            ((WinWindow)Frame).Closing -= new System.ComponentModel.CancelEventHandler(CanCloseMainWindowController_Closing);
        }
    }
}
