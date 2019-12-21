using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.Xpo;
using QuickZ.Core;
using QuickZ.Data;
using DevExpress.XtraBars.Navigation;
using DevExpress.Data.Filtering;
using QuickZ.Core.Models;
using QuickZ.Applications;
using QuickZ.LocalData;
using QuickZ.Data.Models;

namespace QuickZ.Localhub.Forms
{
    public partial class FormBusinessFileListView : XtraForm
    {
        IQuickZApplication activeApplication;
        IBusinessEngine businessEngine;
        public FormBusinessFileListView(IQuickZApplication application)
        {
            InitializeComponent();

            MainTileNavigationPane.SelectedElementChanged += MainTileNavigationPane_SelectedElementChanged;

            activeApplication = application;
            businessEngine = ((IBusinessEngine)QuickZDomainContext.Instance.ActiveBusinessEngine);

            SelectionResult = DatabaseSelectionResult.Exit;
            DataSession = new UnitOfWork((IDataLayer)businessEngine.LocalDataLayer);
            RefreshAccountsList(true);

            Width = 300;

            this.Text = $"QuickZ v{Application.ProductVersion}";

#if RELEASE || DEBUG
            MainTileNavigationPane.Visible = false;
#endif
        }

        private void MainTileNavigationPane_SelectedElementChanged(object sender, TileNavElementEventArgs e)
        {
            if (e.Element.Tile.Tag == null)
                return;

            previousSelectedAccount = selectedAccount;
            selectedAccount = e.Element.Tile.Tag as LocalAccount;

            previousSelectedAccount.IsLastSelectedAccount = false;
            selectedAccount.IsLastSelectedAccount = true;

            RefreshWorkspaceList(true);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            DataSession.CommitChanges();

        }
        public enum DatabaseSelectionResult
        {
            Selected,
            Exit
        }

        string targetConnectionString;
        public string TargetConnectionString
        {
            get { return targetConnectionString; }
            set
            {
                targetConnectionString = value;
            }
        }

        DatabaseSelectionResult selectionResult;
        public DatabaseSelectionResult SelectionResult
        {
            get { return selectionResult; }
            set
            {
                selectionResult = value;
            }
        }
        void RefreshAccountsList(bool isForceReload)
        {
            // --- Load existing Accounts
            var accounts = GetExistingAccounts(isForceReload);
            var localAccount = accounts.Where(a => a.Oid == new Guid(businessEngine.LocalAccountId)).FirstOrDefault();
            var previouslySelected = accounts.Where(a => a.IsLastSelectedAccount).FirstOrDefault();
            selectedAccount = previouslySelected ?? localAccount;

            TileNavCategory localAccountTile = null;
            MainTileNavigationPane.Categories.Clear();
            // --- Setup Tile Navigator for Accounts
            foreach (var item in accounts)
            {
                var newCategory = new TileNavCategory();
                newCategory.Caption = item.Name;
                newCategory.TileText = newCategory.Caption;
                newCategory.Tile.Tag = item;
                newCategory.Tile.AppearanceItem.Hovered.BackColor = Color.Green;
                newCategory.Tile.AppearanceItem.Hovered.BackColor2 = Color.GreenYellow;
                newCategory.Appearance.BackColor = Color.Green;
                newCategory.Appearance.BackColor2 = Color.GreenYellow;
                MainTileNavigationPane.Categories.Add(newCategory);

                // --- Get Default Local Account's Tile in case no Account has been previously selected
                if (item.Oid == new Guid(businessEngine.LocalAccountId))
                    localAccountTile = newCategory;

                if (previouslySelected != null)
                    if (item.Oid == previouslySelected.Oid)
                        MainTileNavigationPane.SelectedElement = newCategory;
            }

            // --- Set default Account
            if (previouslySelected == null)
                MainTileNavigationPane.SelectedElement = localAccountTile;

            RefreshWorkspaceList(isForceReload);

        }
        void RefreshWorkspaceList(bool isForceReload)
        {
            // --- Populate Workspaces
            TargetConnectionString = "";
            gridControl.DataSource = null;
            gridControl.DataSource = GetAvailableWorkspaces(selectedAccount, isForceReload);
            gridControl.RefreshDataSource();
            //gridControl.Refresh();
        }

