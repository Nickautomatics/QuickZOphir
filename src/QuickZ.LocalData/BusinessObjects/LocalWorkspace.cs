using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using QuickZ.Core.Contracts;
using System;
using System.Linq;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using QuickZ.Core;
using System.IO;
using QuickZ.Data.Helpers;
using QuickZ.Core.Enums;
using QuickZ.ExpressApp;
using QuickZ.Applications;

namespace QuickZ.LocalData
{
    [NavigationItem(GroupName = "Local Hub")]
    [CreatableItem(true)]
    [DefaultProperty("Name")]
    [XafDisplayName("Workspace")]
    public class LocalWorkspace : LocalBaseObject // , IEnterpriseObject , IWorkspace
    {
        public override void AfterConstruction() => base.AfterConstruction();

        string databaseSourceURI;

        public LocalWorkspace(Session session) : base(session)
        {

        }

        public LocalWorkspace(Session session, Guid guid) : base(session, guid)
        {

        }

        public LocalWorkspace(Session session, Guid guid, LocalAccount account)
            : base(session, guid)
        {
            Account = account;
        }

        public LocalWorkspace(Session session, Guid guid, LocalAccount account, string name)
            : this(session, guid, account)
        {
            Name = name;
        }

        public LocalWorkspace(Session session, Guid guid, LocalAccount account, string name, bool isLocalFile)
            : this(session, guid, account, name)
        {
            IsLocal = isLocalFile;
        }

        public LocalWorkspace(Session session, LocalAccount account)
            : this(session)
        {
            Account = account;
        }

        public LocalWorkspace(Session session, LocalAccount account, string name)
            : this(session, account)
        {
            Name = name;
        }

        public LocalWorkspace(Session session, LocalAccount account, string name, bool isLocalFile)
            : this(session, account, name)
        {
            IsLocal = isLocalFile;
        }

        /// <summary>
        /// Specify the folder path or URI of where QuickZ looks for a list of Access DB files.
        /// </summary>
        [Size(2048)]
        public string DatabaseSourceURI
        {
            get { return databaseSourceURI; }
            set { SetPropertyValue("DatabaseSourceURI", ref databaseSourceURI, value); }
        }

        void UpdateXmlFileValue()
        {
            if (IsSetDefaults)
            {
                var directory = System.IO.Directory.CreateDirectory(((IBusinessEngine)QuickZDomainContext.Instance.ActiveBusinessEngine).GetAccountWorspaceFolder(QuickZDomainContext.Instance.DefaultAccountsFolder, Account.Name));
                XmlFile = Path.Combine(directory.FullName, String.Format("{0}{1}", Name, QuickZDomainContext.Instance.WorkspaceExtName));
            }
        }

