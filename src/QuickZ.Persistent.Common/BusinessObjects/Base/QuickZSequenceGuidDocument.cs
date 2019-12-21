using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace QuickZ.Persistent.Common {
    [DevExpress.ExpressApp.DC.XafDefaultProperty(nameof(FriendlyId))]
    [NonPersistent]
    public abstract class QuickZSequenceDocument : QuickZSequenceObject {
        public QuickZSequenceDocument(Session session) : base(session) {

        }
        public QuickZSequenceDocument(Session session, Guid oidOverride)
            : base(session, oidOverride) {

        }
        public override void AfterConstruction() {
            base.AfterConstruction();
        }

        protected override string GetSequenceId() {
            if (SequenceId != null)
                return SequencePrefix + String.Format("{0:D6}", SequenceId);

            SequenceId = DevExpress.Persistent.BaseImpl
                        .DistributedIdGeneratorHelper
                        .Generate(this.Session.DataLayer, this.GetType().FullName, string.Empty) + 1;
            return SequencePrefix + String.Format("{0:D6}", SequenceId);
        }
    }
}