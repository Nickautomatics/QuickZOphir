using QuickZ.Core.Models;
using QuickZ.Data.Models;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

namespace QuickZ.SettingsHub.XML
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlRoot("Workspaces")]
    public class XmlWorkspace : WorkspaceBase
    {
        public XmlWorkspace()
            : base()
        {
            
        }
        //[XmlIgnore]
        //public bool IsLastActiveWorkSpace
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}


    }
}
