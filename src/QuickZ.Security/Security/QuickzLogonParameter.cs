using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Runtime.Serialization;
using System;
using QuickZ.Persistent.Common.Security;

namespace QuickZ.Security
{
    [DomainComponent, Serializable]
    public class QuickZLogonParameter : ISerializable, INotifyPropertyChanged
    {

        private string _Password;
        private QuickZUser _QuickZUserAccount;

        [Browsable(false)]
        public QuickZUser QuickZUserAccount
        {
            get { return _QuickZUserAccount; }
            set
            {
                if (_QuickZUserAccount == value || value == null) return;
                _QuickZUserAccount = value;
                UserName = QuickZUserAccount.UserName;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(QuickZUserAccount)));
            }
        }

        public QuickZLogonParameter() { }
        // ISerializable 
        public QuickZLogonParameter(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount > 0)
            {
                UserName = info.GetString("UserName");
                Password = info.GetString("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [System.Security.SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("UserName", UserName);
            info.AddValue("Password", Password);
        }

        [Browsable(false)]
        string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName == value)
                    return;
                userName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(UserName)));
            }
        }
        

        [PasswordPropertyText(true)]
        string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password == value)
                    return;
                password = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }
        
        private IObjectSpace objectSpace;

        [Browsable(false)]

        public IObjectSpace ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
    }
}
