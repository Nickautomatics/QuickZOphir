
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using QuickZ.Core;
using QuickZ.Core.Models;
using System.Collections;
using QuickZ.Core.SettingsHub;
using QuickZ.Data.Models;
using QuickZ.Applications;

namespace QuickZ.Security.BasicWin
{
    public partial class QuickZLoginForm : DevExpress.XtraEditors.XtraForm
    {
        private QuickZAuthentication eezyToolAuthentication;
        private ISettingsHubXmlData _settingsHub;

        public QuickZLoginForm(QuickZAuthentication eezyToolAuthentication, ISettingsHubXmlData settingsHub)
        {
            InitializeComponent();

            _settingsHub = settingsHub;

#if DEBUG
            Shown += (s, e) =>
            {
                UserName = QuickZSecurityModule.DefaultAdministratorUserName;
                Password = QuickZSecurityModule.DefaultAdministratorPwd;
            };
#endif

            sbLogin.Enabled = false;

            this.eezyToolAuthentication = eezyToolAuthentication;

            this.Text = "Startup Security"; // v{Application.ProductVersion}";
            statusVersion.Text = $"v{Application.ProductVersion}";

            liWarningCaption.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            var nowDate = DateTime.Now;
            statusDate.Text = nowDate.ToShortDateString();
            statusTime.Text = nowDate.ToShortTimeString();

            // --- Prevent Login if required fields are missing
            teUsername.EditValueChanged += OnRequiredFieldChanged;
            tePassword.EditValueChanged += OnRequiredFieldChanged;

        }

        private void OnRequiredFieldChanged(object sender, EventArgs e)
        {
            sbLogin.Enabled = !String.IsNullOrEmpty(((BaseEdit)lueWorkspaces).Text)
                && !String.IsNullOrEmpty(((BaseEdit)teUsername).Text);

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            ActiveControl = teUsername;
            teUsername.SelectAll();
        }

        public void SetPassword(string s)
        {
            Password = s;
        }
        public string UserName
        {
            get { return teUsername.Text; }
            set
            {

                teUsername.Text = value;
            }
        }

        public string Password
        {
            get { return tePassword.Text; }
            set
            {

                tePassword.Text = value;
            }
        }

        //public QuickZAuthentication QuickZAuthentication
        //{
        //    get
        //    {
        //        return eezyToolAuthentication;
        //    }

        //    set
        //    {
        //        eezyToolAuthentication = value;
        //    }
        //}

        public void ClearPasswordField()
        {
            tePassword.Text = "";
        }

        public void ShowWarning()
        {
            liWarningCaption.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        public void HideWarning()
        {
            liWarningCaption.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void OnTextEditEnter(object sender, EventArgs e)
        {
            ((TextEdit)sender).BackColor = Color.FromArgb(163, 232, 158);
        }

        private void OnTextEditLeave(object sender, EventArgs e)
        {
            ((TextEdit)sender).BackColor = Color.White;
        }

        private void lueWorkspaces_EditValueChanged(object sender, EventArgs e)
        {
            WorkspaceBase workspace = null;
            foreach (IWorkspace item in _settingsHub.Container.Workspaces)
            {
                if (item.Id == new Guid(lueWorkspaces.EditValue.ToString()))
                {
                    workspace = item as WorkspaceBase;
                    break;
                }

            }
            if (workspace != null)
            {
                ((IBusinessEngine)QuickZDomainContext.Instance.ActiveBusinessEngine).ActiveWorkspace = workspace;
                ((IBusinessEngine)QuickZDomainContext.Instance.ActiveBusinessEngine).MainDatabaseConnectionString = workspace.ConnectionString;
            }

            OnRequiredFieldChanged(sender, e);
        }
    }
}