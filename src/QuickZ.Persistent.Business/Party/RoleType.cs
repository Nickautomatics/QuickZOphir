using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Persistent.Business
{
    [DefaultClassOptions]
    [DefaultProperty("Description")]
    public abstract class RoleType : QuickZ.Persistent.Common.QuickZSimpleAuditGuidObject
    {
        public RoleType(Session session) : base(session) { }

        [RuleRequiredField("RoleType_Description_Required", DefaultContexts.Save, "Role description is required.")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue<string>("Description", value); }
        }
    }

    [DefaultClassOptions]
    public class PartyRoleType : RoleType
    {
        public PartyRoleType(Session session) : base(session) { }

        [Aggregated]
        [Association("PartyRoleType-PartyRoles", typeof(PartyRole))]
        public XPCollection<PartyRole> PartyRoles
        {
            get { return GetCollection<PartyRole>("PartyRoles"); }
        }

        [Aggregated]
        [Association("PartyRoleType-PartyRelationshipTypes_From", typeof(PartyRelationshipType))]
        public XPCollection<PartyRelationshipType> FromRelationships
        {
            get { return GetCollection<PartyRelationshipType>("FromRelationships"); }
        }

        [Aggregated]
        [Association("PartyRoleType-PartyRelationshipTypes_To", typeof(PartyRelationshipType))]
        public XPCollection<PartyRelationshipType> ToRelationships
        {
            get { return GetCollection<PartyRelationshipType>("ToRelationships"); }
        }

        public static PartyRoleType GetPartyRoleType(Session session, string description)
        {
            if (session == null || description == null)
            {
                throw new ArgumentNullException();
            }
            PartyRoleType type = session.FindObject<PartyRoleType>(new BinaryOperator("Description", description));
            if (type == null)
            {
                // create it
                type = new PartyRoleType(session);
                type.Description = description;
            }
            return type;
        }
    }
}
