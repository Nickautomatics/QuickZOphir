using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Templates;
using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Utils;

namespace QuickZ.Themes.SlackifyWin.Templates
{
    public partial class SlackifyLookupForm : XtraFormTemplateBase, ILookupPopupFrameTemplateEx, ISeparatorsHolder
    {
        private const int minWidth = 420;
        private const int minHeight = 150;
        private SlackifyLookupControlTemplate frameTemplate;
        private void ButtonsContainersPanel_Changed(object sender, EventArgs e)
        {
            frameTemplate.ButtonsContainersPanel.MaximumSize = new Size(0, frameTemplate.ButtonsContainersPanel.Root.MinSize.Height);
        }
        private void UpdateMinimumSize()
        {
            int nonClientWidth = Size.Width - ClientSize.Width + Padding.Size.Width;
            int nonClientHeight = Size.Height - ClientSize.Height + Padding.Size.Height;

            MinimumSize = new Size(
                Math.Max(frameTemplate.MinimumSize.Width + nonClientWidth, minWidth),
                Math.Max(frameTemplate.MinimumSize.Height + nonClientHeight, minHeight));
        }
        private void OnSearchEnabledChanged(object sender, EventArgs e)
        {
            if (SearchEnabledChanged != null)
            {
                SearchEnabledChanged(this, new EventArgs());
            }
        }
        protected override IModelFormState GetFormStateNode()
        {
            if (View != null)
            {
                return TemplatesHelper.GetFormStateNode(View.Id);
            }
            else
            {
                return base.GetFormStateNode();
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (frameTemplate.IsSearchEnabled)
            {
                frameTemplate.FindEditor.Focus();
            }
            UpdateMinimumSize();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                frameTemplate.ButtonsContainersPanel.Changed -= new EventHandler(ButtonsContainersPanel_Changed);
                frameTemplate.SearchEnabledChanged -= OnSearchEnabledChanged;
            }
            base.Dispose(disposing);
        }
        protected override DevExpress.XtraBars.Ribbon.RibbonFormStyle RibbonFormStyle
        {
            get
            {
                return DevExpress.XtraBars.Ribbon.RibbonFormStyle.Standard;
            }
        }
        public override void SetSettings(IModelTemplate modelTemplate)
        {
            base.SetSettings(modelTemplate);
            formStateModelSynchronizerComponent.Model = GetFormStateNode();
        }
        public SlackifyLookupForm()
        {
            InitializeComponent();
            MinimumSize = new Size(minWidth, minHeight);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            NativeMethods.SetExecutingApplicationIcon(this);
            ShowInTaskbar = true;
            KeyPreview = true;
            frameTemplate = new SlackifyLookupControlTemplate();
            Controls.Add(frameTemplate);
            frameTemplate.Dock = DockStyle.Fill;
            actionsContainersManager.ActionContainerComponents.AddRange(frameTemplate.GetContainers());
            actionsContainersManager.DefaultContainer = frameTemplate.DefaultContainer;
            viewSiteManager.ViewSiteControl = (Control)frameTemplate.ViewSiteControl;
            frameTemplate.ButtonsContainersPanel.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 12, 12, 0);
            ((Control)this).Padding = new Padding(0, 0, 0, 12);
            frameTemplate.ButtonsContainersPanel.Changed += new EventHandler(ButtonsContainersPanel_Changed);
            frameTemplate.SearchEnabledChanged += OnSearchEnabledChanged;
            frameTemplate.ButtonsContainersPanel.SendToBack();
        }
        public override void SetView(DevExpress.ExpressApp.View view)
        {
            bool isPreviuosViewNotNull = frameTemplate.ListView != null;
            frameTemplate.SetView(view);
            if (view != null)
            {
                SetFormIcon(view);
            }
            bool isT533962case = isPreviuosViewNotNull || this.WindowState == FormWindowState.Maximized;
            if (!isT533962case)
            {
                ClientSize = frameTemplate.PreferredSize;
            }
        }
        public SlackifyLookupControlTemplate FrameTemplate { get { return frameTemplate; } }

        #region ISeparatorsHolder Members
        AnchorStyles ISeparatorsHolder.SeparatorAnchors
        {
            get
            {
                return topSeparatorControl.Visible ? AnchorStyles.Top : AnchorStyles.None;
            }
            set
            {
                topSeparatorControl.Visible = value.HasFlag(AnchorStyles.Top);
            }
        }
        #endregion

        #region ILookupPopupFrameTemplate Members
        public void SetStartSearchString(string searchString)
        {
            frameTemplate.SetStartSearchString(searchString);
        }
        public bool IsSearchEnabled
        {
            get { return frameTemplate.IsSearchEnabled; }
            set { frameTemplate.IsSearchEnabled = value; }
        }
        public void FocusFindEditor() { }
        public event EventHandler<EventArgs> SearchEnabledChanged;
        #endregion
    }
}