namespace QuickZ.Security.BasicWin
{
    partial class QuickZLoginForm
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
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.LayoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.teUsername = new DevExpress.XtraEditors.TextEdit();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbLogin = new DevExpress.XtraEditors.SimpleButton();
            this.lblWarn = new System.Windows.Forms.Label();
            this.lueWorkspaces = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.liWarningCaption = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlMain)).BeginInit();
            this.LayoutControlMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWorkspaces.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liWarningCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(64, 70);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.UseSystemPasswordChar = true;
            this.tePassword.Size = new System.Drawing.Size(278, 20);
            this.tePassword.StyleController = this.LayoutControlMain;
            this.tePassword.TabIndex = 12;
            this.tePassword.Enter += new System.EventHandler(this.OnTextEditEnter);
            this.tePassword.Leave += new System.EventHandler(this.OnTextEditLeave);
            // 
            // LayoutControlMain
            // 
            this.LayoutControlMain.Controls.Add(this.statusStrip1);
            this.LayoutControlMain.Controls.Add(this.tePassword);
            this.LayoutControlMain.Controls.Add(this.teUsername);
            this.LayoutControlMain.Controls.Add(this.sbCancel);
            this.LayoutControlMain.Controls.Add(this.sbLogin);
            this.LayoutControlMain.Controls.Add(this.lblWarn);
            this.LayoutControlMain.Controls.Add(this.lueWorkspaces);
            this.LayoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlMain.Name = "LayoutControlMain";
            this.LayoutControlMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(797, 282, 450, 400);
            this.LayoutControlMain.Root = this.layoutControlGroup1;
            this.LayoutControlMain.Size = new System.Drawing.Size(352, 191);
            this.LayoutControlMain.TabIndex = 14;
            this.LayoutControlMain.Text = "layoutControl1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusVersion,
            this.statusSpring,
            this.statusDate,
            this.statusTime});
            this.statusStrip1.Location = new System.Drawing.Point(7, 164);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(338, 20);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusVersion
            // 
            this.statusVersion.AutoSize = false;
            this.statusVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusVersion.Name = "statusVersion";
            this.statusVersion.Size = new System.Drawing.Size(200, 15);
            this.statusVersion.Text = "Version 1.0.0";
            this.statusVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusSpring
            // 
            this.statusSpring.Name = "statusSpring";
            this.statusSpring.Size = new System.Drawing.Size(1, 15);
            this.statusSpring.Spring = true;
            this.statusSpring.Text = " ";
            // 
            // statusDate
            // 
            this.statusDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statusDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDate.Name = "statusDate";
            this.statusDate.Size = new System.Drawing.Size(67, 15);
            this.statusDate.Text = "01/01/2017";
            // 
            // statusTime
            // 
            this.statusTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statusTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTime.Name = "statusTime";
            this.statusTime.Size = new System.Drawing.Size(57, 15);
            this.statusTime.Text = "12:00 AM";
            this.statusTime.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // teUsername
            // 
            this.teUsername.Location = new System.Drawing.Point(64, 40);
            this.teUsername.Name = "teUsername";
            this.teUsername.Size = new System.Drawing.Size(278, 20);
            this.teUsername.StyleController = this.LayoutControlMain;
            this.teUsername.TabIndex = 11;
            this.teUsername.Enter += new System.EventHandler(this.OnTextEditEnter);
            this.teUsername.Leave += new System.EventHandler(this.OnTextEditLeave);
            // 
            // sbCancel
            // 
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Location = new System.Drawing.Point(261, 124);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(81, 22);
            this.sbCancel.StyleController = this.LayoutControlMain;
            this.sbCancel.TabIndex = 9;
            this.sbCancel.Text = "Cancel";
            this.sbCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // sbLogin
            // 
            this.sbLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbLogin.Appearance.Options.UseFont = true;
            this.sbLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbLogin.Location = new System.Drawing.Point(176, 124);
            this.sbLogin.Name = "sbLogin";
            this.sbLogin.Size = new System.Drawing.Size(75, 22);
            this.sbLogin.StyleController = this.LayoutControlMain;
            this.sbLogin.TabIndex = 8;
            this.sbLogin.Text = "OK";
            this.sbLogin.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // lblWarn
            // 
            this.lblWarn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarn.ForeColor = System.Drawing.Color.Red;
            this.lblWarn.Location = new System.Drawing.Point(61, 97);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(284, 20);
            this.lblWarn.TabIndex = 7;
            this.lblWarn.Text = "Invalid username or password. ";
            this.lblWarn.Visible = false;
            // 
            // lueWorkspaces
            // 
            this.lueWorkspaces.Location = new System.Drawing.Point(64, 10);
            this.lueWorkspaces.Name = "lueWorkspaces";
            this.lueWorkspaces.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWorkspaces.Properties.DisplayMember = "Name";
            this.lueWorkspaces.Properties.NullText = "";
            this.lueWorkspaces.Properties.ValueMember = "Id";
            this.lueWorkspaces.Properties.View = this.gridLookUpEdit1View;
            this.lueWorkspaces.Size = new System.Drawing.Size(278, 20);
            this.lueWorkspaces.StyleController = this.LayoutControlMain;
            this.lueWorkspaces.TabIndex = 13;
            this.lueWorkspaces.EditValueChanged += new System.EventHandler(this.lueWorkspaces_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridLookUpEdit1View.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.DodgerBlue;
            this.gridLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.EnableAppearanceEvenRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem10,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.liWarningCaption,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(352, 191);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teUsername;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(342, 30);
            this.layoutControlItem1.Text = "Loginname";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.sbLogin;
            this.layoutControlItem5.Location = new System.Drawing.Point(166, 114);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(31, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Size = new System.Drawing.Size(85, 32);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.statusStrip1;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 157);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(342, 24);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // liWarningCaption
            // 
            this.liWarningCaption.Control = this.lblWarn;
            this.liWarningCaption.Location = new System.Drawing.Point(0, 90);
            this.liWarningCaption.MaxSize = new System.Drawing.Size(0, 24);
            this.liWarningCaption.MinSize = new System.Drawing.Size(78, 24);
            this.liWarningCaption.Name = "liWarningCaption";
            this.liWarningCaption.Size = new System.Drawing.Size(342, 24);
            this.liWarningCaption.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.liWarningCaption.Text = " ";
            this.liWarningCaption.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lueWorkspaces;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem9.Size = new System.Drawing.Size(342, 30);
            this.layoutControlItem9.Text = "Database";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.tePassword;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem8.Size = new System.Drawing.Size(342, 30);
            this.layoutControlItem8.Text = "Passwort";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.sbCancel;
            this.layoutControlItem6.Location = new System.Drawing.Point(251, 114);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(49, 32);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Size = new System.Drawing.Size(91, 32);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 114);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 32);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(110, 32);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.emptySpaceItem1.Size = new System.Drawing.Size(166, 32);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 146);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(342, 11);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.OptionsColumn.AllowShowHide = false;
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colName.OptionsColumn.ShowInCustomizationForm = false;
            this.colName.OptionsColumn.ShowInExpressionEditor = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // QuickZLoginForm
            // 
            this.AcceptButton = this.sbLogin;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.sbCancel;
            this.ClientSize = new System.Drawing.Size(352, 191);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutControlMain);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickZLoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                             QuickZ";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlMain)).EndInit();
            this.LayoutControlMain.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWorkspaces.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liWarningCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblWarn;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbLogin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusVersion;
        private System.Windows.Forms.ToolStripStatusLabel statusDate;
        private System.Windows.Forms.ToolStripStatusLabel statusTime;
        private System.Windows.Forms.ToolStripStatusLabel statusSpring;
        private DevExpress.XtraEditors.TextEdit teUsername;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraLayout.LayoutControl LayoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem liWarningCaption;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.GridLookUpEdit lueWorkspaces;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
    }
}