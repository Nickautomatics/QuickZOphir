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
    public class PartyRelationshipType : QuickZ.Persistent.Common.QuickZSimpleAuditGuidObject
    {
        public PartyRelationshipType(Session session) : base(session) { }

        [Indexed("FromPartyRoleType", "ToPartyRoleType", Unique = true)]
        [RuleRequiredField("PartyRelationshipType_Name_Required", DefaultContexts.Save, "Party relationship type name is required.")]
        public string Name
        {
            get { return GetPropertyValue<string>(nameof(Name)); }
            set { SetPropertyValue<string>(nameof(Name), value); }
        }

        [Size(200)]
        public string Description
        {
            get { return GetPropertyValue<string>(nameof(Description)); }
            set { SetPropertyValue<string>(nameof(Description), value); }
        }

        /// <summary>
        /// Provider of the Relationship
        /// </summary>
        [Indexed("ToPartyRoleType", Unique = true)]
        [Association("PartyRoleType-PartyRelationshipTypes_From")]
        public PartyRoleType FromPartyRoleType
        {
            get { return GetPropertyValue<PartyRoleType>(nameof(FromPartyRoleType)); }
            set { SetPropertyValue<PartyRoleType>(nameof(FromPartyRoleType), value); }
        }

        /// <summary>
        /// Recepeint of the Relationship
        /// </summary>
        [Association("PartyRoleType-PartyRelationshipTypes_To")]
        public PartyRoleType ToPartyRoleType
        {
            get { return GetPropertyValue<PartyRoleType>(nameof(ToPartyRoleType)); }
            set { SetPropertyValue<PartyRoleType>(nameof(ToPartyRoleType), value); }
        }

        [Aggregated]
        [Association("PartyRelationshipType-PartyRelationships", typeof(PartyRelationship))]
        public XPCollection<PartyRelationship> PartyRelationships
        {
            get { return GetCollection<PartyRelationship>(nameof(PartyRelationships)); }
        }

        public static PartyRelationshipType GetPartyRelationshipType(Session session, string partyRelationshipTypeName, string fromPartyRoleTypeName, string toPartyRoleTypeName)
        {
            if (session == null ||
                string.IsNullOrEmpty(partyRelationshipTypeName) ||
                string.IsNullOrEmpty(fromPartyRoleTypeName) ||
                string.IsNullOrEmpty(toPartyRoleTypeName))
            {
                throw new ArgumentNullException();
            }

            BinaryOperator nameCriteria = new BinaryOperator("Name", partyRelationshipTypeName);

            PartyRoleType fromPartyRoleType = PartyRoleType.GetPartyRoleType(session, fromPartyRoleTypeName);
            BinaryOperator fromCriteria = new BinaryOperator(nameof(FromPartyRoleType), fromPartyRoleType);

            PartyRoleType toPartyRoleType = PartyRoleType.GetPartyRoleType(session, toPartyRoleTypeName);
            BinaryOperator toCriteria = new BinaryOperator(nameof(ToPartyRoleType), toPartyRoleType);

            GroupOperator criteria = new GroupOperator(nameCriteria, fromCriteria, toCriteria);

            PartyRelationshipType type = session.FindObject<PartyRelationshipType>(criteria);
            if (type == null)
            {
                type = new PartyRelationshipType(session);
                type.Name = partyRelationshipTypeName;
                type.FromPartyRoleType = fromPartyRoleType;
                type.ToPartyRoleType = toPartyRoleType;
                type.Description = string.Format("Defines relationships between '{0}' and '{1}'.", fromPartyRoleTypeName, toPartyRoleTypeName);
            }

            return type;
        }
    }
}
