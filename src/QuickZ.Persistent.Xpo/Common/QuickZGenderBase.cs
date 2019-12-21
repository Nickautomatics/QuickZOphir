using DevExpress.Xpo;
using QuickZ.Persistent.Common;
using System;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
    [MapInheritance(MapInheritanceType.ParentTable)]
    public abstract class QuickZGenderBase : QuickZCatalogGuidObject
    {
        public QuickZGenderBase(Session session)
            : base(session)
        {
        }

        public QuickZGenderBase(Session session, Guid guid) : base(session, guid)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

    }
}
