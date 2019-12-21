using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace QuickZ.Persistent.Xpo.BusinessObjects.Templates
{   
    
    public partial class QuickZTemplateReportBase
    {
        public QuickZTemplateReportBase(Session session)
            : base(session)
        {
        }

        public QuickZTemplateReportBase(Session session, Guid oidOverride)
            : base(session, oidOverride)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


    }

}
