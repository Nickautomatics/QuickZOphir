using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuickZ.SettingsHub.XML
{
    [XmlRoot("Workspaces")]
    [XmlInclude(typeof(XmlWorkspace))]
    public class XmlWorkspaces : List<XmlWorkspace>
    {

        public XmlWorkspaces() : base()
        { }


    }
}
