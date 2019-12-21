using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;
using System.Drawing;
using System.Linq;

namespace QuickZ.Persistent.Common {
    [Persistent("Configuration")]
    [System.ComponentModel.DefaultProperty(nameof(OrganizationName))]
    public abstract class GlocalConfiguration : QuickZSimpleAuditGuidObject {
        public GlocalConfiguration(Session session)
            : base(session) {
        }

        public GlocalConfiguration(Session session, Guid guid) : base(session, guid) {

        }

        public override void AfterConstruction() {
            base.AfterConstruction();

        }
        string organizationName;
        [Size(100)]
        public string OrganizationName {
            get {
                return organizationName;
            }
            set {
                SetPropertyValue(nameof(OrganizationName), ref organizationName, value);
            }
        }

        string organizationAddress;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string OrganizationAddress {
            get {
                return organizationAddress;
            }
            set {
                SetPropertyValue(nameof(OrganizationAddress), ref organizationAddress, value);
            }
        }

        private Image organizationLogo;
        [ValueConverter(typeof(ImageValueConverter))]
        public Image OrganizationLogo {
            get {
                //if (schoolLogo == null)
                //    return ReferenceImages.UnknownPerson;
                return organizationLogo;
            }
            set {
                SetPropertyValue<Image>(nameof(OrganizationLogo), ref organizationLogo, value);
            }
        }

        string serverName;
        [Size(64)]
        public string ServerName {
            get {
                return serverName;
            }
            set {
                SetPropertyValue(nameof(ServerName), ref serverName, value);
            }
        }

        string serverIP;
        [Size(32)]
        public string ServerIP {
            get {
                return serverIP;
            }
            set {
                SetPropertyValue(nameof(ServerIP), ref serverIP, value);
            }
        }
    }
}