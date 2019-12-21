using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;
using QuickZ.Persistent.Common;

namespace QuickZ.Persistent.Xpo.BusinessObjects.Multitenancy
{
    [Persistent("Location")]
   [XafDisplayName("Location")]
    public abstract class QuickZLocationBase : QuickZSimpleAuditGuidObject
    { 
        public QuickZLocationBase(Session session)
            : base(session)
        {
        }

        public QuickZLocationBase(Session session, Guid guid) : base(session, guid)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string name;
        [Size(256)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetPropertyValue("Name", ref name, value);
            }
        }

    }
}