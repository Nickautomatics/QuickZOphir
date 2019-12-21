using DevExpress.ExpressApp.Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCALE.Core.Forms
{
    public partial class SplashScreenWindowForm : DevExpress.XtraSplashScreen.SplashScreen
    {
        public SplashScreenWindowForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AllowTransparency = false;
            this.Opacity = 95;
            this.BringToFront();

            this.lblVersion.Text = $"Version {Application.ProductVersion}";
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            UpdateSplashCommand command = (UpdateSplashCommand)cmd;
            if (command == UpdateSplashCommand.Description)
            {
                string description = Convert.ToString(arg);
                lblProgress.Text = description;
            }
        }
        internal void UpdateInfo(string info)
        {
            lblProgress.Text = info;
        }
    }
}
