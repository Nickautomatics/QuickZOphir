using DevExpress.Xpo;
using System;
using System.Linq;

namespace QuickZ.Persistent.Common
{
    [Persistent("Catalog")]
    [System.ComponentModel.DefaultProperty("Name")]
    public abstract class QuickZCatalogGuidObject : QuickZSimpleAuditGuidObject
    {
        public QuickZCatalogGuidObject(Session session)
            : base(session)
        {
        }

        public QuickZCatalogGuidObject(Session session, Guid guid) : base(session, guid)
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
        //[RuleRequiredAttribute]
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
        [Size(2048)]
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
        int sortIndex;
        public int SortIndex
        {
            get
            {
                return sortIndex;
            }
            set
            {
                SetPropertyValue("SortIndex", ref sortIndex, value);
            }
        }

    }
}