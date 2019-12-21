using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using QuickZ.Core.Contracts;
using QuickZ.Core.Models;
using System;
using System.ComponentModel;
using System.Linq;

namespace QuickZ.LocalData
{
    [NavigationItem(GroupName = "Local Hub")]
    [CreatableItem(true)]
    [Persistent("WorkspaceStash")]
    [System.ComponentModel.DefaultProperty("Caption")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Stash")]
    public class LocalStash : LocalQuickAuditObject //, ILocalObject, IWorkspaceStash
    {
        public LocalStash(Session session)
            : base(session)
        {
        }

        public LocalStash(Session session, Guid guid) : base(session, guid)
        {            
        }

        public LocalStash(Session session, Guid guid, LocalAccount account)
            : this(session, guid)
        {
            Account = account;
        }

        public LocalStash(Session session, Guid guid, LocalAccount account, LocalWorkspace workSpace)
            : this(session, guid, account)
        {
            Workspace = workSpace;
        }

        public LocalStash(Session session, Guid guid, LocalAccount account, LocalWorkspace workSpace, string caption)
            : this(session, guid, account, workSpace)
        {
            Caption = caption;
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue) => base.OnChanged(propertyName, oldValue, newValue);

        string caption;
        [Size(64)]
        public string Caption
        {
            get { return caption; }
            set { SetPropertyValue("Caption", ref caption, value); }
        }

        LocalAccount account;
        public LocalAccount Account
        {
            get { return account; }
            set { SetPropertyValue("Account", ref account, value); }
        }

        public bool IsLocal => Workspace.IsLocal;

        int index;
        /// <summary>
        /// Sets the position of the Workspace on the MainForm tab
        /// </summary>
        public int Index
        {
            get { return index; }
            set { SetPropertyValue("Index", ref index, value); }
        }

        LocalWorkspace workspace;
        public LocalWorkspace Workspace
        {
            get { return workspace; }
            set { SetPropertyValue("Workspace", ref workspace, value); }
        }

        bool isLastActiveSession;
        public bool IsLastActiveSession
        {
            get { return isLastActiveSession; }
            set { SetPropertyValue("IsLastActiveSession", ref isLastActiveSession, value); }
        }

    }
}