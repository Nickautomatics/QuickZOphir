using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Templates;

namespace QuickZ.Themes.SlackifyWin.Templates
{
    partial class SlackifyLookupControlTemplate
    {
        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new XafComponentResourceManager(typeof(SlackifyLookupControlTemplate));
            this.topSeparator = new System.Windows.Forms.GroupBox();
            this.buttonsContainersPanel = new DevExpress.XtraLayout.LayoutControl();
            this.diagnosticContainer = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer();
            this.diagnosticLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.objectsCreationContainer = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer();
            this.objectsCreationLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.popupActionsContainer = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer();
            this.popupActionsLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            this.diagnosticLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.objectsCreationLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupActionsLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.bottomSeparator = new System.Windows.Forms.GroupBox();
            this.bottomSeparatorPanel = new DevExpress.XtraEditors.PanelControl();
            this.controlsPanel = new DevExpress.XtraEditors.PanelControl();
            this.viewSitePanel = new DevExpress.XtraEditors.PanelControl();
            this.viewSiteInfoPanel = new DevExpress.XtraEditors.PanelControl();
            this.typeAndFindPanel = new DevExpress.XtraLayout.LayoutControl();
            this.typeValueLabel = new DevExpress.XtraEditors.LabelControl();
            this.searchActionContainer = new DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer();
            this.searchActionLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.typeAndFindPanelLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.typeValueLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchActionContainerLayoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.availableRecordsPanel = new DevExpress.XtraEditors.PanelControl();
            this.AvailableRecords = new DevExpress.XtraEditors.LabelControl();
            this.actionContainersManager = new DevExpress.ExpressApp.Win.Templates.ActionContainersManager(this.components);
            this.viewSiteManager = new DevExpress.ExpressApp.Win.Templates.ViewSiteManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainersPanel)).BeginInit();
            this.buttonsContainersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsCreationContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsCreationLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupActionsContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupActionsLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsCreationLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupActionsLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomSeparatorPanel)).BeginInit();
            this.bottomSeparatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlsPanel)).BeginInit();
            this.controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewSitePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSiteInfoPanel)).BeginInit();
            this.viewSiteInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeAndFindPanel)).BeginInit();
            this.typeAndFindPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchActionContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchActionLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeAndFindPanelLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeValueLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchActionContainerLayoutItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableRecordsPanel)).BeginInit();
            this.availableRecordsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topSeparator
            // 
            resources.ApplyResources(this.topSeparator, "topSeparator");
            this.topSeparator.Name = "topSeparator";
            this.topSeparator.TabStop = false;
            // 
            // buttonsContainersPanel
            // 
            this.buttonsContainersPanel.AllowCustomization = false;
            resources.ApplyResources(this.buttonsContainersPanel, "buttonsContainersPanel");
            this.buttonsContainersPanel.Controls.Add(this.diagnosticContainer);
            this.buttonsContainersPanel.Controls.Add(this.objectsCreationContainer);
            this.buttonsContainersPanel.Controls.Add(this.popupActionsContainer);
            this.buttonsContainersPanel.Name = "buttonsContainersPanel";
            this.buttonsContainersPanel.Root = this.Root;
            this.buttonsContainersPanel.BackColor = System.Drawing.Color.Transparent;
            this.buttonsContainersPanel.TabStop = false;
            // 
            // diagnosticContainer
            // 
            this.diagnosticContainer.ActionId = null;
            this.diagnosticContainer.AllowCustomization = false;
            resources.ApplyResources(this.diagnosticContainer, "diagnosticContainer");
            this.diagnosticContainer.BackColor = System.Drawing.Color.Transparent;
            this.diagnosticContainer.ContainerId = "Diagnostic";
            this.diagnosticContainer.HideItemsCompletely = true;
            this.diagnosticContainer.Name = "diagnosticContainer";
            this.diagnosticContainer.Orientation = DevExpress.ExpressApp.Model.ActionContainerOrientation.Horizontal;
            this.diagnosticContainer.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Caption;
            this.diagnosticContainer.Root = this.diagnosticLayoutGroup;
            // 
            // diagnosticLayoutGroup
            // 
            resources.ApplyResources(this.diagnosticLayoutGroup, "diagnosticLayoutGroup");
            this.diagnosticLayoutGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.diagnosticLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.diagnosticLayoutGroup.GroupBordersVisible = false;
            this.diagnosticLayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.diagnosticLayoutGroup.Name = "diagnosticLayoutGroup";
            this.diagnosticLayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.diagnosticLayoutGroup.Size = new System.Drawing.Size(88, 96);
            this.diagnosticLayoutGroup.TextVisible = false;
            // 
            // objectsCreationContainer
            // 
            this.objectsCreationContainer.ActionId = null;
            this.objectsCreationContainer.AllowCustomization = false;
            resources.ApplyResources(this.objectsCreationContainer, "objectsCreationContainer");
            this.objectsCreationContainer.BackColor = System.Drawing.Color.Transparent;
            this.objectsCreationContainer.ContainerId = "ObjectsCreation";
            this.objectsCreationContainer.HideItemsCompletely = true;
            this.objectsCreationContainer.Name = "objectsCreationContainer";
            this.objectsCreationContainer.Orientation = DevExpress.ExpressApp.Model.ActionContainerOrientation.Horizontal;
            this.objectsCreationContainer.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Caption;
            this.objectsCreationContainer.Root = this.objectsCreationLayoutGroup;
            // 
            // objectsCreationLayoutGroup
            // 
            resources.ApplyResources(this.objectsCreationLayoutGroup, "objectsCreationLayoutGroup");
            this.objectsCreationLayoutGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.objectsCreationLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.objectsCreationLayoutGroup.GroupBordersVisible = false;
            this.objectsCreationLayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.objectsCreationLayoutGroup.Name = "objectsCreationLayoutGroup";
            this.objectsCreationLayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.objectsCreationLayoutGroup.Size = new System.Drawing.Size(88, 96);
            this.objectsCreationLayoutGroup.TextVisible = false;
            // 
            // popupActionsContainer
            // 
            this.popupActionsContainer.ActionId = null;
            this.popupActionsContainer.AllowCustomization = false;
            resources.ApplyResources(this.popupActionsContainer, "popupActionsContainer");
            this.popupActionsContainer.BackColor = System.Drawing.Color.Transparent;
            this.popupActionsContainer.ContainerId = "PopupActions";
            this.popupActionsContainer.HideItemsCompletely = true;
            this.popupActionsContainer.Name = "popupActionsContainer";
            this.popupActionsContainer.Orientation = DevExpress.ExpressApp.Model.ActionContainerOrientation.Horizontal;
            this.popupActionsContainer.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Caption;
            this.popupActionsContainer.Root = this.popupActionsLayoutGroup;
            // 
            // popupActionsLayoutGroup
            // 
            resources.ApplyResources(this.popupActionsLayoutGroup, "popupActionsLayoutGroup");
            this.popupActionsLayoutGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.popupActionsLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.popupActionsLayoutGroup.GroupBordersVisible = false;
            this.popupActionsLayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.popupActionsLayoutGroup.Name = "popupActionsLayoutGroup";
            this.popupActionsLayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.popupActionsLayoutGroup.Size = new System.Drawing.Size(81, 96);
            this.popupActionsLayoutGroup.TextVisible = false;
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem,
            this.diagnosticLayoutItem,
            this.objectsCreationLayoutItem,
            this.popupActionsLayoutItem});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 12, 12, 12);
            this.Root.Size = new System.Drawing.Size(574, 120);
            // 
            // emptySpaceItem
            // 
            this.emptySpaceItem.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem, "emptySpaceItem");
            this.emptySpaceItem.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem.Name = "emptySpaceItem";
            this.emptySpaceItem.Size = new System.Drawing.Size(305, 96);
            this.emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // diagnosticLayoutItem
            // 
            this.diagnosticLayoutItem.Control = this.diagnosticContainer;
            this.diagnosticLayoutItem.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            resources.ApplyResources(this.diagnosticLayoutItem, "diagnosticLayoutItem");
            this.diagnosticLayoutItem.Location = new System.Drawing.Point(305, 0);
            this.diagnosticLayoutItem.Name = "diagnosticLayoutItem";
            this.diagnosticLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.diagnosticLayoutItem.Size = new System.Drawing.Size(88, 96);
            this.diagnosticLayoutItem.TextSize = new System.Drawing.Size(0, 0);
            this.diagnosticLayoutItem.TextToControlDistance = 0;
            this.diagnosticLayoutItem.TextVisible = false;
            // 
            // objectsCreationLayoutItem
            // 
            this.objectsCreationLayoutItem.Control = this.objectsCreationContainer;
            this.objectsCreationLayoutItem.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            resources.ApplyResources(this.objectsCreationLayoutItem, "objectsCreationLayoutItem");
            this.objectsCreationLayoutItem.Location = new System.Drawing.Point(393, 0);
            this.objectsCreationLayoutItem.Name = "objectsCreationLayoutItem";
            this.objectsCreationLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.objectsCreationLayoutItem.Size = new System.Drawing.Size(88, 96);
            this.objectsCreationLayoutItem.TextSize = new System.Drawing.Size(0, 0);
            this.objectsCreationLayoutItem.TextToControlDistance = 0;
            this.objectsCreationLayoutItem.TextVisible = false;
            // 
            // popupActionsLayoutItem
            // 
            this.popupActionsLayoutItem.Control = this.popupActionsContainer;
            this.popupActionsLayoutItem.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            resources.ApplyResources(this.popupActionsLayoutItem, "popupActionsLayoutItem");
            this.popupActionsLayoutItem.Location = new System.Drawing.Point(481, 0);
            this.popupActionsLayoutItem.Name = "popupActionsLayoutItem";
            this.popupActionsLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.popupActionsLayoutItem.Size = new System.Drawing.Size(81, 96);
            this.popupActionsLayoutItem.TextSize = new System.Drawing.Size(0, 0);
            this.popupActionsLayoutItem.TextToControlDistance = 0;
            this.popupActionsLayoutItem.TextVisible = false;
            // 
            // bottomSeparator
            // 
            resources.ApplyResources(this.bottomSeparator, "bottomSeparator");
            this.bottomSeparator.Name = "bottomSeparator";
            this.bottomSeparator.TabStop = false;
            // 
            // bottomSeparatorPanel
            // 
            this.bottomSeparatorPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bottomSeparatorPanel.Controls.Add(this.bottomSeparator);
            resources.ApplyResources(this.bottomSeparatorPanel, "bottomSeparatorPanel");
            this.bottomSeparatorPanel.Name = "bottomSeparatorPanel";
            // 
            // controlsPanel
            // 
            resources.ApplyResources(this.controlsPanel, "controlsPanel");
            this.controlsPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.controlsPanel.Controls.Add(this.viewSitePanel);
            this.controlsPanel.Controls.Add(this.viewSiteInfoPanel);
            this.controlsPanel.Name = "controlsPanel";
            // 
            // viewSitePanel
            // 
            resources.ApplyResources(this.viewSitePanel, "viewSitePanel");
            this.viewSitePanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.viewSitePanel.Name = "viewSitePanel";
            // 
            // viewSiteInfoPanel
            // 
            resources.ApplyResources(this.viewSiteInfoPanel, "viewSiteInfoPanel");
            this.viewSiteInfoPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.viewSiteInfoPanel.Controls.Add(this.typeAndFindPanel);
            this.viewSiteInfoPanel.Controls.Add(this.topSeparator);
            this.viewSiteInfoPanel.Controls.Add(this.availableRecordsPanel);
            this.viewSiteInfoPanel.Name = "viewSiteInfoPanel";
            // 
            // typeAndFindPanel
            // 
            this.typeAndFindPanel.AllowCustomization = false;
            this.typeAndFindPanel.Controls.Add(this.typeValueLabel);
            this.typeAndFindPanel.Controls.Add(this.searchActionContainer);
            resources.ApplyResources(this.typeAndFindPanel, "typeAndFindPanel");
            this.typeAndFindPanel.Name = "typeAndFindPanel";
            this.typeAndFindPanel.Root = this.typeAndFindPanelLayoutGroup;
            // 
            // typeValueLabel
            // 
            resources.ApplyResources(this.typeValueLabel, "typeValueLabel");
            this.typeValueLabel.Name = "typeValueLabel";
            this.typeValueLabel.StyleController = this.typeAndFindPanel;
            // 
            // searchActionContainer
            // 
            this.searchActionContainer.ActionId = "FullTextSearch";
            this.searchActionContainer.AllowCustomization = false;
            resources.ApplyResources(this.searchActionContainer, "searchActionContainer");
            this.searchActionContainer.BackColor = System.Drawing.Color.Transparent;
            this.searchActionContainer.ContainerId = "FullTextSearch";
            this.searchActionContainer.HideItemsCompletely = false;
            this.searchActionContainer.Name = "searchActionContainer";
            this.searchActionContainer.OptionsView.AutoSizeInLayoutControl = DevExpress.XtraLayout.AutoSizeModes.UseMinAndMaxSize;
            this.searchActionContainer.Orientation = DevExpress.ExpressApp.Model.ActionContainerOrientation.Horizontal;
            this.searchActionContainer.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.searchActionContainer.Root = this.searchActionLayoutGroup;
            this.searchActionContainer.TabStop = false;
            this.searchActionContainer.ActionItemAdded += new System.EventHandler<DevExpress.ExpressApp.Win.Templates.ActionContainers.ActionItemEventArgs>(this.searchActionContainer_ActionItemAdded);
            // 
            // searchActionLayoutGroup
            // 
            resources.ApplyResources(this.searchActionLayoutGroup, "searchActionLayoutGroup");
            this.searchActionLayoutGroup.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.searchActionLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.searchActionLayoutGroup.GroupBordersVisible = false;
            this.searchActionLayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.searchActionLayoutGroup.Name = "searchActionLayoutGroup";
            this.searchActionLayoutGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.searchActionLayoutGroup.Size = new System.Drawing.Size(501, 26);
            // 
            // typeAndFindPanelLayoutGroup
            // 
            this.typeAndFindPanelLayoutGroup.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("typeAndFindPanelLayoutGroup.AppearanceItemCaption.Font")));
            this.typeAndFindPanelLayoutGroup.AppearanceItemCaption.Options.UseFont = true;
            resources.ApplyResources(this.typeAndFindPanelLayoutGroup, "typeAndFindPanelLayoutGroup");
            this.typeAndFindPanelLayoutGroup.GroupBordersVisible = false;
            this.typeAndFindPanelLayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.typeValueLayoutItem,
            this.searchActionContainerLayoutItem});
            this.typeAndFindPanelLayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.typeAndFindPanelLayoutGroup.Name = "typeAndFindPanelLayoutGroup";
            this.typeAndFindPanelLayoutGroup.OptionsItemText.TextToControlDistance = 18;
            this.typeAndFindPanelLayoutGroup.Size = new System.Drawing.Size(550, 44);
            this.typeAndFindPanelLayoutGroup.TextVisible = false;
            // 
            // typeValueLayoutItem
            // 
            this.typeValueLayoutItem.Control = this.typeValueLabel;
            resources.ApplyResources(this.typeValueLayoutItem, "typeValueLayoutItem");
            this.typeValueLayoutItem.Location = new System.Drawing.Point(0, 0);
            this.typeValueLayoutItem.Name = "typeValueLayoutItem";
            this.typeValueLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 5);
            this.typeValueLayoutItem.Size = new System.Drawing.Size(550, 18);
            this.typeValueLayoutItem.TextSize = new System.Drawing.Size(31, 13);
            // 
            // searchActionContainerLayoutItem
            // 
            this.searchActionContainerLayoutItem.Control = this.searchActionContainer;
            resources.ApplyResources(this.searchActionContainerLayoutItem, "searchActionContainerLayoutItem");
            this.searchActionContainerLayoutItem.Location = new System.Drawing.Point(0, 18);
            this.searchActionContainerLayoutItem.Name = "searchActionContainerLayoutItem";
            this.searchActionContainerLayoutItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.searchActionContainerLayoutItem.Size = new System.Drawing.Size(550, 26);
            this.searchActionContainerLayoutItem.TextSize = new System.Drawing.Size(31, 13);
            // 
            // availableRecordsPanel
            // 
            resources.ApplyResources(this.availableRecordsPanel, "availableRecordsPanel");
            this.availableRecordsPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.availableRecordsPanel.Controls.Add(this.AvailableRecords);
            this.availableRecordsPanel.Name = "availableRecordsPanel";
            // 
            // AvailableRecords
            // 
            resources.ApplyResources(this.AvailableRecords, "AvailableRecords");
            this.AvailableRecords.Name = "AvailableRecords";
            // 
            // actionContainersManager
            // 
            this.actionContainersManager.ActionContainerComponents.Add(this.searchActionContainer);
            this.actionContainersManager.ActionContainerComponents.Add(this.diagnosticContainer);
            this.actionContainersManager.ActionContainerComponents.Add(this.objectsCreationContainer);
            this.actionContainersManager.ActionContainerComponents.Add(this.popupActionsContainer);
            this.actionContainersManager.DefaultContainer = null;
            this.actionContainersManager.Template = this;
            // 
            // viewSiteManager
            // 
            this.viewSiteManager.UseDeferredLoading = false;
            this.viewSiteManager.ViewSiteControl = this.viewSitePanel;
            // 
            // LookupControlTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bottomSeparatorPanel);
            this.Controls.Add(this.buttonsContainersPanel);
            this.Controls.Add(this.controlsPanel);
            this.Name = "LookupControlTemplate";
            this.BackColor = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.buttonsContainersPanel)).EndInit();
            this.buttonsContainersPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsCreationContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsCreationLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupActionsContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupActionsLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectsCreationLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupActionsLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomSeparatorPanel)).EndInit();
            this.bottomSeparatorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlsPanel)).EndInit();
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewSitePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSiteInfoPanel)).EndInit();
            this.viewSiteInfoPanel.ResumeLayout(false);
            this.viewSiteInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeAndFindPanel)).EndInit();
            this.typeAndFindPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchActionContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchActionLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeAndFindPanelLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeValueLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchActionContainerLayoutItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableRecordsPanel)).EndInit();
            this.availableRecordsPanel.ResumeLayout(false);
            this.availableRecordsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        protected DevExpress.XtraEditors.PanelControl controlsPanel;
        protected DevExpress.XtraEditors.PanelControl viewSiteInfoPanel;
        protected DevExpress.XtraEditors.PanelControl viewSitePanel;
        protected DevExpress.XtraLayout.LayoutControl typeAndFindPanel;
        protected DevExpress.XtraLayout.LayoutControlItem typeValueLayoutItem;
        protected DevExpress.XtraLayout.LayoutControlItem searchActionContainerLayoutItem;
        protected DevExpress.XtraLayout.LayoutControl buttonsContainersPanel;
        protected System.Windows.Forms.GroupBox topSeparator;
        protected DevExpress.XtraEditors.PanelControl bottomSeparatorPanel;
        protected System.Windows.Forms.GroupBox bottomSeparator;
        protected DevExpress.XtraEditors.LabelControl AvailableRecords;
        protected DevExpress.XtraEditors.LabelControl typeValueLabel;
        private DevExpress.ExpressApp.Win.Templates.ActionContainersManager actionContainersManager;
        private DevExpress.ExpressApp.Win.Templates.ViewSiteManager viewSiteManager;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer searchActionContainer;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem;
        private DevExpress.XtraLayout.LayoutControlGroup searchActionLayoutGroup;
        private System.ComponentModel.IContainer components;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer diagnosticContainer;
        private DevExpress.XtraLayout.LayoutControlGroup diagnosticLayoutGroup;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer popupActionsContainer;
        private DevExpress.XtraLayout.LayoutControlGroup popupActionsLayoutGroup;
        private DevExpress.ExpressApp.Win.Templates.ActionContainers.ButtonsContainer objectsCreationContainer;
        private DevExpress.XtraLayout.LayoutControlGroup objectsCreationLayoutGroup;
        private DevExpress.XtraLayout.LayoutControlItem diagnosticLayoutItem;
        private DevExpress.XtraLayout.LayoutControlItem objectsCreationLayoutItem;
        private DevExpress.XtraLayout.LayoutControlItem popupActionsLayoutItem;
        private DevExpress.XtraEditors.PanelControl availableRecordsPanel;
        private DevExpress.XtraLayout.LayoutControlGroup typeAndFindPanelLayoutGroup;
    }
}
