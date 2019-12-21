using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuickZ.Themes.SlackifyWin.Controllers
{
    /// <summary>
    /// Reference: https://www.devexpress.com/Support/Center/Question/Details/T577264/how-to-migrate-a-winforms-application-to-use-the-light-style
    /// </summary>
    public class CustomizeMasterDetailViewController : ViewController<DevExpress.ExpressApp.ListView>
    {
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            // --- Set SidePanel Size Defaults
            if (View.Model.MasterDetailMode == MasterDetailMode.ListViewAndDetailView && View.Control is Control)
            {
                SidePanel sidePanel = ((Control)View.Control).Controls.OfType<SidePanel>().First();
                sidePanel.MinimumSize = new Size(200, 0);
                sidePanel.MaximumSize = new Size(800, 0);
            }
        }
    }
}
