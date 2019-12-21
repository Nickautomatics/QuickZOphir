using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace  QuickZ.Persistent.Simple
{
    [System.ComponentModel.DefaultProperty("FullName")]
    [DevExpress.ExpressApp.DC.XafDisplayName("Person")]
    [ImageName("BO_Person")]
    [CalculatedPersistentAliasAttribute("FullName", "FullNamePersistentAlias")]
    [NonPersistent]
    public abstract class QuickZPersonBase : QuickZPartyBase, IPerson
    {
        private const string defaultFullNameFormat = "{FirstName} {MiddleName} {LastName}";
        private const string defaultFullNamePersistentAlias = "concat(FirstName, MiddleName, LastName)";
#if MediumTrust
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public PersonImpl person = new PersonImpl();
#else
        private PersonImpl person = new PersonImpl();
#endif
        static QuickZPersonBase()
        {
            PersonImpl.FullNameFormat = defaultFullNameFormat;
        }

        // public override QuickZAddressBase PrimaryAddress { get; set; }

        private static string fullNamePersistentAlias = defaultFullNamePersistentAlias;
        public static string FullNamePersistentAlias
        {
            get { return fullNamePersistentAlias; }
        }
        public static void SetFullNameFormat(string format, string persistentAlias)
        {
            PersonImpl.FullNameFormat = format;
            fullNamePersistentAlias = persistentAlias;
        }
        public QuickZPersonBase(Session session) : base(session) { }
        public QuickZPersonBase(Session session, Guid guid) : base(session, guid)
        { }
        public void SetFullName(string fullName)
        {
            person.SetFullName(fullName);
        }

        [DevExpress.Persistent.Validation.RuleRequiredField]
        [Persistent("FirstName")]
        public string FirstName
        {
            get { return person.FirstName; }
            set
            {
                string oldValue = person.FirstName;
                person.FirstName = value;
                OnChanged("FirstName", oldValue, person.FirstName);
            }
        }
        [DevExpress.Persistent.Validation.RuleRequiredField]
        [Persistent("LastName")]
        public string LastName
        {
            get { return person.LastName; }
            set
            {
                string oldValue = person.LastName;
                person.LastName = value;
                OnChanged("LastName", oldValue, person.LastName);
            }
        }
        public string MiddleName
        {
            get { return person.MiddleName; }
            set
            {
                string oldValue = person.MiddleName;
                person.MiddleName = value;
                OnChanged("MiddleName", oldValue, person.MiddleName);
            }
        }
        public DateTime Birthday
        {
            get { return person.Birthday; }
            set
            {
                DateTime oldValue = person.Birthday;
                person.Birthday = value;
                OnChanged("Birthday", oldValue, person.Birthday);
            }
        }
        private string _FullName;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDashboards(false)]
        [NonPersistent]
        //[ObjectValidatorIgnoreIssue(typeof(ObjectValidatorDefaultPropertyIsNonPersistentNorAliased)), SearchMemberOptions(SearchMemberMode.Include)]
        public string FullName
        {
            get {
                if (String.IsNullOrEmpty(_FullName))
                    _FullName = ObjectFormatter.Format(PersonImpl.FullNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
                return _FullName; }
            set
            {
                SetPropertyValue("FullName", ref _FullName, value);
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string DisplayName
        {
            get { return FullName; }
        }
        [Size(100)]
        public string Email
        {
            get { return person.Email; }
            set
            {
                string oldValue = person.Email;
                person.Email = value;
                OnChanged("Email", oldValue, person.Email);
            }
        }
    }
}
