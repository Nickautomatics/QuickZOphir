using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using QuickZ.Persistent.Common;
using System;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
    [Persistent("Phone")]
    [System.ComponentModel.DefaultProperty(nameof(Number))]
    [DevExpress.ExpressApp.DC.XafDisplayName("Phoner Number")]

    public abstract class QuickZPhoneBase : QuickZSimpleAuditGuidObject, IPhoneNumber
    {
        private PhoneNumberImpl phone = new PhoneNumberImpl();        
        public QuickZPhoneBase(Session session) : base(session) { }
        public QuickZPhoneBase(Session session, Guid guid) : base(session, guid)
        { }
        public override string ToString()
        {
            return Number;
        }
        [Persistent]
        public string Number
        {
            get { return phone.Number; }
            set
            {
                string oldValue = phone.Number;
                phone.Number = value;
                OnChanged("Number", oldValue, phone.Number);
            }
        }

        public string PhoneType
        {
            get { return phone.PhoneType; }
            set
            {
                string oldValue = phone.PhoneType;
                phone.PhoneType = value;
                OnChanged("PhoneType", oldValue, phone.PhoneType);
            }
        }
    }


    public class PhoneType : QuickZSimpleAuditGuidObject
    {
        public PhoneType(Session session) : base(session) { }
        private string typeName;
        public string TypeName
        {
            get { return typeName; }
            set { SetPropertyValue("TypeName", ref typeName, value); }
        }
    }
}
