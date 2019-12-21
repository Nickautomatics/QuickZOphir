using DevExpress.Data.Filtering;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using QuickZ.Persistent.Xpo.BusinessObjects.Multitenancy;
using System;
using System.Linq;

namespace QuickZ.Persistent.Common
{
    /// <summary>
    /// This can be assigned to any object that will be accessible to all Locations (e.g. Country, State, City
    /// </summary>
    [RuleObjectExists("SharedGlobalLocationSingletonExists", DefaultContexts.Save, "True", InvertResult = true,
    CustomMessageTemplate = "Shared Location object already exists.")]
    [RuleCriteria("CannotDeleteSharedGlobalLocationSingleton", DefaultContexts.Delete, "False",
    CustomMessageTemplate = "Cannot delete Shared Location object because it is being internally used by the system.")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class SharedGlobalLocation : QuickZLocationBase
    {
        public const string SharedGlobalLocationId = "932A3C9D-BA97-4E02-82A4-E157466FB50F";
        private static SharedGlobalLocation instance;
        public SharedGlobalLocation(Session session)
            : base(session)
        {
        }

        public SharedGlobalLocation(Session session, Guid guid) : base(session, guid)
        {

        }

        public static SharedGlobalLocation GetInstance(Session session)
        {
            instance = session.FindObject<SharedGlobalLocation>(CriteriaOperator.Parse("Oid = ?", new Guid(SharedGlobalLocationId)));
            if (instance == null)
            {
                instance = new SharedGlobalLocation(session, new Guid(SharedGlobalLocationId));
                instance.Name = "Shared Location";
                instance.IsSystemObject = true;
                instance.IsActive = true;
            }

            return instance;
        }
        public static SharedGlobalLocation Instance
        {
            get
            {
                return instance;
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }


    }
}