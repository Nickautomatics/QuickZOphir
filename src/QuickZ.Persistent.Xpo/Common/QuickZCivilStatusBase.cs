using DevExpress.Xpo;
using QuickZ.Persistent.Common;
using System;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
    [MapInheritance(MapInheritanceType.ParentTable)]
    public abstract class QuickZCivilStatusBase : QuickZCatalogGuidObject
    {
        public QuickZCivilStatusBase(Session session)
            : base(session)
        {
        }

        public QuickZCivilStatusBase(Session session, Guid guid) : base(session, guid)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

    }
}
