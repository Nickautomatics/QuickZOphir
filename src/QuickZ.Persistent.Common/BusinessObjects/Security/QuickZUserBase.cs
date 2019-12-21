using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.Collections.ObjectModel;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base.Security;
using System.Linq;
using DevExpress.ExpressApp.Security;
using QuickZ.Persistent.Common;

namespace QuickZ.Persistent.Common.Security
{
    [ImageName("BO_User"), DefaultProperty("UserName")]
    [Persistent("SecurityUserAccount")]
    [System.ComponentModel.DisplayName("User Account")]
    public  abstract class QuickZUser : QuickZLiteGuidObject, ISecurityUser, IAuthenticationActiveDirectoryUser, IAuthenticationStandardUser , IPermissionPolicyUser, ISecurityUserWithRoles
    {
        public QuickZUser(Session session)
            : base(session)
        {
        }

        public QuickZUser(Session session, Guid guid) : base(session, guid)
        {

        }

        protected virtual IEnumerable<ISecurityRole> GetSecurityRoles()
        {
            IList<ISecurityRole> result = new List<ISecurityRole>();
            foreach (QuickZPermissionRole role in Roles)
            {
                result.Add(role);
            }
            return new ReadOnlyCollection<ISecurityRole>(result);
        }
        [Association("Users-PermissionRoles")]
        [RuleRequiredField("PermissionPolicyUser_Roles_RuleRequiredField", DefaultContexts.Save, TargetCriteria = "IsActive=True", CustomMessageTemplate = "An active user must have at least one role assigned")]
        public XPCollection<QuickZPermissionRole> Roles
        {
            get
            {
                return GetCollection<QuickZPermissionRole>("Roles");
            }
        }
        IList<ISecurityRole> ISecurityUserWithRoles.Roles
        {
            get
            {
                IList<ISecurityRole> result = new List<ISecurityRole>();
                foreach (QuickZPermissionRole role in GetSecurityRoles())
                {
                    result.Add(role);
                }
                return new ReadOnlyCollection<ISecurityRole>(result);
            }
        }
        IEnumerable<IPermissionPolicyRole> IPermissionPolicyUser.Roles
        {
            get
            {
                return Roles.OfType<IPermissionPolicyRole>();
            }
        }
        private string userName = string.Empty;
        private bool isActive = true;
        private string storedPassword;
        private bool changePasswordOnFirstLogon = false;
        [Browsable(false)]
        [Size(SizeAttribute.Unlimited)]
        [Persistent]
        [SecurityBrowsable]
        public string StoredPassword
        {
            get { return storedPassword; }
            set { SetPropertyValue("StoredPassword", ref storedPassword, value); }
        }
        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set { SetPropertyValue("ChangePasswordOnFirstLogon", ref changePasswordOnFirstLogon, value); }
        }
        [RuleRequiredField("PermissionPolicyUser_UserName_RuleRequiredField", DefaultContexts.Save)]
        [RuleUniqueValue("PermissionPolicyUser_UserName_RuleUniqueValue", DefaultContexts.Save, "The login with the entered user name was already registered within the system")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }
        public bool ComparePassword(string password)
        {
            return PasswordCryptographer.VerifyHashedPasswordDelegate(storedPassword, password);
        }
        public void SetPassword(string password)
        {
            StoredPassword = PasswordCryptographer.HashPasswordDelegate(password);
        }
    }
}
