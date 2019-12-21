using DevExpress.Xpo;
using QuickZ.Core.Contracts.Templates;
using System;

namespace QuickZ.Persistent.Xpo.BusinessObjects.Templates
{
    public partial class QuickZFileTemplate 

    {
        //public QuickZFileTemplate(Session session) : base(session)
        //{

        //}

        public QuickZFileTemplate(Session session, Guid oidOverride) : base(session, oidOverride)
        {

        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (((ITemplateFile)this).Content == null)
            {
                Name = "Unknown File";
                Description = "(empty file)";
            }
            else
            {
                if (String.IsNullOrEmpty(Name))
                    Name = ((ITemplateFile)this).FileName;
            }
        }
    }

}
