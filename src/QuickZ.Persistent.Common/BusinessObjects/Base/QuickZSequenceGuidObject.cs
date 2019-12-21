using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using QuickZ.Core.Contracts;
using QuickZ.Core;

namespace QuickZ.Persistent.Common
{
    // DevEx coed. See https://www.devexpress.com/Support/Center/Example/Details/E2829
    [NonPersistent]
    [DevExpress.ExpressApp.DC.XafDefaultProperty(nameof(FriendlyId))]
    public abstract class QuickZSequenceObject : QuickZSimpleAuditGuidObject
    {
        public QuickZSequenceObject(Session session)
            : base(session)
        {
        }
        public QuickZSequenceObject(Session session, Guid oidOverride)
            : base(session, oidOverride)
        {

        }

        #region XPO Overrides
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            if (Session.IsNewObject(this))
                FriendlyId = GetSequenceId();
        }
        #endregion

        [Browsable(false)]
        protected virtual string SequencePrefix { 
            get { return ""; }
        }

        #region Methods

        protected virtual string GetSequenceId()
        {
            if (SequenceId != null)
                return SequencePrefix + String.Format("{0:D4}", SequenceId);

            SequenceId = DevExpress.Persistent.BaseImpl
                        .DistributedIdGeneratorHelper
                        .Generate(this.Session.DataLayer, this.GetType().FullName, string.Empty);
            return SequencePrefix + String.Format("{0:D4}", SequenceId);
        }
        #endregion

        #region SequenceObject Members
  
        // [Browsable(false)]
        [NonCloneable]
        [RuleUniqueValue]
        [RuleRequiredField]
        [ImmediatePostData]
        [DevExpress.ExpressApp.DC.XafDisplayName("Reference #")]
        public string FriendlyId
        {
            get => GetPropertyValue<string>(nameof(FriendlyId));
            set => SetPropertyValue<string>(nameof(FriendlyId), value);
        }

        [RuleUniqueValue]
        [RuleRequiredField]
        [Browsable(false)]
        [NonCloneable]
        [ImmediatePostData]
        public long? SequenceId
        {
            get => GetPropertyValue<long?>(nameof(SequenceId));
            set => SetPropertyValue<long?>(nameof(SequenceId), value);
        }
        #endregion
    }
}