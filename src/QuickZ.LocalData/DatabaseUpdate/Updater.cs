using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using QuickZ.Applications;
using QuickZ.Core;
using QuickZ.Core.Enums;

namespace QuickZ.LocalData.DatabaseUpdate {
    public class QuickZLocalDataUpdater : ModuleUpdater {
        public QuickZLocalDataUpdater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            // --- Make sure that a Local Account always exists
            // NOTE: No longer used due to a shift to a more simplified licensing strategy
            CreateLocalAccount((IBusinessEngine)QuickZDomainContext.Instance.ActiveBusinessEngine);
        }

        public void CreateLocalAccount(IBusinessEngine businessEngine)
        {
            var engine = (IBusinessEngine)QuickZDomainContext.Instance.ActiveBusinessEngine;

            // REJOICE: No need for this since we're now loading configuration data from Settings folder
            var session = new UnitOfWork((IDataLayer)((IBusinessEngine)QuickZDomainContext.Instance.ActiveBusinessEngine).LocalDataLayer);

            // --- Verify that local account does not exist          
            var localAccount = session.FindObject<LocalAccount>(CriteriaOperator.Parse("Oid = ?", new Guid(engine.LocalAccountId))); // Evaluate(typeof(LocalBusinessFile), DevExpress.Data.Filtering.CriteriaOperator.Parse("Count()"), null);
            if (localAccount == null)
            {
                // --- Create Local Account (default account for new Users)
                localAccount = new LocalAccount(session, new Guid(engine.LocalAccountId), engine.LocalAccountName);
                session.CommitChanges();
            }

            // --- Create default Workspace for Local Account
            var defaultWorkspace = session.FindObject<LocalWorkspace>(
                CriteriaOperator.Parse("Oid = ? AND Account.Oid = ?", new Guid(engine.DefaultLocalWorkspaceId), localAccount.Oid)
            );

            if (defaultWorkspace == null)
            {
                defaultWorkspace = new LocalWorkspace(session, new Guid(engine.DefaultLocalWorkspaceId), localAccount)
                {
                    Name = engine.DefaultLocalWorkspaceName,
                    IsLocal = true,
                    DataStorageType = DataStorageTypeEnum.XML,
                    XmlFile = engine.GetAccountWorspaceFolder(engine.DefaultDataFolder, localAccount.Name)
                };
                session.CommitChanges();
            }
            localAccount.Workspaces.Add(defaultWorkspace);

            // --- Create default WorkspaceSession for Local Account
            var defaultWorkspaceSession = session.FindObject<LocalStash>(CriteriaOperator
                .Parse("Oid = ? AND Workspace.Oid = ?",
                    new Guid(engine.DefaultWorkspaceSessionId), defaultWorkspace.Oid
                )
            );

            if (defaultWorkspaceSession == null)
            {
                defaultWorkspaceSession = new LocalStash(
                    session, new Guid(engine.DefaultWorkspaceSessionId), localAccount, defaultWorkspace, defaultWorkspace.SessionCaption
                );
                session.CommitChanges();
            }
        }
    }
}
