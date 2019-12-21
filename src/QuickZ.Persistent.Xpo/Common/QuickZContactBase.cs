using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace  QuickZ.Persistent.Simple
{
    
    [NonPersistent]
    [DevExpress.ExpressApp.DC.XafDisplayName("Contact")]
    [System.ComponentModel.DefaultProperty("FullName")]
    public abstract class QuickZContactBase : QuickZPersonBase
    {
        public QuickZContactBase(Session session) : base(session)
        {
        }
        public QuickZContactBase(Session session, Guid guid) : base(session, guid)
        {

        }

    }
}
