using DevExpress.ExpressApp.Win;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCALE.Core.Helpers
{
    class SplashHelper : ISplash , ISupportUpdateSplash
    {
        static private SplashScreenWindowForm form;
        private static bool isStarted = false;
        public void Start()
        {
            isStarted = true;
            form = new SplashScreenWindowForm();
            form.Show();
            System.Windows.Forms.Application.DoEvents();
        }
        public void Stop()
        {
            if (form != null)
            {
                form.Hide();
                form.Close();
                form = null;
            }
            isStarted = false;
        }
        public void SetDisplayText(string displayText)
        {
        }
        public bool IsStarted
        {
            get { return isStarted; }
        }

        public void UpdateSplash(string caption, string description, params object[] additionalParams)
        {
           form.UpdateInfo(description);
        }
    }
}
