using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using QuickZ.Persistent.Common;
using System;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
    [System.ComponentModel.DefaultProperty("Name")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Country")]
    [Persistent("Country")]
    public abstract class QuickZCountryBase : QuickZSimpleAuditGuidObject, ICountry
    {
        private string name;
        private string phoneCode;
        public QuickZCountryBase(Session session) : base(session) { }

        public QuickZCountryBase(Session session, Guid guid) : base(session, guid)
        {

        }

        public override string ToString()
        {
            return Name;
        }
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
        public string PhoneCode
        {
            get { return phoneCode; }
            set { SetPropertyValue("PhoneCode", ref phoneCode, value); }
        }
    }
    
}
