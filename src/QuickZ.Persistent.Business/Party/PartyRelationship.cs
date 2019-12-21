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
    public abstract class PartyRelationship : QuickZ.Persistent.Common.QuickZSimpleAuditGuidObject
    {
        public PartyRelationship(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            InitPartyRelationshipType();
        }

        protected abstract void InitPartyRelationshipType();

        [Indexed(nameof(FromPartyRole), nameof(ToPartyRole), Unique = true)]
        [RuleRequiredField("PartyRelationship_FromDate_Required", DefaultContexts.Save, "Party relationship 'From' date is required.")]
        public DateTime FromDate
        {
            get { return GetPropertyValue<DateTime>(nameof(FromDate)); }
            set { SetPropertyValue<DateTime>(nameof(FromDate), value); }
        }

        public DateTime ThruDate
        {
            get { return GetPropertyValue<DateTime>(nameof(ThruDate)); }
            set { SetPropertyValue<DateTime>(nameof(ThruDate), value); }
        }

        [RuleRequiredField("PartyRelationship_PartyRelationshipType_Required", DefaultContexts.Save, "Party relationship type is required.")]
        [Association("PartyRelationshipType-PartyRelationships")]
        public PartyRelationshipType PartyRelationshipType
        {
            get { return GetPropertyValue<PartyRelationshipType>(nameof(PartyRelationshipType)); }
            set { SetPropertyValue<PartyRelationshipType>(nameof(PartyRelationshipType), value); }
        }

        [RuleRequiredField("PartyRelationship_FromPartyRole_Required", DefaultContexts.Save, "Party relationship 'From' party role is required.")]
        [Association("PartyRole-PartyRelationships_From")]
        public PartyRole FromPartyRole
        {
            get { return GetPropertyValue<PartyRole>(nameof(FromPartyRole)); }
            set { SetPropertyValue<PartyRole>(nameof(FromPartyRole), value); }
        }

        [RuleRequiredField("PartyRelationship_ToPartyRole_Required", DefaultContexts.Save, "Party relationship 'To' party role is required.")]
        [Association("PartyRole-PartyRelationships_To")]
        public PartyRole ToPartyRole
        {
            get { return GetPropertyValue<PartyRole>(nameof(ToPartyRole)); }
            set { SetPropertyValue<PartyRole>(nameof(ToPartyRole), value); }
        }

    }
}
