using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using QuickZ.Core.Models;
using QuickZ.Data.Helpers;

namespace QuickZ.Data.Models
{
    [XmlType("Workspace")]
    [XmlRoot("Workspace")]
    public class WorkspaceBase : IWorkspace
    {
        public WorkspaceBase()
        {
            Id = Guid.NewGuid();
        }

        [Browsable(false)]
        private Guid workspaceId;
        [XmlIgnore]
        public Guid Id
        {
            get { return workspaceId; }
            set
            {
                workspaceId = value;
            }
        }

        public string ConnectionString
        {
            get { return DatabaseHelper.GetConnectionStringByType(this); }
        }

        string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
            }
        }

        string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }


        string dBType;
        public string DBType
        {
            get { return dBType; }
            set
            {
                dBType = value;
            }
        }
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        string database;
        public string Database
        {
            get { return database; }
            set
            {
                database = value;
            }
        }
        string server;
        public string Server
        {
            get { return server; }
            set
            {
                server = value;
            }
        }
        string port;
        public string Port
        {
            get { return port; }
            set
            {
                port = value;
            }
        }

        bool isLastActiveWorkSpace;
        public bool IsLastActiveWorkSpace
        {
            get { return isLastActiveWorkSpace; }
            set
            {
                isLastActiveWorkSpace = value;
            }
        }
        
    }
}
