using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Filtering;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Linq;

namespace QuickZ.Persistent.Business
{
    [System.ComponentModel.DefaultProperty("FullName")]
    [DevExpress.ExpressApp.DC.XafDisplayName("People")]
    [ImageName("BO_Person")]
    [CalculatedPersistentAliasAttribute("FullName", "FullNamePersistentAlias")]
    [NonPersistent]
    [DomainComponent]
    public abstract class Person : Party
    {
        private const string defaultFullNameFormat = "{FirstName} {MiddleName} {LastName}";
        private const string defaultFullNamePersistentAlias = "concat(FirstName, MiddleName, LastName)";
#if MediumTrust
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public PersonImpl person = new PersonImpl();
#else
        private PersonImpl person = new PersonImpl();
#endif

        public Person(Session session) : base(session) { }
        public Person(Session session, Guid guid) : base(session, guid)
        { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Name
        {
            get { return FullName; }
        }

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
                OnChanged(nameof(FirstName), oldValue, person.FirstName);
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
                OnChanged(nameof(LastName), oldValue, person.LastName);
            }
        }
        public string MiddleName
        {
            get { return person.MiddleName; }
            set
            {
                string oldValue = person.MiddleName;
                person.MiddleName = value;
                OnChanged(nameof(MiddleName), oldValue, person.MiddleName);
            }
        }
        public DateTime? Birthday
        {
            get { return person.Birthday; }
            set
            {
                DateTime oldValue = person.Birthday;
                person.Birthday = value.Value;
                OnChanged(nameof(Birthday), oldValue, person.Birthday);
            }
        }
        private string _FullName;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDashboards(false)]
        [NonPersistent]
        [ObjectValidatorIgnoreIssue(typeof(ObjectValidatorDefaultPropertyIsNonPersistentNorAliased)), SearchMemberOptions(SearchMemberMode.Include)]
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
