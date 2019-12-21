using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace QuickZ.Persistent.Business
{    
    public abstract class PersonRole : PartyRole
    {
        public PersonRole(Session session) : base(session) { }

        protected override void InitPartyRoleType()
        {
            PartyRoleType = PartyRoleType.GetPartyRoleType(Session, this.GetType().Name);
        }

        public override bool CanPlayRole(Type partyType)
        {
            return partyType == null
                || partyType == typeof(Person)
                || partyType.IsSubclassOf(typeof(Person));
        }

    }
}