        void BuildConnectionString()
        {
            if (IsSetDefaults)
            {
                switch (DataStorageType)
                {
                    case DataStorageTypeEnum.XML:
                        ConnectionString = DatabaseHelper.BuildXMLConnectionString(XmlFile);
                        break;
                    case DataStorageTypeEnum.AccessDB:
                        ConnectionString = DatabaseHelper.BuildMSAccessConnectionString(AccessDbFile, UserName, Password);
                        break;
                    case DataStorageTypeEnum.SqlServerExpress:
                        ConnectionString = DatabaseHelper.BuildLocalSqlServerConnectionString(MsSqlExpressServerInstanceName, DatabaseName);
                        break;
                    case DataStorageTypeEnum.ApplicationServer:
                        ConnectionString = ApplicationServerUri; // DatabaseHelper.BuildPostgresConnectionString(MsSqlExpressServerInstanceName, DatabaseName, UserName, Password);
                        break;
                }
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (String.IsNullOrEmpty(SessionCaption))
                SessionCaption = Name;

            // --- Build ConnectionString when database-aware properties are changed
            if (IsSetDefaults)
            {
                if (DataStorageType == DataStorageTypeEnum.XML)
                    UpdateXmlFileValue();
                BuildConnectionString();
            }

        }

        bool isSetDefaults = true;
        [NonPersistent]
        public bool IsSetDefaults
        {
            get
            {
                return isSetDefaults;
            }
            set
            {
                SetPropertyValue("IsSetDefaults", ref isSetDefaults, value);
            }
        }

        LocalAccount account;
        [ImmediatePostData]
        public LocalAccount Account
        {
            get { return account; }
            set { SetPropertyValue("Account", ref account, value); }
        }

        string licenseKey;
        [Size(256)]
        public string LicenseKey
        {
            get { return licenseKey; }
            set { SetPropertyValue("LicenseKey", ref licenseKey, value); }
        }

        string name;
        [Size(128)]
        [System.ComponentModel.DisplayName("Workspace Name")]
        [ImmediatePostData]
        //[RuleUniqueValue]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }

        string sessionCaption;
        [Size(128)]
        [ImmediatePostData]
        public string SessionCaption
        {
            get
            {
                return sessionCaption;
            }
            set
            {
                SetPropertyValue("SessionCaption", ref sessionCaption, value);
            }
        }

        bool isLocal;
        public bool IsLocal
        {
            get { return isLocal; }
            set { SetPropertyValue("IsLocal", ref isLocal, value); }
        }

        DataStorageTypeEnum dataStorageType;
        [ImmediatePostData]
        public DataStorageTypeEnum DataStorageType
        {
            get { return dataStorageType; }
            set { SetPropertyValue("DataStorageType", ref dataStorageType, value); }
        }

        string xmlFile;
        [Size(1048)]
        [ImmediatePostData]
        public string XmlFile
        {
            get { return xmlFile; }
            set { SetPropertyValue("XmlFile", ref xmlFile, value); }
        }

        string userName;
        [Size(64)]
        [ImmediatePostData]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }

        string password;
        [Size(32)]
        [PasswordPropertyText]
        [ImmediatePostData]
        public string Password
        {
            get { return password; }
            set { SetPropertyValue("Password", ref password, value); }
        }

        string accessDbFile;
        [Size(1048)]
        [ImmediatePostData]
        public string AccessDbFile
        {
            get { return accessDbFile; }
            set { SetPropertyValue("AccessDbFile", ref accessDbFile, value); }
        }

        string msSqlExpressServerName;
        [Size(32)]
        [XafDisplayName("Instance Name")]
        [ImmediatePostData]
        public string MsSqlExpressServerInstanceName
        {
            get { return msSqlExpressServerName; }
            set { SetPropertyValue("MsSqlExpressServerName", ref msSqlExpressServerName, value); }
        }

        string databaseName;
        [Size(64)]
        public string DatabaseName
        {
            get { return databaseName; }
            set { SetPropertyValue("DatabaseName", ref databaseName, value); }
        }

        [NonPersistent]
        [ImmediatePostData]
        public string SqlUserName
        {
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }
        }

        [NonPersistent]
        [ImmediatePostData]
        public string SqlPassword
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;
            }
        }

        string applicationServerUri;
        [Size(256)]
        [XafDisplayName("Application Server (URI)")]
        [ImmediatePostData]
        public string ApplicationServerUri
        {
            get { return applicationServerUri; }
            set { SetPropertyValue("ApplicationServerUri", ref applicationServerUri, value); }
        }

        string connectionString;
#if !DEBUG
        [Browsable(false)]
#endif
        [Size(2048)]
        [ImmediatePostData]
        public string ConnectionString
        {
            get { return connectionString; }
            set { SetPropertyValue("ConnectionString", ref connectionString, value); }
        }

        protected override void EndEdit()
        {
            base.EndEdit();
        }

        protected override void Invalidate(bool disposing)
        {
            base.Invalidate(disposing);
        }

        protected override void OnSaved()
        {
            base.OnSaved();
        }

        bool isLastActiveWorkSpace;
        public bool IsLastActiveWorkSpace
        {
            get { return isLastActiveWorkSpace; }
            set { SetPropertyValue("IsLastActiveWorkSpace", ref isLastActiveWorkSpace, value); }
        }

        // TODO: Override this later and transfer Validtation into a Controller
        //     private bool _IsConnectionVerified = false;
        //     [RuleFromBoolProperty("EnterpriseWorkspaceConnectionVerified", DefaultContexts.Save,
        //"Cannot connect to the database. Please check your connection parameters and try again.")]
        //     public bool IsConnectionVerified => _IsConnectionVerified;

    }
}