using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using QuickZ.Persistent.Common;
using System;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
   [Persistent("State")]
   [XafDisplayName("")]
    public abstract class QuickZStateBase : QuickZSimpleAuditGuidObject
    { 
        public QuickZStateBase(Session session)
            : base(session)
        {
        }

        public QuickZStateBase(Session session, Guid guid) : base(session, guid)
        {
            
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        string code;
        [Size(64)]
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                SetPropertyValue("Code", ref code, value);
            }
        }
        string name;
        [Size(128)]
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
        string description;
        [Size(1024)]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                SetPropertyValue("Description", ref description, value);
            }
        }

    }
}