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
using QuickZ.SettingsHub;
using DevExpress.XtraBars.Navigation;
using DevExpress.Data.Filtering;
using QuickZ.Core.Models;
using QuickZ.SettingsHub.XML;
using QuickZ.Applications;
using QuickZ.LocalData;
using QuickZ.Data.Models;

namespace QuickZ.SettingsHub.Forms
{
    public partial class FormWorkspaceListView : XtraForm
    {
        IQuickzApplication activeApplication;
        SettingsHubXmlData xmlSettingsHub = null;

        public FormWorkspaceListView(IQuickzApplication application)
        {
            InitializeComponent();

            Text = $"QuickZ Version: {Application.ProductVersion}";
            Width = 300;
            SelectionResult = DatabaseSelectionResult.Exit;

            activeApplication = application;            

            RefreshWorkspaceList(true);

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
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

        void RefreshWorkspaceList(bool isForceReload)
        {
            // --- Populate Workspaces
            TargetConnectionString = "";
            gridControl.DataSource = null;
            gridControl.DataSource = GetAvailableWorkspaces(isForceReload);
            gridControl.RefreshDataSource();
            //gridControl.Refresh();
        }

        public XmlWorkspace SelectedWorkspace
        {
            get { return gridView.GetRow(gridView.FocusedRowHandle) as XmlWorkspace; }
        }

        List<XmlWorkspace> availableWorkspaces = null;
        /// <summary>
        /// For now, I am just generating dummy data
        /// </summary>
        /// <returns></returns>
        public List<XmlWorkspace> GetAvailableWorkspaces(bool isForceReload)
        {
            var busineEngine = (IBusinessEngine)QuickzDomainContext.Instance.ActiveBusinessEngine;

            if (availableWorkspaces == null || isForceReload)
            {
                availableWorkspaces = xmlSettingsHub.Container.Workspaces;

                // --- Always clear all Workspaces from SettingsHub cache
                ((List<WorkspaceBase>)busineEngine.Workspaces).Clear();
                foreach (var wp in availableWorkspaces)
                {
                    ((List<WorkspaceBase>)busineEngine.Workspaces).Add(new WorkspaceBase { Id = Guid.NewGuid(), Name = wp.Name });
                }
            }
            return availableWorkspaces;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            OnSelectClicked(sender, e);
        }

        private void OnSelectClicked(object sender, EventArgs e)
        {
            SelectionResult = DatabaseSelectionResult.Selected;
            TargetConnectionString = SelectedWorkspace.ConnectionString;

            // --- Notify Business Engine
            var busineEngine = ((IBusinessEngineComponent)activeApplication).ActiveBusinessEngine;
            busineEngine.ActiveEnterpriseAccountId = Guid.Empty;
            busineEngine.ActiveEnterpriseWorkspaceId = SelectedWorkspace.Id;
            busineEngine.ActiveWorkspaceCaption = SelectedWorkspace.Name;
            busineEngine.ActiveWorkspace = new WorkspaceBase
            {
                Id = SelectedWorkspace.Id,
                Name = SelectedWorkspace.Name
            };


            // --- Update Main Workspace
            foreach (var ws in availableWorkspaces)
            {
                if (ws.Id == SelectedWorkspace.Id)
                    ws.IsLastActiveWorkSpace = true;
                else
                    ws.IsLastActiveWorkSpace = false;
            }
                

            Hide(); // --- Do not use Close() because it disposes
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            SelectionResult = DatabaseSelectionResult.Exit;
            Close();
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            RefreshWorkspaceList(true);
        }
    }
}
