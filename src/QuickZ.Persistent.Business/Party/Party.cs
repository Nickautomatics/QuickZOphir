using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using QuickZ.Persistent.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace  QuickZ.Persistent.Business
{
    [NonPersistent]
    [DomainComponent]
    [DefaultProperty(nameof(Name))]
    public abstract class Party : QuickZSimpleAuditGuidObject
    {                
        protected Party(Session session) : base(session) { }
        public Party(Session session, Guid guid) : base(session, guid)
        {  }
        public override string ToString()
        {
            return Name;
        }

        private Image photo;
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Photo
        {
            get
            {
                return photo;
            }
            set
            {
                SetPropertyValue<Image>("Photo", ref photo, value);
            }
        }

        public abstract string Name
        {
            get;
        }

        [DevExpress.Xpo.Aggregated]
        [Association("Party-PartyRoles", typeof(PartyRole))]
        public XPCollection<PartyRole> PartyRoles
        {
            get { return GetCollection<PartyRole>("PartyRoles"); }
        }
    }
}

