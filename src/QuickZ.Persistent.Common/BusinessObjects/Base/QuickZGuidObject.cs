using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using QuickZ.Core.Contracts;
using QuickZ.Core.Contracts.System;
using System;
using System.ComponentModel;
using System.Linq;

namespace QuickZ.Persistent.Common
{
    [NonPersistent]
    [System.ComponentModel.DefaultProperty("Oid")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Lite Object")]
    public abstract class QuickZLiteGuidObject : XPLiteObject, IHasDisplayText, ISystemObjectTarget
    {
        #region Constructors
        public QuickZLiteGuidObject(Session session)
            : base(session)
        {
            // SetNewKey(Guid.NewGuid());

        }

        public QuickZLiteGuidObject(Session session, Guid guid) : base(session)
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

        ///// <summary>
        ///// MS Access doesn't support "long" for PK Identity 
        ///// </summary>
        //int oid;
        //[Persistent("Oid")]
        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]
        //[VisibleInLookupListView(false)]
        //[NonCloneable]
        //[MemberDesignTimeVisibility(false)]
        //[Key(AutoGenerate = true)]
        //public int Oid
        //{
        //    get
        //    {
        //        return oid;
        //    }
        //    private set
        //    {
        //        SetPropertyValue(nameof(Oid), ref oid, value);
        //    }
        //}
        
        Guid oid;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [MemberDesignTimeVisibility(false)]
        [NonCloneable]
        [Persistent("Oid")]
        [Key(AutoGenerate = true)]
        public Guid Oid
        {
            get { return oid; }
            private set
            {

                SetPropertyValue(nameof(Oid), ref oid, value);
            }
        }

        bool isStandardObject;
        /// <summary>
        /// Inidicates that an object is a part of a standardized procedure/structure
        /// </summary>
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [MemberDesignTimeVisibility(false)]
        [NonCloneable]
        public bool IsStandardObject
        {
            get
            {
                return isStandardObject;
            }
            set
            {
                SetPropertyValue("IsStandardObject", ref isStandardObject, value);
            }
        }

        string standardizationType;
        /// <summary>
        /// Indicates the body/group that implements the standard (e.g. DepEd, CHED, TESDA, etc.)
        /// </summary>
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [MemberDesignTimeVisibility(false)]
        [NonCloneable]
        [Size(32)]
        public string StandardizationType
        {
            get
            {
                return standardizationType;
            }
            set
            {
                SetPropertyValue("StandardizationType", ref standardizationType, value);
            }
        }

        private bool _IsSystemObject;
        /// <summary>
        /// Indicates that this object can only be managed internally by the system
        /// </summary>
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [NonCloneable]
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
