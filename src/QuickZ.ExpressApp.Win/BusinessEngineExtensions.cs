using QuickZ.Applications;
using QuickZ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickZ.ExpressApp.Win.Extensions
{
    public static class BusinessEngineExtensions
    {
        public static void Shutdown(this IBusinessEngine engine)
        {
            Application.ExitThread();
            Application.Exit();
            Environment.Exit(0);
        }

        public static void ForceApplicationExit(this IBusinessEngine engine)
        {
            Application.Exit();
            Environment.Exit(0);
        }
    }


}
