using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Core.Helpers {
    public static class DirectoryHelper {
        public const string DefaultUserSettingsFolderName = "Settings";

        /// <summary>
        /// Returns QuickZ's default configuration foler
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultConfigurationFolder() =>
            Path.Combine(GetApplicationPath(), DefaultUserSettingsFolderName);

        /// <summary>
        /// Returns C:\ProgramData
        /// </summary>
        /// <returns></returns>
        public static string GetCommonApplicationDataFolder() =>
             Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        /// <summary>
        /// Returns C:\Users\{CurrentUser}\AppData\Roaming
        /// </summary>
        /// <returns>Directory string in value</returns>
        public static string GetCurrentUserAppDataFolder() =>
             Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Creates the directory path if it does not exist
        /// returns the existing path
        /// </summary>
        /// <returns>Directory string in value</returns>
        public static string GetDirectoryExistsOrNot(string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// Returns C:\Users\Public\
        /// </summary>
        /// <returns></returns>
        public static string GetPublicFolder() =>
                new System.IO.DirectoryInfo(GetCommonApplicationDataFolder()).Parent.FullName;

        /// <summary>
        /// Returns the folder of the current application
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationPath() =>
            AppDomain.CurrentDomain.BaseDirectory;

    }
}
