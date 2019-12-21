using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Persistent.Business
{
    public class PartyRoleException : ApplicationException
    {
        public PartyRoleException() : this("Party role exception.") { }
        public PartyRoleException(string message) : base(message) { }
    }

    // [DefaultClassOptions]
    [NonPersistent]
    [DomainComponent]
    [XafDisplayName("Party Role")]
    [NavigationItem("Party Roles")]
    public abstract class PartyRole : QuickZ.Persistent.Common.QuickZSequenceObject
    {
        public PartyRole(Session session) : base(session) { }

        [Indexed("PartyRoleType", Unique = true)]
        [Association("Party-PartyRoles")]
        public Party Party
        {
            get { return GetPropertyValue<Party>("Party"); }
            set
            {
                if (CanPlayRole(value.GetType()))
                {
                    SetPropertyValue<Party>("Party", value);
                }
                else
                {
                    string message = string.Format("Role type '{0}' is not valid for party type '{1}'.", this.GetType().Name, value.GetType().Name);
                    throw new PartyRoleException(message);
                }
            }
        }

        [DevExpress.ExpressApp.DC.Aggregated]
        [Association("PartyRole-PartyRelationships_From", typeof(PartyRelationship))]
        public XPCollection<PartyRelationship> FromRelationships
        {
            get { return GetCollection<PartyRelationship>("FromRelationships"); }
        }

        [DevExpress.ExpressApp.DC.Aggregated]
        [Association("PartyRole-PartyRelationships_To", typeof(PartyRelationship))]
        public XPCollection<PartyRelationship> ToRelationships
        {
            get { return GetCollection<PartyRelationship>("ToRelationships"); }
        }

        [Association("PartyRoleType-PartyRoles")]
        public PartyRoleType PartyRoleType
        {
            get { return GetPropertyValue<PartyRoleType>("PartyRoleType"); }
            set { SetPropertyValue<PartyRoleType>("PartyRoleType", value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            InitPartyRoleType();
        }

        protected abstract void InitPartyRoleType();
        public virtual bool CanPlayRole(Type partyType)
        {
            return partyType == null || partyType.IsSubclassOf(typeof(Party));
        }
    }
}
