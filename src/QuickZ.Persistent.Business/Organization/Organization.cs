using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using QuickZ.Persistent.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace QuickZ.Persistent.Business
{
    [NonPersistent]
    [DomainComponent]
    [DefaultProperty(nameof(Name))]
    [XafDisplayName("Organization")]
    public abstract class Organization : Party
    {
        protected Organization(Session session) : base(session) { }
        public Organization(Session session, Guid guid) : base(session, guid)
        {
        }

    }


}

