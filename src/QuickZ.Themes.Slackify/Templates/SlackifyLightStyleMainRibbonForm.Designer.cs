namespace QuickZ.Themes.SlackifyWin.Templates
{
    partial class SlackifyLightStyleMainRibbonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlackifyLightStyleMainRibbonForm));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barContainerStatusMessages = new DevExpress.XtraBars.BarLinkContainerExItem();
            this.barContainerNotifications = new DevExpress.XtraBars.BarLinkContainerExItem();
            this.barActionContainerNotifications = new DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer();
            this.MainSideNavigationPane = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.HomeNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navBarControl = new DevExpress.ExpressApp.Win.Templates.Navigation.XafNavBarControl();
            this.navBarSingleChoiceActionControl = new DevExpress.ExpressApp.Win.Templates.Navigation.NavBarSingleChoiceActionControl();
            this.SettingsNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.SlackifyXafMasterContainer = new QuickZ.Themes.SlackifyWin.Templates.SlackifyXafMasterContainer();
            this.MainTileNavigationPane = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.NavMainButton = new DevExpress.XtraBars.Navigation.NavButton();
            this.NavCompanyNameButton = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton2 = new DevExpress.XtraBars.Navigation.NavButton();
            this.NavDocumentCaptionButton = new DevExpress.XtraBars.Navigation.NavButton();
            this.formStateModelSynchronizer = new DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer();
            this.modelSynchronizationManager = new DevExpress.ExpressApp.Win.Templates.ModelSynchronizationManager();
            this.navBarControlModelSynchronizer = new DevExpress.ExpressApp.Win.Templates.Navigation.NavBarControlModelSynchronizer();
            ((System.ComponentModel.ISupportInitialize)(this.barActionContainerNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSideNavigationPane)).BeginInit();
            this.MainSideNavigationPane.SuspendLayout();
            this.HomeNavigationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarSingleChoiceActionControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTileNavigationPane)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barContainerStatusMessages);
            this.ribbonStatusBar.ItemLinks.Add(this.barContainerNotifications);
            resources.ApplyResources(this.ribbonStatusBar, "ribbonStatusBar");
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = null;
            // 
            // barContainerStatusMessages
            // 
            resources.ApplyResources(this.barContainerStatusMessages, "barContainerStatusMessages");
            this.barContainerStatusMessages.Id = 27;
            this.barContainerStatusMessages.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems;
            this.barContainerStatusMessages.Name = "barContainerStatusMessages";
            // 
            // barContainerNotifications
            // 
            this.barContainerNotifications.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barContainerNotifications, "barContainerNotifications");
            this.barContainerNotifications.Id = 28;
            this.barContainerNotifications.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems;
            this.barContainerNotifications.Name = "barContainerNotifications";
            // 
            // barActionContainerNotifications
            // 
            this.barActionContainerNotifications.ActionCategory = "Notifications";
            this.barActionContainerNotifications.BarContainerItem = this.barContainerNotifications;
            // 
            // MainSideNavigationPane
            // 
            this.MainSideNavigationPane.AllowHtmlDraw = true;
            this.MainSideNavigationPane.AllowResize = false;
            resources.ApplyResources(this.MainSideNavigationPane, "MainSideNavigationPane");
            this.MainSideNavigationPane.Controls.Add(this.HomeNavigationPage);
            this.MainSideNavigationPane.Controls.Add(this.SettingsNavigationPage);
            this.MainSideNavigationPane.Controls.Add(this.navigationPage1);
            this.MainSideNavigationPane.Controls.Add(this.navigationPage2);
            this.MainSideNavigationPane.DisableLiveResize = true;
            this.MainSideNavigationPane.LookAndFeel.SkinName = "The Bezier";
            this.MainSideNavigationPane.Name = "MainSideNavigationPane";
            this.MainSideNavigationPane.PageProperties.AllowBorderColorBlending = true;
            this.MainSideNavigationPane.PageProperties.AllowCustomHeaderButtonsGlyphSkinning = true;
            this.MainSideNavigationPane.PageProperties.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("MainSideNavigationPane.PageProperties.AppearanceCaption.Image")));
            this.MainSideNavigationPane.PageProperties.AppearanceCaption.Options.UseImage = true;
            this.MainSideNavigationPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.HomeNavigationPage,
            this.navigationPage1,
            this.navigationPage2,
            this.SettingsNavigationPage});
            this.MainSideNavigationPane.RegularSize = new System.Drawing.Size(229, 549);
            this.MainSideNavigationPane.SelectedPage = this.HomeNavigationPage;
            // 
            // HomeNavigationPage
            // 
            this.HomeNavigationPage.BackgroundPadding = new System.Windows.Forms.Padding(1);
            resources.ApplyResources(this.HomeNavigationPage, "HomeNavigationPage");
            this.HomeNavigationPage.Controls.Add(this.navBarControl);
            this.HomeNavigationPage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("HomeNavigationPage.ImageOptions.Image")));
            this.HomeNavigationPage.Name = "HomeNavigationPage";
            this.HomeNavigationPage.Properties.ShowCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.HomeNavigationPage.Properties.ShowExpandButton = DevExpress.Utils.DefaultBoolean.False;
            this.HomeNavigationPage.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image;
            // 
            // navBarControl
            // 
            this.navBarControl.ActionControl = this.navBarSingleChoiceActionControl;
            this.navBarControl.ActiveGroup = null;
            this.navBarControl.AllowHorizontalResizing = DevExpress.Utils.DefaultBoolean.False;
            this.navBarControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.navBarControl, "navBarControl");
            this.navBarControl.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControl.ExplorerBarShowGroupButtons = false;
            this.navBarControl.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.NavigationPaneGroupClientHeight = 20;
            this.navBarControl.NavigationPaneMaxVisibleGroups = 4;
            this.navBarControl.OptionsNavPane.CollapsedWidth = ((int)(resources.GetObject("resource.CollapsedWidth")));
            this.navBarControl.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.navBarControl.OptionsNavPane.ShowExpandButton = false;
            this.navBarControl.OptionsNavPane.ShowHeaderText = false;
            this.navBarControl.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.StoreDefaultPaintStyleName = true;
            // 
            // navBarSingleChoiceActionControl
            // 
            this.navBarSingleChoiceActionControl.ActionId = "ShowNavigationItem";
            this.navBarSingleChoiceActionControl.NavigationControl = this.navBarControl;                        
            this.navBarSingleChoiceActionControl.NavigationStyle = DevExpress.ExpressApp.Templates.ActionContainers.NavigationStyle.TreeList;
            //this.navBarSingleChoiceActionControl.AllowAutoSelectNavItem = true;
            // 
            // SettingsNavigationPage
            // 
            this.SettingsNavigationPage.BackgroundPadding = new System.Windows.Forms.Padding(0);
            resources.ApplyResources(this.SettingsNavigationPage, "SettingsNavigationPage");
            this.SettingsNavigationPage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SettingsNavigationPage.ImageOptions.Image")));
            this.SettingsNavigationPage.Name = "SettingsNavigationPage";
            // 
            // navigationPage1
            // 
            resources.ApplyResources(this.navigationPage1, "navigationPage1");
            this.navigationPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("navigationPage1.ImageOptions.Image")));
            this.navigationPage1.Name = "navigationPage1";
            // 
            // navigationPage2
            // 
            resources.ApplyResources(this.navigationPage2, "navigationPage2");
            this.navigationPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("navigationPage2.ImageOptions.Image")));
            this.navigationPage2.Name = "navigationPage2";
            // 
            // SlackifyXafMasterContainer
            // 
            resources.ApplyResources(this.SlackifyXafMasterContainer, "SlackifyXafMasterContainer");
            this.SlackifyXafMasterContainer.Name = "SlackifyXafMasterContainer";
            // 
            // MainTileNavigationPane
            // 
            this.MainTileNavigationPane.Buttons.Add(this.NavMainButton);
            this.MainTileNavigationPane.Buttons.Add(this.NavCompanyNameButton);
            this.MainTileNavigationPane.Buttons.Add(this.navButton2);
            this.MainTileNavigationPane.Buttons.Add(this.NavDocumentCaptionButton);
            // 
            // MainTileNagivationCategory
            // 
            this.MainTileNavigationPane.DefaultCategory.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.MainTileNavigationPane.DefaultCategory.Name = "MainTileNagivationCategory";
            this.MainTileNavigationPane.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.MainTileNavigationPane.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.MainTileNavigationPane, "MainTileNavigationPane");
            this.MainTileNavigationPane.Name = "MainTileNavigationPane";
            // 
            // NavMainButton
            // 
            this.NavMainButton.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("NavMainButton.Appearance.BackColor")));
            this.NavMainButton.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.NavMainButton, "NavMainButton");
            this.NavMainButton.Glyph = ((System.Drawing.Image)(resources.GetObject("NavMainButton.Glyph")));
            this.NavMainButton.Name = "NavMainButton";
            this.NavMainButton.Padding = new System.Windows.Forms.Padding(4);
            this.NavMainButton.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.NavMainButton_ElementClick);
            // 
            // NavCompanyNameButton
            // 
            this.NavCompanyNameButton.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            resources.ApplyResources(this.NavCompanyNameButton, "NavCompanyNameButton");
            this.NavCompanyNameButton.Enabled = false;
            this.NavCompanyNameButton.Name = "NavCompanyNameButton";
            // 
            // navButton2
            // 
            this.navButton2.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            resources.ApplyResources(this.navButton2, "navButton2");
            this.navButton2.Enabled = false;
            this.navButton2.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton2.Glyph")));
            this.navButton2.Name = "navButton2";
            // 
            // NavDocumentCaptionButton
            // 
            resources.ApplyResources(this.NavDocumentCaptionButton, "NavDocumentCaptionButton");
            this.NavDocumentCaptionButton.Enabled = false;
            this.NavDocumentCaptionButton.Name = "NavDocumentCaptionButton";
            this.NavDocumentCaptionButton.Padding = new System.Windows.Forms.Padding(0, -1, -1, -1);
            // 
            // formStateModelSynchronizer
            // 
            this.formStateModelSynchronizer.Form = null;
            // 
            // modelSynchronizationManager
            // 
            this.modelSynchronizationManager.ModelSynchronizableComponents.Add(this.formStateModelSynchronizer);
            this.modelSynchronizationManager.ModelSynchronizableComponents.Add(this.navBarControlModelSynchronizer);
            // 
            // navBarControlModelSynchronizer
            // 
            this.navBarControlModelSynchronizer.NavBarControl = null;
            // 
            // SlackifyLightStyleMainRibbonForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SlackifyXafMasterContainer);
            this.Controls.Add(this.MainSideNavigationPane);
            this.Controls.Add(this.MainTileNavigationPane);
            this.Controls.Add(this.ribbonStatusBar);
            this.LookAndFeel.SkinName = "The Bezier";
            this.Name = "SlackifyLightStyleMainRibbonForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            ((System.ComponentModel.ISupportInitialize)(this.barActionContainerNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSideNavigationPane)).EndInit();
            this.MainSideNavigationPane.ResumeLayout(false);
            this.HomeNavigationPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarSingleChoiceActionControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainTileNavigationPane)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        
        private DevExpress.XtraBars.Navigation.NavigationPane MainSideNavigationPane;
        private DevExpress.XtraBars.Navigation.NavigationPage HomeNavigationPage;
        private DevExpress.XtraBars.Navigation.NavigationPage SettingsNavigationPage;
        private DevExpress.XtraBars.Navigation.TileNavPane MainTileNavigationPane;
        private DevExpress.XtraBars.Navigation.NavButton NavMainButton;
        private DevExpress.ExpressApp.Win.Templates.Navigation.NavBarControlModelSynchronizer navBarControlModelSynchronizer;
        private DevExpress.ExpressApp.Win.Templates.Navigation.NavBarSingleChoiceActionControl navBarSingleChoiceActionControl;
        private DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer formStateModelSynchronizer;
        private DevExpress.ExpressApp.Win.Templates.ModelSynchronizationManager modelSynchronizationManager;
        private SlackifyXafMasterContainer SlackifyXafMasterContainer;
        private DevExpress.ExpressApp.Win.Templates.Navigation.XafNavBarControl navBarControl;
        private DevExpress.XtraBars.Navigation.NavButton NavCompanyNameButton;
        private DevExpress.XtraBars.Navigation.NavButton navButton2;
        private DevExpress.XtraBars.Navigation.NavButton NavDocumentCaptionButton;
        public DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        public DevExpress.XtraBars.BarLinkContainerExItem barContainerStatusMessages;
        public DevExpress.XtraBars.BarLinkContainerExItem barContainerNotifications;
        public DevExpress.ExpressApp.Win.Templates.Bars.ActionControls.BarLinkActionControlContainer barActionContainerNotifications;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
    }
}