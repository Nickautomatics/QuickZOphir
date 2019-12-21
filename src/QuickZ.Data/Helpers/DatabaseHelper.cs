using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using Microsoft.Win32;
using QuickZ.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Data.Helpers {

    public class DatabaseHelper {
        public const string MSAccessCode = "MSAccess";
        public const string SQLServerCode = "SQLServer";
        public const string SQLServerLocalCode = "SQLServerLocal";
        public const string PostgreSQLode = "PostgreSQL";
        public const string SQLiteCode = "SQLite";

        /// <summary>
        /// Create an XPO-compatible XML file
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateEmptyXpoDatasetFile(string filePath) {
            if (System.IO.File.Exists(filePath))
                return;
            var directory = System.IO.Directory.CreateDirectory(new System.IO.FileInfo(filePath).Directory.FullName);

            TextWriter tw = new StreamWriter(filePath, true);
            tw.WriteLine("<XpoDataSet>");
            tw.WriteLine("</XpoDataSet>");
            tw.Close();
        }

        /// <summary>
        /// Checks whether the Access Database Engine drivers are installed
        /// NOTE: Microsoft Jet seems to have better performance compared to Ace
        /// </summary>
        /// <returns></returns>
        [Obsolete("Not ideally efficient in some cases, if not most.")]
        public static bool IsAccessDatabaseEngineInstalled() {
            bool llretval = false;
            string AccessDBAsValue = string.Empty;
            RegistryKey rkACDBKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\Installer\Products");
            if (rkACDBKey != null) {
                //int lnSubKeyCount = 0;
                //lnSubKeyCount =rkACDBKey.SubKeyCount; 
                foreach (string subKeyName in rkACDBKey.GetSubKeyNames()) {
                    using (RegistryKey RegSubKey = rkACDBKey.OpenSubKey(subKeyName)) {
                        foreach (string valueName in RegSubKey.GetValueNames()) {
                            if (valueName.ToUpper() == "PRODUCTNAME") {
                                AccessDBAsValue = (string)RegSubKey.GetValue(valueName.ToUpper());
                                if (AccessDBAsValue.ToLower().Contains("Access database engine".ToLower())) {
                                    llretval = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (llretval) {
                        break;
                    }
                }
            }
            return llretval;
        }

        /// <summary>
        /// Default ConnectionString for XML datasources.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string BuildXMLConnectionString(string filePath) {
            var connectionString =
                $@"XpoProvider = XmlDataSet; 
                   Data Source = {filePath};
                   Read Only = false";
            return connectionString;
        }

        public static void ExtractEmbeddedResource(string resourceName, string fileName) {
            // --- Do not overwrite file
            if (File.Exists(fileName))
                return;

            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)) {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                    resource.CopyTo(file);
                }
            }
        }

        /// <summary>
        /// Default ConnectionString for SQLite datasources.
        /// The dataPathFile parameter should already contain the dbname.db filename
        /// path combined with the directory
        /// </summary>
        /// <param name="dataPathFile"></param>
        /// <returns></returns>
        public static string BuildSQLiteConnectionString(string dataPathFile) => SQLiteConnectionProvider.GetConnectionString(dataPathFile);

        public static IDataLayer GetDataLayer(Assembly[] localAssemblies, AutoCreateOption autoCreateOption, string connectionString) {
            var dataStore = XpoDefault.GetConnectionProvider(connectionString, autoCreateOption);
            XPDictionary dictionary = new ReflectionDictionary();
            dictionary.CollectClassInfos(localAssemblies);

            return new SimpleDataLayer(dictionary, dataStore);
        }

        /// <summary>
        /// https://community.devexpress.com/blogs/markmiller/CodeRushShortcutsAndTemplates.pdf
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string BuildMSAccessConnectionString(string filePath, string userName, string password) {
            // Microsoft.Jet.OLEDB.4.0
            // Warning: ACE is slower that Jet (on most occasions)
            var connectionString = $@"
                        Provider = Microsoft.ACE.OLEDB.12.0;
                        Mode = Share Deny None; 
                        Data Source = {filePath};";

            if (!String.IsNullOrEmpty(userName)) connectionString +=
                        $@"User ID={userName};
                        Password ={password}";
            return connectionString;
        }

        public static string BuildLocalSqlServerConnectionString(string localInstanceFullName, string databaseName) {
            var connectionString = $@"
                        Data Source = {localInstanceFullName};
                        Initial Catalog = {databaseName};
                        Integrated Security = SSPI;
                        Pooling = false;
                        Connection Timeout = 60";
            return connectionString;
        }

        public static string BuildSqlServerConnectionString(string serverInstanceFullName, string databaseName, string userName, string password) {
            var connectionString = $@"
                        Data Source = {serverInstanceFullName};
                        Initial Catalog = {databaseName};
                        User ID = {userName}; 
                        Password = {password};
                        Pooling = false;
                        Connection Timeout = 60";
            return connectionString;
        }

        public static string BuildPostgreSQLConnectionString(string serverInstanceFullName, string port, string databaseName, string userName, string password) {
            var connectionString = $@"
                        Host = {serverInstanceFullName};
                        Database ={databaseName};
                        User ID = {userName}; 
                        Password = {password};
                        Pooling = false;
                        Connection Timeout = 60";
            return connectionString;
        }

        public static string GetConnectionStringByType(IWorkspace workspace) {
            switch (workspace.DBType) {
                case SQLServerLocalCode:
                    return DatabaseHelper.BuildLocalSqlServerConnectionString(workspace.Server, workspace.Database);
                case SQLServerCode:
                    return DatabaseHelper.BuildSqlServerConnectionString(workspace.Server, workspace.Database, workspace.UserName, workspace.Password);
                case PostgreSQLode:
                    return DatabaseHelper.BuildPostgreSQLConnectionString(workspace.Server, workspace.Port, workspace.Database, workspace.UserName, workspace.Password);
                case MSAccessCode:
                    return DatabaseHelper.BuildMSAccessConnectionString(workspace.Database, workspace.UserName, workspace.Password);
                default:
                    return DatabaseHelper.BuildMSAccessConnectionString(workspace.Database, workspace.UserName, workspace.Password);
            }
        }
    }
}
