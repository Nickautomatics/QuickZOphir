using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Templates.ActionControls;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Controls;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.Templates.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using QuickZ.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuickZ.Themes.SlackifyWin.Templates
{
    public partial class SlackifyLightStyleMainRibbonForm : DevExpress.XtraEditors.XtraForm, IActionControlsSite, IContextMenuHolder, IWindowTemplate, IDockManagerHolder, IBarManagerHolder, ISupportViewChanged, IXafDocumentsHostWindow, ISupportUpdate, IViewSiteTemplate, ISupportStoreSettings, IViewHolder
    {
        private static readonly object viewChanged = new object();
        private static readonly object settingsReloaded = new object();
        private UIType uiType;
        private StatusMessagesHelper statusMessagesHelper;

        static Control settingsContainer;
        public static Control SettingsContainer
        {
            get
            {
                return settingsContainer;
            }
            set
            {

                settingsContainer = value;
            }
        }

        public SlackifyLightStyleMainRibbonForm()
        {
            InitializeComponent();

            // --- Experiment
            SettingsContainer = (Control)SettingsNavigationPage;

            InitializeImages();
            SynchronizeBarAndDockingControllerWithDefault();
            SlackifyXafMasterContainer.MainRibbonControl.Manager.ForceLinkCreate();
            statusMessagesHelper = new StatusMessagesHelper(barContainerStatusMessages);
            OnUITypeChanged();
            new NavBarControlVisibilityHelper(navBarControl, SlackifyXafMasterContainer.barSubItemNavigationPane);

            // --- Setup status bar
            this.ribbonStatusBar.Ribbon = SlackifyXafMasterContainer.MainRibbonControl;
            SlackifyXafMasterContainer.MainRibbonControl.StatusBar = ribbonStatusBar;
            SlackifyXafMasterContainer.MainRibbonControl.ActionContainers.Add(this.barActionContainerNotifications);
            SlackifyXafMasterContainer.MainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {             
                this.barContainerNotifications,
                this.barContainerStatusMessages
            });

            // --- Setup NavigationPane (Side) Alignment
            var prop = typeof(NavigationPane).GetField("buttonsPanelCore", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var panel = prop.GetValue(MainSideNavigationPane) as NavigationPaneButtonsPanel;
            panel.ContentAlignment = System.Drawing.ContentAlignment.BottomLeft;            

            // CustomNavigationButton button = new CustomNavigationButton(navigationPane1);
            //ButtonsPanel buttonPanel = (navigationPane1 as INavigationPane).ButtonsPanel as ButtonsPanel;
            //buttonPanel.Buttons.Insert(0, button);
            //buttonPanel.ContentAlignment = System.Drawing.ContentAlignment.


            navBarControl.ActiveGroupChanged += NavBarControl_ActiveGroupChanged;

        }

        private void NavBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            HomeNavigationPage.Caption = e.Group.Caption;
        }

        protected virtual void InitializeImages()
        {
            SlackifyXafMasterContainer.barMdiChildrenListItem.Glyph = ImageLoader.Instance.GetImageInfo("Action_WindowList").Image;
            SlackifyXafMasterContainer.barMdiChildrenListItem.LargeGlyph = ImageLoader.Instance.GetLargeImageInfo("Action_WindowList").Image;
            SlackifyXafMasterContainer.barSubItemPanels.Glyph = ImageLoader.Instance.GetImageInfo("Action_Navigation").Image;
            SlackifyXafMasterContainer.barSubItemPanels.LargeGlyph = ImageLoader.Instance.GetLargeImageInfo("Action_Navigation").Image;
            SlackifyXafMasterContainer.barSubItemNavigationPane.Glyph = ImageLoader.Instance.GetImageInfo("NavigationOptions").Image;
            SlackifyXafMasterContainer.barSubItemNavigationPane.LargeGlyph = ImageLoader.Instance.GetLargeImageInfo("NavigationOptions").Image;
        }
        protected virtual void SynchronizeBarAndDockingControllerWithDefault()
        {
            SlackifyXafMasterContainer.mainBarAndDockingController.PropertiesBar.ScaleEditors = BarAndDockingController.Default.PropertiesBar.ScaleEditors;
            SlackifyXafMasterContainer.mainBarAndDockingController.PropertiesRibbon.ScaleEditors = BarAndDockingController.Default.PropertiesRibbon.ScaleEditors;
        }
        protected virtual void OnUITypeChanged()
        {
            UIType uiType = ((IXafDocumentsHostWindow)this).UIType;
            if (uiType == UIType.TabbedMDI)
            {
                SetupTabbedMdi();
            }
            else if (uiType == UIType.StandardMDI)
            {
                SetupStandardMdi();
            }
            else
            {
                SetupSdi();
            }
        }
        protected void SetupSdi()
        {
            SlackifyXafMasterContainer.MainRibbonControl.MdiMergeStyle = RibbonMdiMergeStyle.Never;
            SlackifyXafMasterContainer.documentManager.View = SlackifyXafMasterContainer.noDocumentsView;
            SlackifyXafMasterContainer.documentManager.ViewCollection.Remove(SlackifyXafMasterContainer.nativeMdiView);
            SlackifyXafMasterContainer.documentManager.ViewCollection.Remove(SlackifyXafMasterContainer.tabbedView);
            SlackifyXafMasterContainer.viewSitePanel.Visible = true;
            SlackifyXafMasterContainer.documentManager.ClientControl = SlackifyXafMasterContainer.viewSitePanel;
            SlackifyXafMasterContainer.barMdiChildrenListItem.Visibility = BarItemVisibility.Never;
        }
        protected void SetupStandardMdi()
        {
            SlackifyXafMasterContainer.MainRibbonControl.MdiMergeStyle = RibbonMdiMergeStyle.OnlyWhenMaximized;
            SlackifyXafMasterContainer.documentManager.View = SlackifyXafMasterContainer.nativeMdiView;
            SlackifyXafMasterContainer.documentManager.ViewCollection.Remove(SlackifyXafMasterContainer.noDocumentsView);
            SlackifyXafMasterContainer.documentManager.ViewCollection.Remove(SlackifyXafMasterContainer.tabbedView);
            SetupMdiCommon();
        }
        protected void SetupTabbedMdi()
        {
            SlackifyXafMasterContainer.MainRibbonControl.MdiMergeStyle = RibbonMdiMergeStyle.Always;
            SlackifyXafMasterContainer.documentManager.View = SlackifyXafMasterContainer.tabbedView;
            SlackifyXafMasterContainer.documentManager.ViewCollection.Remove(SlackifyXafMasterContainer.noDocumentsView);
            SlackifyXafMasterContainer.documentManager.ViewCollection.Remove(SlackifyXafMasterContainer.nativeMdiView);
            SetupMdiCommon();
        }
        private void SetupMdiCommon()
        {
            SlackifyXafMasterContainer.viewSitePanel.Visible = false;
            SlackifyXafMasterContainer.documentManager.MdiParent = this;
            SlackifyXafMasterContainer.barMdiChildrenListItem.Visibility = BarItemVisibility.Always;
        }

        protected virtual void RaiseViewChanged(DevExpress.ExpressApp.View view)
        {
            EventHandler<TemplateViewChangedEventArgs> handler = (EventHandler<TemplateViewChangedEventArgs>)Events[viewChanged];
            if (handler != null)
            {
                handler(this, new TemplateViewChangedEventArgs(view));
            }
        }
        protected virtual void RaiseSettingsReloaded()
        {
            EventHandler handler = (EventHandler)Events[settingsReloaded];
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected override FormShowMode ShowMode
        {
            get { return FormShowMode.AfterInitialization; }
        }

        #region IActionControlsSite Members
        IEnumerable<IActionControlContainer> IActionControlsSite.ActionContainers
        {
            get { return SlackifyXafMasterContainer.MainRibbonControl.ActionContainers; }
        }
        IEnumerable<IActionControl> IActionControlsSite.ActionControls
        {
            get
            {
                List<IActionControl> actionControls = new List<IActionControl>(SlackifyXafMasterContainer.MainRibbonControl.ActionControls);
                actionControls.Add(navBarControl.ActionControl);
                return actionControls;
            }
        }
        IActionControlContainer IActionControlsSite.DefaultContainer
        {
            get { return SlackifyXafMasterContainer.barActionContainerDefault; }
        }
        #endregion

        #region IFrameTemplate Members
        void IFrameTemplate.SetView(DevExpress.ExpressApp.View view)
        {
            SlackifyXafMasterContainer.viewSiteManager.SetView(view);
            RaiseViewChanged(view);
        }
        ICollection<IActionContainer> IFrameTemplate.GetContainers()
        {
            return new IActionContainer[] { };
        }
        IActionContainer IFrameTemplate.DefaultContainer
        {
            get { return null; }
        }
        #endregion

        #region IWindowTemplate Members
        void IWindowTemplate.SetCaption(string caption)
        {

            var activeApp = ((XafApplication)QuickZDomainContext.Instance.ActiveApplication);
            var tenantName = QuickZDomainContext.Instance.TenantName;
            var modCaption = caption.Replace("- " + activeApp.ApplicationName, "");

            SlackifyXafMasterContainer.MainRibbonControl.ApplicationCaption = " ";
            SlackifyXafMasterContainer.MainRibbonControl.ApplicationDocumentCaption = modCaption;

            NavCompanyNameButton.Caption = tenantName;

            this.Text = activeApp.ApplicationName + " - " + SlackifyXafMasterContainer.MainRibbonControl.ApplicationDocumentCaption;
            NavDocumentCaptionButton.Caption = SlackifyXafMasterContainer.MainRibbonControl.ApplicationDocumentCaption;

        }
        void IWindowTemplate.SetStatus(ICollection<string> statusMessages)
        {
            statusMessagesHelper.SetMessages(statusMessages);
        }
        bool IWindowTemplate.IsSizeable
        {
            get { return FormBorderStyle == FormBorderStyle.Sizable; }
            set { FormBorderStyle = (value ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog); }
        }
        #endregion

        #region IBarManagerHolder Members
        BarManager IBarManagerHolder.BarManager
        {
            get { return SlackifyXafMasterContainer.MainRibbonControl.Manager; }
        }
        event EventHandler IBarManagerHolder.BarManagerChanged
        {
            add { }
            remove { }
        }
        #endregion

        #region IDockManagerHolder Members
        DevExpress.XtraBars.Docking.DockManager IDockManagerHolder.DockManager
        {
            get { return SlackifyXafMasterContainer.dockManager; }
        }
        #endregion

        #region IContextMenuHolder
        PopupMenu IContextMenuHolder.ContextMenu
        {
            get { return SlackifyXafMasterContainer.contextMenu; }
        }
        #endregion

        #region ISupportViewChanged Members
        event EventHandler<TemplateViewChangedEventArgs> ISupportViewChanged.ViewChanged
        {
            add { Events.AddHandler(viewChanged, value); }
            remove { Events.RemoveHandler(viewChanged, value); }
        }
        #endregion

        #region IDocumentsHostWindow Members
        bool IDocumentsHostWindow.DestroyOnRemovingChildren
        {
            get { return true; }
        }
        DocumentManager IDocumentsHostWindow.DocumentManager
        {
            get { return SlackifyXafMasterContainer.documentManager; }
        }
        #endregion

        #region IXafDocumentsHostWindow Members
        UIType IXafDocumentsHostWindow.UIType
        {
            get { return uiType; }
            set
            {
                if (uiType != value)
                {
                    uiType = value;
                    OnUITypeChanged();
                }
            }
        }
        #endregion

        #region ISupportUpdate Members
        void ISupportUpdate.BeginUpdate()
        {
            if (SlackifyXafMasterContainer.MainRibbonControl.Manager != null)
            {
                SlackifyXafMasterContainer.MainRibbonControl.Manager.BeginUpdate();
            }
        }
        void ISupportUpdate.EndUpdate()
        {
            if (SlackifyXafMasterContainer.MainRibbonControl.Manager != null)
            {
                SlackifyXafMasterContainer.MainRibbonControl.Manager.EndUpdate();
            }
        }
        #endregion

        #region IViewSiteTemplate Members
        object IViewSiteTemplate.ViewSiteControl
        {
            get { return SlackifyXafMasterContainer.viewSiteManager.ViewSiteControl; }
        }
        #endregion

        #region ISupportStoreSettings Members
        void ISupportStoreSettings.SetSettings(IModelTemplate settings)
        {
            IModelTemplateWin templateModel = (IModelTemplateWin)settings;
            TemplatesHelper templatesHelper = new TemplatesHelper(templateModel);
            formStateModelSynchronizer.Model = templatesHelper.GetFormStateNode();
            navBarControlModelSynchronizer.Model = templatesHelper.GetNavBarCustomizationNode();
            templatesHelper.SetRibbonSettings(SlackifyXafMasterContainer.MainRibbonControl);
        }
        void ISupportStoreSettings.ReloadSettings()
        {
            modelSynchronizationManager.ApplyModel();
            RaiseSettingsReloaded();
        }
        void ISupportStoreSettings.SaveSettings()
        {
            SuspendLayout();
            try
            {
                modelSynchronizationManager.SynchronizeModel();
            }
            finally
            {
                ResumeLayout();
            }
        }
        event EventHandler ISupportStoreSettings.SettingsReloaded
        {
            add { Events.AddHandler(settingsReloaded, value); }
            remove { Events.RemoveHandler(settingsReloaded, value); }
        }
        #endregion

        #region IViewHolder Members
        DevExpress.ExpressApp.View IViewHolder.View
        {
            get { return SlackifyXafMasterContainer.viewSiteManager.View; }
        }
        #endregion

        private void NavMainButton_ElementClick(object sender, NavElementEventArgs e)
        {
            MainSideNavigationPane.SelectedPageIndex = 0;
        }
    }
}
