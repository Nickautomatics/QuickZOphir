using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace QuickZ.Persistent.Business
{
    public enum CustomerType
    {
        Individual = 100,
        Organization = 200
    }

    [Persistent("Customer")]
    [DomainComponent]
    public abstract class CustomerRole : PartyRole
    {
        public CustomerRole(Session session) : base(session) {
            type = CustomerType.Individual;
        }

        public override bool CanPlayRole(Type partyType)
        {
            return partyType == null
                || partyType == typeof(Party)
                || partyType.IsSubclassOf(typeof(Party));
        }

        CustomerType type;
        public CustomerType Type
        {
            get => type;
            set => SetPropertyValue(nameof(Type), ref type, value);
        }
    }
}
