using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace QuickZ.Persistent.Business
{
    [DomainComponent]
    [Persistent("Organization")]
    public abstract class OrganizationRole : PartyRole
    {
        public OrganizationRole(Session session) : base(session) { }

        public override bool CanPlayRole(Type partyType)
        {
            return partyType == null
                || partyType == typeof(Organization)
                || partyType.IsSubclassOf(typeof(Organization));
        }
    }
}