        LocalAccount selectedAccount = null;
        LocalAccount previousSelectedAccount = null;

        void ProcessCommand(string command)
        {
            if (command == "Exit")
            {
                SelectionResult = DatabaseSelectionResult.Exit;
                Close();
            }

            if (command == "Select")
            {
                SelectionResult = DatabaseSelectionResult.Selected;
                TargetConnectionString = SelectedWorkspace.ConnectionString;

                // --- Notify Business Engine
                var busineEngine = ((IBusinessEngineComponent)activeApplication).ActiveBusinessEngine;
                busineEngine.ActiveEnterpriseAccountId = SelectedWorkspace.Account.Oid;
                busineEngine.ActiveEnterpriseWorkspaceId = SelectedWorkspace.Oid;
                busineEngine.ActiveWorkspaceCaption = SelectedWorkspace.SessionCaption;
                busineEngine.ActiveWorkspace = new WorkspaceBase
                {
                    Id = SelectedWorkspace.Oid,
                    Name = SelectedWorkspace.SessionCaption
                };


                // --- Update Main Workspace
                foreach (var ws in GetAvailableWorkspaces(selectedAccount, false))
                {
                    if (ws.Oid == SelectedWorkspace.Oid)
                        ws.IsLastActiveWorkSpace = true;
                    else
                        ws.IsLastActiveWorkSpace = false;
                }
                ((UnitOfWork)DataSession).CommitChanges();

                Hide(); // --- Do not use Close() because it disposes
            }

            if (command == "Refresh")
            {
                RefreshWorkspaceList(true);
            }
        }

        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            ProcessCommand(e.Button.Properties.Caption);
        }

        public LocalWorkspace SelectedWorkspace
        {
            get { return gridView.GetRow(gridView.FocusedRowHandle) as LocalWorkspace; }
        }

        UnitOfWork session;
        public UnitOfWork DataSession
        {
            get { return session; }
            set
            {
                session = value;
            }
        }

        XPCollection<LocalAccount> existingAccounts = null;
        /// <summary>
        /// For now, I am just generating dummy data
        /// </summary>
        /// <returns></returns>
        public XPCollection<LocalAccount> GetExistingAccounts(bool isForceReload)
        {
            if (existingAccounts == null || isForceReload)
                existingAccounts = new XPCollection<LocalAccount>(
                    PersistentCriteriaEvaluationBehavior.InTransaction,
                    DataSession,
                    null);
            //new SortProperty("Name", DevExpress.Xpo.DB.SortingDirection.Ascending));
            return existingAccounts;
        }

        XPCollection<LocalWorkspace> availableWorkspaces = null;
        /// <summary>
        /// For now, I am just generating dummy data
        /// </summary>
        /// <returns></returns>
        public XPCollection<LocalWorkspace> GetAvailableWorkspaces(LocalAccount account, bool isForceReload)
        {
            if (account == null)
                return null;

            if (businessEngine.Workspaces == null)
                businessEngine.Workspaces = new List<WorkspaceBase>();

            if (availableWorkspaces == null || isForceReload)
            {
                availableWorkspaces = new XPCollection<LocalWorkspace>(
                                            PersistentCriteriaEvaluationBehavior.InTransaction,
                                            DataSession,
                                            CriteriaOperator.Parse("Account.Oid = ?", account.Oid));

                ((List<WorkspaceBase>)businessEngine.Workspaces).Clear();
                foreach (var wp in availableWorkspaces)
                {
                    ((List<WorkspaceBase>)businessEngine.Workspaces).Add(new WorkspaceBase { Id = wp.Oid, Name = wp.Name });
                }

            }
            return availableWorkspaces;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ProcessCommand("Select");
        }
    }
}
