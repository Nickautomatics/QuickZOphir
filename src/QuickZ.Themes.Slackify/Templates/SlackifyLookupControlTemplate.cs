using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.Utils.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace QuickZ.Themes.SlackifyWin.Templates
{
    [ToolboxItem(false)]
    public partial class SlackifyLookupControlTemplate : UserControl, IFrameTemplate, ILookupPopupFrameTemplateEx, IViewSiteTemplate, ISupportUpdate, ISupportViewChanged, IButtonsContainersOwner, IViewHolder
    {
        public const int DefaultPreferredWidth = 400;
        public const int DefaultPreferredHeight = 300;
        public const string SearchFilterName = "search filter";
        private bool showButtonsContainersPanel = true;
        private const int minWidth = 400;
        private const int minHeight = 300;
        private DevExpress.ExpressApp.ListView listView;
        private bool isSearchEnabled;
        private Size preferredSize;
        private void searchActionContainer_ActionItemAdded(object sender, ActionItemEventArgs e)
        {
            e.Item.LayoutItem.TextVisible = false;
            e.Item.Action.Executed += new EventHandler<ActionBaseEventArgs>(ParametrizedAction_Executed);
            typeAndFindPanel.Changed -= TypeAndFindPanel_Changed;
            typeAndFindPanel.Changed += TypeAndFindPanel_Changed;
        }
        private void ParametrizedAction_Executed(object sender, ActionBaseEventArgs e)
        {
            if (listView != null && listView.CollectionSource.List != null && listView.CollectionSource.List.Count > 0)
            {
                FocusListViewEditor();
            }
        }
        private void TypeAndFindPanel_Changed(object sender, EventArgs e)
        {
            typeAndFindPanel.MaximumSize = new Size(0, typeAndFindPanel.Root.MinSize.Height + 4);
        }
        private void RefreshSize()
        {
            if (listView != null && listView.IsControlCreated)
            {
                int viewControlMinWidth = viewSitePanel.Controls[0].MinimumSize.Width;
                int viewControlMinHeight = viewSitePanel.Controls[0].MinimumSize.Height;

                int searchPanelMinWidth = isSearchEnabled ? ((IXtraResizableControl)typeAndFindPanel).MinSize.Width + viewSiteInfoPanel.Padding.Horizontal : 0;
                int searchPanelMinHeight = isSearchEnabled ? viewSiteInfoPanel.Height + 20 : 0;

                int contentMinWidth = Math.Max(viewControlMinWidth, searchPanelMinWidth);
                int contentMinHeight = Math.Max(viewControlMinHeight, searchPanelMinHeight);
                if (preferredSize.IsEmpty)
                {
                    preferredSize = new Size(
                        Math.Max(viewControlMinWidth, DefaultPreferredWidth),
                        Math.Max(viewControlMinHeight, DefaultPreferredHeight) + (showButtonsContainersPanel ? buttonsContainersPanel.Height : 0));
                }

                MinimumSize = new Size(
                    Math.Max(contentMinWidth, minWidth),
                    Math.Max(contentMinHeight + (showButtonsContainersPanel ? buttonsContainersPanel.Height : 0), minHeight));
            }
        }
        private void FocusListViewEditor()
        {
            Control listViewEditor = GetListViewEditor();
            if (listViewEditor != null)
            {
                listViewEditor.Focus();
            }
        }
        private Control GetListViewEditor()
        {
            if (listView != null && listView.Editor != null && listView.Editor.Control != null)
            {
                return listView.Editor.Control as Control;
            }
            return null;
        }
        private bool ContainsActiveAction(IActionContainer actionContainer)
        {
            foreach (ActionBase action in actionContainer.Actions)
            {
                if (action.Active)
                {
                    return true;
                }
            }
            return false;
        }
        private void OnSearchEnabledChanged()
        {
            if (SearchEnabledChanged != null)
            {
                SearchEnabledChanged(this, new EventArgs());
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Visible && (FindForm() != null))
            {
                SetPreferredSize(Size);
            }
            base.OnSizeChanged(e);
        }
        public SlackifyLookupControlTemplate()
        {
            InitializeComponent();
            IsSearchEnabled = false;
        }
        private ButtonEdit SearchActionContainerEditor
        {
            get
            {
                ButtonEdit editor = null;
                if (SearchActionContainer.Actions.Count > 0)
                {
                    ButtonsContainersActionItemBase actionItem = SearchActionContainer.ActionItems[SearchActionContainer.Actions[0]];
                    editor = (ButtonEdit)actionItem.Control;
                }
                return editor;
            }
        }
        public override Size GetPreferredSize(Size proposedSize)
        {
            return preferredSize;
        }
        public void SetView(DevExpress.ExpressApp.View view)
        {
            viewSiteManager.SetView(view);

            if (view != null)
            {
                listView = (DevExpress.ExpressApp.ListView)view;
                typeValueLabel.Text = view.Caption;
                if (!isSearchEnabled)
                {
                    FocusListViewEditor();
                }
                RefreshSize();
            }
            else
            {
                listView = null;
            }
            if (ViewChanged != null)
            {
                ViewChanged(this, new TemplateViewChangedEventArgs(view));
            }
        }
        public void SetPreferredSize(Size preferredSize)
        {
            this.preferredSize = preferredSize;
            if (PreferredSizeChanged != null)
            {
                PreferredSizeChanged(this, EventArgs.Empty);
            }
        }
        public ICollection<IActionContainer> GetContainers()
        {
            return actionContainersManager.GetContainers();
        }
        public bool IsButtonsContainersPanelEmpty()
        {
            return !ContainsActiveAction(popupActionsContainer) && !ContainsActiveAction(objectsCreationContainer) && !ContainsActiveAction(diagnosticContainer);
        }
        public void BeginUpdate() { }
        public void EndUpdate() { }
        public void SetStartSearchString(string searchString)
        {
            if (IsSearchEnabled && SearchActionContainerEditor != null)
            {
                SearchActionContainerEditor.Text = searchString;
                if (!String.IsNullOrEmpty(SearchActionContainerEditor.Text))
                {
                    SearchActionContainerEditor.Select(SearchActionContainerEditor.Text.Length, 0);
                }
            }
            else
            {
                listView.Editor.StartIncrementalSearch(searchString);
            }
        }
        public IActionContainer DefaultContainer
        {
            get { return actionContainersManager.DefaultContainer; }
        }
        public bool IsSearchEnabled
        {
            get { return isSearchEnabled; }
            set
            {
                isSearchEnabled = value;
                viewSiteInfoPanel.Visible = value;
                bottomSeparatorPanel.Visible = value;
                viewSitePanel.DockPadding.All = isSearchEnabled ? 12 : 0;
                RefreshSize();
                OnSearchEnabledChanged();
            }
        }
        public DevExpress.ExpressApp.ListView ListView
        {
            get { return listView; }
        }
        public ButtonEdit FindEditor
        {
            get { return SearchActionContainerEditor; }
        }
        public Control BottomSeparator
        {
            get { return bottomSeparatorPanel; }
        }
        public LayoutControl ButtonsContainersPanel
        {
            get { return buttonsContainersPanel; }
        }
        public object ViewSiteControl
        {
            get { return viewSiteManager.ViewSiteControl; }
        }
        public bool ShowButtonsContainersPanel
        {
            get { return showButtonsContainersPanel; }
            set
            {
                if (showButtonsContainersPanel != value)
                {
                    if (value)
                    {
                        if (!Controls.Contains(ButtonsContainersPanel))
                        {
                            Controls.Add(ButtonsContainersPanel);
                        }
                    }
                    else
                    {
                        if (Controls.Contains(ButtonsContainersPanel))
                        {
                            Controls.Remove(ButtonsContainersPanel);
                        }
                    }
                    showButtonsContainersPanel = value;
                }
            }
        }
        public ButtonsContainer DiagnosticContainer
        {
            get { return diagnosticContainer; }
        }
        public ButtonsContainer ObjectsCreationContainer
        {
            get { return objectsCreationContainer; }
        }
        public ButtonsContainer PopupActionsContainer
        {
            get { return popupActionsContainer; }
        }
        public ButtonsContainer SearchActionContainer
        {
            get { return searchActionContainer; }
        }
        public event EventHandler<EventArgs> PreferredSizeChanged;
        public event EventHandler<TemplateViewChangedEventArgs> ViewChanged;
        public event EventHandler<EventArgs> SearchEnabledChanged;

        public void FocusFindEditor()
        {
            if (IsSearchEnabled && SearchActionContainerEditor != null)
            {
                Form form = FindForm();
                if (form != null)
                {
                    form.ActiveControl = SearchActionContainerEditor;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                typeAndFindPanel.Changed -= TypeAndFindPanel_Changed;
            }
            base.Dispose(disposing);
            if (disposing)
            {
                buttonsContainersPanel.Dispose();
            }
        }
        #region IViewHolder Members
        DevExpress.ExpressApp.View IViewHolder.View
        {
            get { return listView; }
        }
        #endregion
    }
}
