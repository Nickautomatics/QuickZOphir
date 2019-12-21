using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using QuickZ.Persistent.Common;
using System;
using System.ComponentModel;

namespace  QuickZ.Persistent.Simple
{
    [XafDisplayName("Address")]
    [DefaultProperty("FullAddress")]
    [CalculatedPersistentAliasAttribute("FullAddress", "FullAddressPersistentAlias")]
    [Persistent("PhysicalAddress")]
    public abstract class QuickZAddressBase : QuickZSimpleAuditGuidObject, IAddress
    {
        private const string defaultFullAddressFormat = "{Country.Name}; {StateProvince}; {City}; {Street}; {ZipPostal}";
        private const string defaultfullAddressPersistentAlias = "concat(Country.Name, StateProvince, City, Street, ZipPostal)";
        static QuickZAddressBase()
        {
            AddressImpl.FullAddressFormat = defaultFullAddressFormat;
        }
        public QuickZAddressBase(Session session) : base(session) { }

        public QuickZAddressBase(Session session, Guid guid) : base(session, guid)
        {

        }

        private static string fullAddressPersistentAlias = defaultfullAddressPersistentAlias;
        private AddressImpl address = new AddressImpl();
        public static string FullAddressPersistentAlias
        {
            get { return fullAddressPersistentAlias; }
        }
        public static void SetFullAddressFormat(string format, string persistentAlias)
        {
            AddressImpl.FullAddressFormat = format;
            fullAddressPersistentAlias = persistentAlias;
        }
        public string Street
        {
            get { return address.Street; }
            set
            {
                string oldValue = address.Street;
                address.Street = value;
                OnChanged("Street", oldValue, address.Street);
            }
        }
        public string City
        {
            get { return address.City; }
            set
            {
                string oldValue = address.City;
                address.City = value;
                OnChanged("City", oldValue, address.City);
            }
        }
        public string StateProvince
        {
            get { return address.StateProvince; }
            set
            {
                string oldValue = address.StateProvince;
                address.StateProvince = value;
                OnChanged("StateProvince", oldValue, address.StateProvince);
            }
        }
        public string ZipPostal
        {
            get { return address.ZipPostal; }
            set
            {
                string oldValue = address.ZipPostal;
                address.ZipPostal = value;
                OnChanged("ZipPostal", oldValue, address.ZipPostal);
            }
        }
        ICountry IAddress.Country
        {
            get { return Country; }
            set
            {                
                Country = (QuickZCountryBase)value;
            }
        }
        public QuickZCountryBase Country
        {
            get { return address.Country as QuickZCountryBase; }
            set
            {
                ICountry oldValue = address.Country;
                address.Country = value as ICountry;
                OnChanged("Country", oldValue, address.Country);
            }
        }
        public virtual string FullAddress
        {
            get { return ObjectFormatter.Format(AddressImpl.FullAddressFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }
    }
}
