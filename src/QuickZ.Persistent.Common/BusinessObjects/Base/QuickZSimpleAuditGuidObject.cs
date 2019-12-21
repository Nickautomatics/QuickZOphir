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
using QuickZ.Core;

namespace QuickZ.Persistent.Common
{
    [DeferredDeletion(Enabled = true)]
    [NonPersistent]
    [System.ComponentModel.DefaultProperty("Oid")]
    [DevExpress.ExpressApp.DC.XafDisplayName("QuickZ Object")]
    public abstract class QuickZSimpleAuditGuidObject : QuickZLiteGuidObject, IHasDisplayText
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public QuickZSimpleAuditGuidObject(Session session)
            : base(session)
        {
        }

        public QuickZSimpleAuditGuidObject(Session session, Guid guid) : base(session, guid)
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

            DeletedByUserId = null;
        }


        protected override void OnSaving()
        {
            base.OnSaving();

            if (Session.IsNewObject(this))
            {
                CreatedOn = DateTime.Now;
                CreatedBy = String.IsNullOrEmpty(SecuritySystem.CurrentUserName) ? QuickZDomainContext.Instance.EnterpriseSuperAdminUser : SecuritySystem.CurrentUserName ;
                CreatedByUserId = SecuritySystem.CurrentUserId == null
                    ? new Guid(QuickZDomainContext.Instance.EnterpriseSuperAdminId)
                    : (String.IsNullOrEmpty(SecuritySystem.CurrentUserId.ToString())
                        ? new Guid(QuickZDomainContext.Instance.EnterpriseSuperAdminId)
                        : new Guid(SecuritySystem.CurrentUserId.ToString())
                        );
            }

            LastModifiedOn = DateTime.Now;
            LastModifiedBy = String.IsNullOrEmpty(SecuritySystem.CurrentUserName) ? QuickZDomainContext.Instance.EnterpriseSuperAdminUser : SecuritySystem.CurrentUserName;
            LastModifiedByUserId = SecuritySystem.CurrentUserId == null
                     ? new Guid(QuickZDomainContext.Instance.EnterpriseSuperAdminId)
                     : (String.IsNullOrEmpty(SecuritySystem.CurrentUserId.ToString())
                         ? new Guid(QuickZDomainContext.Instance.EnterpriseSuperAdminId)
                         : new Guid(SecuritySystem.CurrentUserId.ToString())
                         );
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            DeletedOn = DateTime.Now;
            DeletedBy = String.IsNullOrEmpty(SecuritySystem.CurrentUserName) ? QuickZDomainContext.Instance.EnterpriseSuperAdminUser : SecuritySystem.CurrentUserName;
            DeletedByUserId = SecuritySystem.CurrentUserId == null
                    ? new Guid(QuickZDomainContext.Instance.EnterpriseSuperAdminId)
                    : (String.IsNullOrEmpty(SecuritySystem.CurrentUserId.ToString())
                        ? new Guid(QuickZDomainContext.Instance.EnterpriseSuperAdminId)
                        : new Guid(SecuritySystem.CurrentUserId.ToString())
                        );

        }

        #endregion

        #region Persistent Properties
        //private bool _IsSystemObject;
          
        private bool isActive;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [XafDisplayName("Active")]
        [NonCloneable]
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue(nameof(IsActive), ref isActive, value); }
        }

        private DateTime? _LastModifiedOn;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [NonCloneable]
        public DateTime? LastModifiedOn
        {
            get { return _LastModifiedOn; }
            set { SetPropertyValue(nameof(LastModifiedOn), ref _LastModifiedOn, value); }
        }

        private string _LastModifiedBy;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [NonCloneable]
        public string LastModifiedBy
        {
            get { return _LastModifiedBy; }
            set { SetPropertyValue(nameof(LastModifiedBy), ref _LastModifiedBy, value); }
        }

        private  Guid? _LastModifiedByUserId;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [Size(48)]
        [NonCloneable]
        public Guid? LastModifiedByUserId
        {
            get
            {
                return _LastModifiedByUserId;
            }
            set
            {
                SetPropertyValue(nameof(LastModifiedByUserId), ref _LastModifiedByUserId, value);
            }
        }

        private Guid? _CreatedByUserId = null;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [Size(48)]
        [NonCloneable]
        public Guid? CreatedByUserId
        {
            get
            {
                return _CreatedByUserId;
            }
            set
            {
                SetPropertyValue(nameof(CreatedByUserId), ref _CreatedByUserId, value);
            }
        }

        private DateTime? _CreatedOn;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [NonCloneable]
        public DateTime? CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue(nameof(CreatedOn), ref _CreatedOn, value); }
        }

        private string _CreatedBy;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [NonCloneable]
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue(nameof(CreatedBy), ref _CreatedBy, value); }
        }

        private DateTime? _DeletedOn;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [NonCloneable]
        public DateTime? DeletedOn
        {
            get { return _DeletedOn; }
            set { SetPropertyValue(nameof(DeletedOn), ref _DeletedOn, value); }
        }

        private string _DeletedBy;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [NonCloneable]
        public string DeletedBy
        {
            get { return _DeletedBy; }
            set { SetPropertyValue(nameof(DeletedBy), ref _DeletedBy, value); }
        }

        private Guid? _DeletedByUserId;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        [Size(48)]
        [NonCloneable]
        public Guid? DeletedByUserId
        {
            get
            {
                return _DeletedByUserId;
            }
            set
            {
                SetPropertyValue(nameof(DeletedByUserId), ref _DeletedByUserId, value);
            }
        }

        #endregion

        public override string ToString()
        {
            return GetDisplayText();
        }
    }
    // DevEx coed. See https://www.devexpress.com/Support/Center/Example/Details/E2829
}