using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Core.Helpers {
    public static class WindowsHelper {
        /// <summary>
        /// Returns C:\Users\Public\Documents
        /// Enable this is you want to save to Public Documents folder
        /// </summary>
        /// <returns>
        /// Current windows username
        /// </returns>
        public static string GetWindowsCurrentUser() => Environment.UserName;


    }
}
