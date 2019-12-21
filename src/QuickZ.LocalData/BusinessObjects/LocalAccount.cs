using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using QuickZ.Core;
using QuickZ.Core.Contracts;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace QuickZ.LocalData
{
    [NavigationItem(GroupName = "Local Hub")]
    [CreatableItem(true)]
    [DefaultProperty("Name")]
    [XafDisplayName("Account")]
    public class LocalAccount : LocalBaseObject // , IEnterpriseObject, IEnterpriseAccount, IAccountWithLicenses
    {
        public LocalAccount(Session session)
            : base(session)
        {
            
        }

        public LocalAccount(Session session, Guid guid) : base(session, guid)
        {

        }

        public LocalAccount(Session session, Guid guid, string name) : this(session, guid)
        {
            Name = name;
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaved()
        {
            base.OnSaved();
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            // --- Don't do this for the Default Local Account
            if (Oid != new Guid(QuickZDomainContext.Instance.LocalAccountId) && Workspaces.Count == 0)
            {
                var newWorkspace = new LocalWorkspace(Session, this, "My Workspace");
                Workspaces.Add(newWorkspace);
            }
        }

        bool isLastSelectedAccount;
        public bool IsLastSelectedAccount
        {
            get
            {
                return isLastSelectedAccount;
            }
            set
            {
                SetPropertyValue("IsLastSelectedAccount", ref isLastSelectedAccount, value);
            }
        }

        EnterpriseAccountTypeEnum accountType;
        public EnterpriseAccountTypeEnum AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                SetPropertyValue("AccountType", ref accountType, value);
            }
        }

        string name;
        [Size(128)]
        [XafDisplayName("Account Name")]
        [RuleUniqueValue]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }

        string masterLicense;
        [Size(128)]
        public string MasterLicense
        {
            get
            {
                return masterLicense;
            }
            set
            {
                SetPropertyValue("MasterLicense", ref masterLicense, value);
            }
        }

        string licenses;
        [Size(SizeAttribute.Unlimited)]
        // TODO: Provide a custom PropertyEditor
        public string Licenses
        {
            get
            {
                return licenses;
            }
            set
            {
                SetPropertyValue("Licenses", ref licenses, value);
            }
        }

        XPCollection<LocalStash> _Stash = null;
        public XPCollection<LocalStash> Stash
        {
            get
            {
                if (_Stash == null)
                    _Stash = new XPCollection<LocalStash>(Session, CriteriaOperator.Parse("Account.Oid = ?", this.Oid));
                return _Stash;
            }
        }

        XPCollection<LocalWorkspace> _Workspaces = null;
        public XPCollection<LocalWorkspace> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                    _Workspaces = new XPCollection<LocalWorkspace>(Session, CriteriaOperator.Parse("Account.Oid = ?", this.Oid));
                return _Workspaces;
            }
        }

    }
}