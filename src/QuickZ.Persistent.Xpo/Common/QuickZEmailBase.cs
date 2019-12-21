using DevExpress.Xpo;
using QuickZ.Persistent.Common;

namespace  QuickZ.Persistent.Simple
{
    [Persistent("EmailAddress")]
    public abstract class QuickZEmailBase : QuickZSimpleAuditGuidObject
    { 
        public QuickZEmailBase(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string emailAddress;
        [Size(256)]
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                SetPropertyValue("EmailAddress", ref emailAddress, value);
            }
        }

    }
}