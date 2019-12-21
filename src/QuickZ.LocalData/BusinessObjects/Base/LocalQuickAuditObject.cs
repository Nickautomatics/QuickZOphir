using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using QuickZ.Core.Contracts;
using QuickZ.LocalData;

namespace QuickZ.LocalData
{
    [NonPersistent]
    [System.ComponentModel.DefaultProperty("Oid")]
    [DevExpress.ExpressApp.DC.XafDisplayName("QuickZ Object")]
    public abstract class  LocalQuickAuditObject : LocalBaseObject, IHasDisplayText
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public LocalQuickAuditObject(Session session)
            : base(session)
        {
        }

        public LocalQuickAuditObject(Session session, Guid guid) : base(session, guid)
        {

        }

        #region Overrides

        protected override void OnLoaded()
        {
            base.OnLoaded();

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            IsActive = true;
            IsSystemObject = false;
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (Session.IsNewObject(this))
            {
                CreatedOn = DateTime.Now;
                CreatedByUserName = SecuritySystem.CurrentUserName;
                CreatedByUserId = SecuritySystem.CurrentUserId == null ? "System" : SecuritySystem.CurrentUserId.ToString();
            }

            LastModifiedOn = DateTime.Now;
            LastModifiedByUserName = SecuritySystem.CurrentUserName;
            LastModifiedByUserId = SecuritySystem.CurrentUserId == null ? "System" : SecuritySystem.CurrentUserId.ToString();
        }

        #endregion

        #region Persistent Properties        
        private string _CreatedByUserId;
        private string _LastModifiedByUserId;
        private bool isActive;
        [XafDisplayName("Active")]
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }

        private DateTime? _LastModifiedOn;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        public DateTime? LastModifiedOn
        {
            get { return _LastModifiedOn; }
            set { SetPropertyValue("LastModifiedDate", ref _LastModifiedOn, value); }
        }

        private string _LastModifiedBy;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        public string LastModifiedByUserName
        {
            get { return _LastModifiedBy; }
            set { SetPropertyValue("LastModifiedBy", ref _LastModifiedBy, value); }
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [Size(48)]
        public string LastModifiedByUserId
        {
            get
            {
                return _LastModifiedByUserId;
            }
            set
            {
                SetPropertyValue("LastModifiedByUserId", ref _LastModifiedByUserId, value);
            }
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [Size(48)]
        public string CreatedByUserId
        {
            get
            {
                return _CreatedByUserId;
            }
            set
            {
                SetPropertyValue("CreatedByUserId", ref _CreatedByUserId, value);
            }
        }

        private DateTime? _CreatedOn;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        public DateTime? CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue("CreatedDate", ref _CreatedOn, value); }
        }

        private string _CreatedBy;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        public string CreatedByUserName
        {
            get { return _CreatedBy; }
            set { SetPropertyValue("CreatedBy", ref _CreatedBy, value); }
        }

        #endregion

        public override string ToString()
        {
            return GetDisplayText();
        }
    }
}