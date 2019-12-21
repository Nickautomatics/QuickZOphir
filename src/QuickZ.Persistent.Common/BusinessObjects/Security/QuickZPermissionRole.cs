using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using QuickZ.Core.Contracts.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Persistent.Common.Security
{
    [System.ComponentModel.DefaultProperty("Name")]
    [DevExpress.ExpressApp.DC.XafDisplayName("User Group")]
    //[DefaultClassOptions, ImageName("BO_Role")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class QuickZPermissionRole : PermissionPolicyRoleBase, ISystemObjectTarget ,IPermissionPolicyRoleWithUsers
    {


        public QuickZPermissionRole(Session session)
            : base(session) {
        }

        public QuickZPermissionRole(Session session, Guid guid)
            : this(session)
        {
            SetMemberValue("Oid", guid);
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        [Association("Users-PermissionRoles")]
        public XPCollection<QuickZUser> Users
        {
            get
            {
                return GetCollection<QuickZUser>("Users");
            }
        }

        IEnumerable<IPermissionPolicyUser> IPermissionPolicyRoleWithUsers.Users
        {
            get { return Users.OfType<IPermissionPolicyUser>(); }
        }

        public bool CanExport
        {
            get { return GetPropertyValue<bool>("CanExport"); }
            set { SetPropertyValue<bool>("CanExport", value); }
        }

        public bool CanPrint
        {
            get { return GetPropertyValue<bool>("CanPrint"); }
            set { SetPropertyValue<bool>("CanPrint", value); }
        }

        bool isSystemObject;
        public bool IsSystemObject
        {
            get
            {
                return isSystemObject;
            }
            set
            {
                SetPropertyValue("IsSystemObject", ref isSystemObject, value);
            }
        }
    }

    #region Export Permission
    public class ExportPermissionRequestProcessor : PermissionRequestProcessorBase<ExportPermissionRequest>
    {
        private IPermissionDictionary permissions;
        public ExportPermissionRequestProcessor(IPermissionDictionary permissions)
        {
            this.permissions = permissions;
        }
        public override bool IsGranted(ExportPermissionRequest permissionRequest)
        {
            return (permissions.FindFirst<ExportPermission>() != null);
        }
    }
    public class ExportPermission : IOperationPermission
    {
        public string Operation
        {
            get { return "Export"; }
        }
    }
    public class ExportPermissionRequest : IPermissionRequest
    {
        public object GetHashObject()
        {
            return this.GetType().FullName;
        }
    }
    #endregion

    #region Print Permission
    public class PrintPermissionRequestProcessor : PermissionRequestProcessorBase<PrintPermissionRequest>
    {
        private IPermissionDictionary permissions;
        public PrintPermissionRequestProcessor(IPermissionDictionary permissions)
        {
            this.permissions = permissions;
        }
        public override bool IsGranted(PrintPermissionRequest permissionRequest)
        {
            return (permissions.FindFirst<PrintPermission>() != null);
        }
    }
    public class PrintPermission : IOperationPermission
    {
        public string Operation
        {
            get { return "Print"; }
        }
    }

    public class PrintPermissionRequest : IPermissionRequest
    {
        public object GetHashObject()
        {
            return this.GetType().FullName;
        }
    }
    #endregion
}
