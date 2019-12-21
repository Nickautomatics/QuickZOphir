using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using QuickZ.Persistent.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
    [NonPersistent]
    public abstract class QuickZPartyBase : QuickZSimpleAuditGuidObject
    {                
        protected QuickZPartyBase(Session session) : base(session) { }
        public QuickZPartyBase(Session session, Guid guid) : base(session, guid)
        {  }
        public override string ToString()
        {
            return DisplayName;
        }

        //[ImageEditor]
        //public Image Photo
        //{
        //    get { return GetDelayedPropertyValue<byte[]>("Photo"); }
        //    set { SetDelayedPropertyValue<byte[]>("Photo", value); }
        //}
        private Image photo;
        //[Browsable(false)]
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Photo
        {
            get
            {
                //if (photo == null)
                //    return ReferenceImages.UnknownPerson;
                return photo;
            }
            set
            {
                SetPropertyValue<Image>("Photo", ref photo, value);
            }
        }
        //[NonPersistent]
        //[XafDisplayName("Latest Photo")]
        //public Image PhotoExist
        //{
        //    get
        //    {
        //        if (photo == null)
        //            return ReferenceImages.UnknownPerson;
        //        return photo;
        //    }
        //    set
        //    {
        //        Photo = value;
        //    }
        //}
        //[ObjectValidatorIgnoreIssue(typeof(ObjectValidatorDefaultPropertyIsVirtual), typeof(ObjectValidatorDefaultPropertyIsNonPersistentNorAliased))]
        public abstract string DisplayName
        {
            get;
        }
    }
}

