using DevExpress.Xpo;
using QuickZ.Persistent.Common;
using System;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
    [Persistent("City")]
    public abstract class QuickZCityBase : QuickZSimpleAuditGuidObject
    { 
        public QuickZCityBase(Session session)
            : base(session)
        {
        }

        public QuickZCityBase(Session session, Guid guid) : base(session, guid)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
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

        string country;
        [Size(64)]
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                SetPropertyValue("Country", ref country, value);
            }
        }

        string state;
        [Size(128)]
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                SetPropertyValue("State", ref state, value);
            }
        }


        string zipCode;
        [Size(16)]
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                SetPropertyValue("ZipCode", ref zipCode, value);
            }
        }

    }
}