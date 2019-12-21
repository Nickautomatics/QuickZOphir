using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.XtraEditors;
using QuickZ.Security.BasicWin;
using DevExpress.Persistent.Base.Security;
using System.Windows.Forms;
using QuickZ.Core;
using QuickZ.ExpressApp.Win;
using QuickZ.ExpressApp.Win.Extensions;
using QuickZ.ExpressApp;
using QuickZ.Applications;
using DevExpress.ExpressApp.Win;
using QuickZ.Persistent.Common.Security;
using QuickZ.Core.SettingsHub;

namespace QuickZ.Security
{

    public class QuickZAuthentication : AuthenticationBase, IAuthenticationStandard
    {

        private bool isLogonFailed;
        private QuickZLoginForm logonForm;
        private QuickZLogonParameter localParameters;
        
        public QuickZAuthentication()
        {
            localParameters = new QuickZLogonParameter();
            logonForm = new QuickZLoginForm(this);
            UserType = typeof(QuickZUser);
        }

        private QuickZLoginForm LogonForm
        {
            get { return logonForm; }
            set
            {
                logonForm = value;
            }
        }

        public void HideWarning()
        {
            logonForm.HideWarning();
        }
        public void ShowWarning()
        {
            logonForm.ShowWarning();
        }

        public void SetPassword(string password)
        {
            if (localParameters != null)
                localParameters.Password = password;
            LogonForm.SetPassword(password);
        }

        public DialogResult ShowLogonForm(bool isShowWarning = false, bool isClearPwd = false)
        {
            ((WinApplication)QuickZDomainContext.Instance.ActiveApplication).StopSplash();

            RefreshWorkSpaces(settingsHub);

            logonForm.DialogResult = DialogResult.None;

            if (isClearPwd) logonForm.ClearPasswordField();
            if (isShowWarning) logonForm.ShowWarning();

            logonForm.ShowDialog();
            if (logonForm.DialogResult == DialogResult.OK)
            {
                if (localParameters != null)
                {
                    localParameters.UserName = logonForm.UserName;
                    localParameters.Password = logonForm.Password;
                }
                ((WinApplication)QuickZDomainContext.Instance.ActiveApplication).ConnectionString = logonForm.ConnectionString;
                BusinessEngine.Instance.Workspaces = logonForm.Workspaces;
                if (isShowWarning) logonForm.HideWarning();
            }
            else
            {
                ((IBusinessEngine)QuickZDomainContext.Instance).ForceApplicationExit();
            }

            return logonForm.DialogResult;
        }

        public override void Logoff()
        {
            base.Logoff();
        }
        public override void ClearSecuredLogonParameters()
        {
            localParameters.Password = "";
            base.ClearSecuredLogonParameters();
        }
        public override object Authenticate(IObjectSpace objectSpace)
        {
            return AuthenticateStandard(objectSpace);
        }

        private object AuthenticateStandard(IObjectSpace objectSpace)
        {
            if (string.IsNullOrEmpty(localParameters.UserName))
                throw new ArgumentException(SecurityExceptionLocalizer.GetExceptionMessage(SecurityExceptionId.UserNameIsEmpty));

            var user = (IAuthenticationStandardUser)objectSpace.FindObject(UserType, new BinaryOperator("UserName", localParameters.UserName));

            if (user == null || !user.ComparePassword(localParameters.Password))
            {
                throw new AuthenticationException(localParameters.UserName, SecurityExceptionLocalizer.GetExceptionMessage(SecurityExceptionId.RetypeTheInformation));
            }
            return user;
        }

        public override void SetLogonParameters(object logonParameters)
        {
            localParameters = (QuickZLogonParameter)logonParameters;
        }
        public override IList<Type> GetBusinessClasses()
        {
            return new Type[] { typeof(QuickZLogonParameter) };
        }
        public override bool AskLogonParametersViaUI
        {
            get
            {
                return false;
            }
        }

        public override Type UserType
        {
            get
            {
                return typeof(QuickZUser); 
            }
            set
            {
                base.UserType = typeof(QuickZUser); 
            }
        }
        public override object LogonParameters
        {
            get { return localParameters; }
        }
        public override bool IsLogoffEnabled
        {
            get { return true; }
        }

        public string UserName
        {
            get
            {
                return logonForm.UserName;
            }
            set
            {
                logonForm.UserName = value;
            }
        }
        public string Password
        {
            get
            {
                return logonForm.Password;
            }
            set
            {
                logonForm.Password = value;
            }
        }

    }
}
