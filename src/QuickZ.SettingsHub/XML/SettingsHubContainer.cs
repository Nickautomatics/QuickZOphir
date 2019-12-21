using QuickZ.Core.Models;
using QuickZ.Core.SettingsHub;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace QuickZ.SettingsHub.XML
{
    [Serializable()]
    [XmlType(AnonymousType = true)]
    [XmlRoot("QuickZ", IsNullable = false)]
    public class SettingsHubContainer : ISettingsHubContainer
    {
        public SettingsHubContainer()
        {

        }

        XmlWorkspaces workspaces;
        [XmlIgnore]
        public XmlWorkspaces Workspaces
        {
            get
            {
                if (workspaces == null)
                    workspaces = new XmlWorkspaces();
                return workspaces;
            }
            set { workspaces = value; }
        }

        [XmlArrayAttribute("Workspaces")]
        public XmlWorkspace[] WorkspaceArray
        {
            get { return Workspaces.ToArray(); }
            set
            {
                foreach (XmlWorkspace item in value)
                {
                    Workspaces.Add(item);
                }
            }
        }

        IList ISettingsHubContainer.Workspaces
        {
            get
            {
                return Workspaces as IList;
            }

        }
    }
}
