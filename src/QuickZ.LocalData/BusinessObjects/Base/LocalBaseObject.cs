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
using DevExpress.Xpo.Metadata;

namespace QuickZ.LocalData
{
    [NonPersistent]
    [System.ComponentModel.DefaultProperty("Id")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Lite Object")]
    public abstract class LocalBaseObject : XPLiteObject //, IHasDisplayText
    {
        #region Constructors
        public LocalBaseObject(Session session)
            : base(session)
        {
            SetNewKey(Guid.NewGuid());
        }

        public LocalBaseObject(Session session, Guid guid) : this(session)
        {
            SetNewKey(guid);
        }
        #endregion

        #region Local variables
        private bool isDefaultPropertyAttributeInit = false;
        private XPMemberInfo defaultPropertyMemberInfo;
        #endregion

        #region Overrides
        public override string ToString()
        {
            return GetDisplayText();
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsSystemObject = false;
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }

        /// <summary>
        /// Prevent system objects from being deleted
        /// </summary>
        protected override void OnDeleting()
        {
            if (IsSystemObject)
                throw new UserFriendlyException("Sorry, you cannot delete a SYSTEM object");
            else
                base.OnDeleting();
        }

        public void SetNewKey(Guid guid)
        {
            oid = guid;
        }
        #endregion

        #region Persistent Properties

        long id;
        [Persistent("ID")]
        [Key(AutoGenerate = true)]
        public long Id
        {
            get
            {
                return id;
            }
            private set
            {
                SetPropertyValue("Id", ref id, value);
            }
        }
        
        Guid oid;
        [Persistent("Oid"), Indexed]
        public Guid Oid
        {
            get { return oid; }
            private set
            {

                SetPropertyValue("Oid", ref oid, value);
            }
        }

        private bool _IsSystemObject;
        /// <summary>
        /// Indicates that this object can only be managed internally by the system
        /// </summary>
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ImmediatePostData]
        public bool IsSystemObject
        {
            get
            {
                return _IsSystemObject;
            }
            set
            {
                SetPropertyValue("IsSystemObject", ref _IsSystemObject, value);
            }
        }
        #endregion

        #region IHasDisplayText Members
        public virtual string GetDisplayText()
        {
            if (!BaseObject.IsXpoProfiling)
            {
                if (!isDefaultPropertyAttributeInit)
                {
                    string defaultPropertyName = string.Empty;
                    XafDefaultPropertyAttribute xafDefaultPropertyAttribute = XafTypesInfo.Instance.FindTypeInfo(GetType()).FindAttribute<XafDefaultPropertyAttribute>();
                    if (xafDefaultPropertyAttribute != null)
                        defaultPropertyName = xafDefaultPropertyAttribute.Name;
                    else
                    {
                        DefaultPropertyAttribute defaultPropertyAttribute = XafTypesInfo.Instance.FindTypeInfo(GetType()).FindAttribute<DefaultPropertyAttribute>();
                        if (defaultPropertyAttribute != null)
                            defaultPropertyName = defaultPropertyAttribute.Name;
                    }
                    if (!string.IsNullOrEmpty(defaultPropertyName))
                        defaultPropertyMemberInfo = ClassInfo.FindMember(defaultPropertyName);

                    isDefaultPropertyAttributeInit = true;
                }
                if (defaultPropertyMemberInfo != null)
                {
                    object obj = defaultPropertyMemberInfo.GetValue(this);
                    if (obj != null)
                        return obj.ToString();
                }
            }
            return base.ToString();
        }
        #endregion

    }
}
