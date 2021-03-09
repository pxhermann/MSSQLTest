namespace MSSQLTest
{
    partial class FormMain
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
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
			System.Windows.Forms.MenuStrip tsbSaveScript;
			System.Windows.Forms.SplitContainer splitContainer1;
			System.Windows.Forms.ToolStripLabel toolStripLabel2;
			System.Windows.Forms.ToolStripLabel toolStripLabel3;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.miApp = new System.Windows.Forms.ToolStripMenuItem();
			this.miDBConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.miDBDisconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.miAppExit = new System.Windows.Forms.ToolStripMenuItem();
			this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tbScript = new System.Windows.Forms.TextBox();
			this.dgScriptResult = new System.Windows.Forms.DataGridView();
			this.chbSqlDepCaptureChange = new System.Windows.Forms.CheckBox();
			this.lvSqlDepChanges = new System.Windows.Forms.ListView();
			this.colDt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colSrc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cbSqlDepTable = new System.Windows.Forms.ComboBox();
			this.statusMain = new System.Windows.Forms.StatusStrip();
			this.siSQLServer = new System.Windows.Forms.ToolStripStatusLabel();
			this.siComputer = new System.Windows.Forms.ToolStripStatusLabel();
			this.siUser = new System.Windows.Forms.ToolStripStatusLabel();
			this.siOnTop = new System.Windows.Forms.CheckBox();
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.tsDB = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tsbDBConnect = new System.Windows.Forms.ToolStripButton();
			this.tsbDBDisconnect = new System.Windows.Forms.ToolStripButton();
			this.tsScript = new System.Windows.Forms.ToolStrip();
			this.tsbScriptOpen = new System.Windows.Forms.ToolStripButton();
			this.tsbScriptSave = new System.Windows.Forms.ToolStripButton();
			this.tsbScriptExecute = new System.Windows.Forms.ToolStripButton();
			this.tsTrn = new System.Windows.Forms.ToolStrip();
			this.tsbTrnBegin = new System.Windows.Forms.ToolStripButton();
			this.tsbTrnCommit = new System.Windows.Forms.ToolStripButton();
			this.tsbTrnRollback = new System.Windows.Forms.ToolStripButton();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			tsbSaveScript = new System.Windows.Forms.MenuStrip();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			tsbSaveScript.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgScriptResult)).BeginInit();
			this.statusMain.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.tsDB.SuspendLayout();
			this.tsScript.SuspendLayout();
			this.tsTrn.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(94, 19);
			toolStripStatusLabel1.Text = "Computer name";
			// 
			// toolStripStatusLabel3
			// 
			toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new System.Drawing.Size(72, 19);
			toolStripStatusLabel3.Text = "Current user";
			// 
			// toolStripStatusLabel2
			// 
			toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
			toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			toolStripStatusLabel2.Size = new System.Drawing.Size(62, 19);
			toolStripStatusLabel2.Text = "SQL server";
			// 
			// tsbSaveScript
			// 
			tsbSaveScript.Dock = System.Windows.Forms.DockStyle.None;
			tsbSaveScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miApp,
            this.miHelp});
			tsbSaveScript.Location = new System.Drawing.Point(0, 0);
			tsbSaveScript.Name = "tsbSaveScript";
			tsbSaveScript.Size = new System.Drawing.Size(1036, 24);
			tsbSaveScript.TabIndex = 0;
			tsbSaveScript.Text = "menuMain";
			// 
			// miApp
			// 
			this.miApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDBConnect,
            this.miDBDisconnect,
            this.toolStripSeparator1,
            this.miAppExit});
			this.miApp.Name = "miApp";
			this.miApp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.miApp.Size = new System.Drawing.Size(73, 20);
			this.miApp.Text = "Aplication";
			// 
			// miDBConnect
			// 
			this.miDBConnect.Name = "miDBConnect";
			this.miDBConnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.miDBConnect.Size = new System.Drawing.Size(221, 22);
			this.miDBConnect.Text = "Connec to database";
			this.miDBConnect.Click += new System.EventHandler(this.miAction_Click);
			// 
			// miDBDisconnect
			// 
			this.miDBDisconnect.Name = "miDBDisconnect";
			this.miDBDisconnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.miDBDisconnect.Size = new System.Drawing.Size(221, 22);
			this.miDBDisconnect.Text = "Disconnect";
			this.miDBDisconnect.Click += new System.EventHandler(this.miAction_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
			// 
			// miAppExit
			// 
			this.miAppExit.Name = "miAppExit";
			this.miAppExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.miAppExit.Size = new System.Drawing.Size(221, 22);
			this.miAppExit.Text = "Exit";
			this.miAppExit.Click += new System.EventHandler(this.miAction_Click);
			// 
			// miHelp
			// 
			this.miHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
			this.miHelp.Name = "miHelp";
			this.miHelp.Size = new System.Drawing.Size(44, 20);
			this.miHelp.Text = "Help";
			// 
			// miHelpAbout
			// 
			this.miHelpAbout.Name = "miHelpAbout";
			this.miHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.miHelpAbout.Size = new System.Drawing.Size(135, 22);
			this.miHelpAbout.Text = "About...";
			this.miHelpAbout.Click += new System.EventHandler(this.miAction_Click);
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			splitContainer1.Panel1MinSize = 300;
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(this.chbSqlDepCaptureChange);
			splitContainer1.Panel2.Controls.Add(this.lvSqlDepChanges);
			splitContainer1.Panel2.Controls.Add(this.cbSqlDepTable);
			splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
			splitContainer1.Panel2MinSize = 150;
			splitContainer1.Size = new System.Drawing.Size(1036, 473);
			splitContainer1.SplitterDistance = 650;
			splitContainer1.TabIndex = 16;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tbScript);
			this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(3);
			this.splitContainer2.Panel1MinSize = 150;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.dgScriptResult);
			this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.splitContainer2.Panel2MinSize = 150;
			this.splitContainer2.Size = new System.Drawing.Size(650, 473);
			this.splitContainer2.SplitterDistance = 265;
			this.splitContainer2.TabIndex = 12;
			// 
			// tbScript
			// 
			this.tbScript.AcceptsReturn = true;
			this.tbScript.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbScript.HideSelection = false;
			this.tbScript.Location = new System.Drawing.Point(3, 3);
			this.tbScript.Multiline = true;
			this.tbScript.Name = "tbScript";
			this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbScript.Size = new System.Drawing.Size(644, 259);
			this.tbScript.TabIndex = 6;
			this.tbScript.WordWrap = false;
			// 
			// dgScriptResult
			// 
			this.dgScriptResult.AllowUserToAddRows = false;
			this.dgScriptResult.AllowUserToDeleteRows = false;
			this.dgScriptResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgScriptResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgScriptResult.Location = new System.Drawing.Point(3, 3);
			this.dgScriptResult.Name = "dgScriptResult";
			this.dgScriptResult.ReadOnly = true;
			this.dgScriptResult.Size = new System.Drawing.Size(644, 198);
			this.dgScriptResult.TabIndex = 0;
			// 
			// chbSqlDepCaptureChange
			// 
			this.chbSqlDepCaptureChange.AllowDrop = true;
			this.chbSqlDepCaptureChange.AutoSize = true;
			this.chbSqlDepCaptureChange.Location = new System.Drawing.Point(2, 33);
			this.chbSqlDepCaptureChange.Name = "chbSqlDepCaptureChange";
			this.chbSqlDepCaptureChange.Size = new System.Drawing.Size(143, 17);
			this.chbSqlDepCaptureChange.TabIndex = 14;
			this.chbSqlDepCaptureChange.Text = "capture changes in table";
			this.chbSqlDepCaptureChange.UseVisualStyleBackColor = true;
			this.chbSqlDepCaptureChange.CheckedChanged += new System.EventHandler(this.chbSqlDepCaptureChange_CheckedChanged);
			// 
			// lvSqlDepChanges
			// 
			this.lvSqlDepChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvSqlDepChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDt,
            this.colType,
            this.colSrc});
			this.lvSqlDepChanges.GridLines = true;
			this.lvSqlDepChanges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvSqlDepChanges.HideSelection = false;
			this.lvSqlDepChanges.Location = new System.Drawing.Point(2, 56);
			this.lvSqlDepChanges.MultiSelect = false;
			this.lvSqlDepChanges.Name = "lvSqlDepChanges";
			this.lvSqlDepChanges.Size = new System.Drawing.Size(376, 439);
			this.lvSqlDepChanges.TabIndex = 15;
			this.lvSqlDepChanges.UseCompatibleStateImageBehavior = false;
			this.lvSqlDepChanges.View = System.Windows.Forms.View.Details;
			// 
			// colDt
			// 
			this.colDt.Text = "Time";
			this.colDt.Width = 80;
			// 
			// colType
			// 
			this.colType.Text = "Type";
			this.colType.Width = 80;
			// 
			// colSrc
			// 
			this.colSrc.Text = "Source";
			this.colSrc.Width = 159;
			// 
			// cbSqlDepTable
			// 
			this.cbSqlDepTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSqlDepTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSqlDepTable.FormattingEnabled = true;
			this.cbSqlDepTable.Location = new System.Drawing.Point(2, 3);
			this.cbSqlDepTable.Name = "cbSqlDepTable";
			this.cbSqlDepTable.Size = new System.Drawing.Size(376, 21);
			this.cbSqlDepTable.TabIndex = 13;
			this.cbSqlDepTable.DropDown += new System.EventHandler(this.cbTable_DropDown);
			this.cbSqlDepTable.SelectedIndexChanged += new System.EventHandler(this.cbSqlDepTable_SelectedIndexChanged);
			// 
			// toolStripLabel2
			// 
			toolStripLabel2.Name = "toolStripLabel2";
			toolStripLabel2.Size = new System.Drawing.Size(70, 22);
			toolStripLabel2.Text = "Transaction:";
			// 
			// toolStripLabel3
			// 
			toolStripLabel3.Name = "toolStripLabel3";
			toolStripLabel3.Size = new System.Drawing.Size(58, 22);
			toolStripLabel3.Text = "Sql script:";
			// 
			// statusMain
			// 
			this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel2,
            this.siSQLServer,
            toolStripStatusLabel1,
            this.siComputer,
            toolStripStatusLabel3,
            this.siUser});
			this.statusMain.Location = new System.Drawing.Point(0, 522);
			this.statusMain.Name = "statusMain";
			this.statusMain.Size = new System.Drawing.Size(1036, 24);
			this.statusMain.TabIndex = 1;
			this.statusMain.Text = "statusMain";
			// 
			// siSQLServer
			// 
			this.siSQLServer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.siSQLServer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.siSQLServer.DoubleClickEnabled = true;
			this.siSQLServer.Name = "siSQLServer";
			this.siSQLServer.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.siSQLServer.Size = new System.Drawing.Size(36, 19);
			this.siSQLServer.Text = " - - ";
			this.siSQLServer.DoubleClick += new System.EventHandler(this.siSQLServer_DoubleClick);
			// 
			// siComputer
			// 
			this.siComputer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.siComputer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.siComputer.Name = "siComputer";
			this.siComputer.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.siComputer.Size = new System.Drawing.Size(36, 19);
			this.siComputer.Text = " - - ";
			// 
			// siUser
			// 
			this.siUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.siUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.siUser.Name = "siUser";
			this.siUser.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.siUser.Size = new System.Drawing.Size(36, 19);
			this.siUser.Text = " - - ";
			// 
			// siOnTop
			// 
			this.siOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.siOnTop.AutoSize = true;
			this.siOnTop.Location = new System.Drawing.Point(473, 528);
			this.siOnTop.Name = "siOnTop";
			this.siOnTop.Size = new System.Drawing.Size(91, 17);
			this.siOnTop.TabIndex = 6;
			this.siOnTop.Text = "always on top";
			this.siOnTop.UseVisualStyleBackColor = true;
			this.siOnTop.CheckedChanged += new System.EventHandler(this.siOnTop_CheckedChanged);
			// 
			// toolStripContainer
			// 
			this.toolStripContainer.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.AutoScroll = true;
			this.toolStripContainer.ContentPanel.Controls.Add(splitContainer1);
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1036, 473);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.LeftToolStripPanelVisible = false;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.RightToolStripPanelVisible = false;
			this.toolStripContainer.Size = new System.Drawing.Size(1036, 522);
			this.toolStripContainer.TabIndex = 12;
			this.toolStripContainer.Text = "toolStripContainer";
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(tsbSaveScript);
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.tsDB);
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.tsScript);
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.tsTrn);
			// 
			// tsDB
			// 
			this.tsDB.Dock = System.Windows.Forms.DockStyle.None;
			this.tsDB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbDBConnect,
            this.tsbDBDisconnect});
			this.tsDB.Location = new System.Drawing.Point(3, 24);
			this.tsDB.Name = "tsDB";
			this.tsDB.Size = new System.Drawing.Size(119, 25);
			this.tsDB.TabIndex = 13;
			this.tsDB.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
			this.toolStripLabel1.Text = "Database: ";
			// 
			// tsbDBConnect
			// 
			this.tsbDBConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbDBConnect.Image = global::MSSQLTest.Properties.Resources.connect;
			this.tsbDBConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDBConnect.Name = "tsbDBConnect";
			this.tsbDBConnect.Size = new System.Drawing.Size(23, 22);
			this.tsbDBConnect.Text = "toolStripButton1";
			this.tsbDBConnect.ToolTipText = "Connect to database (Ctrl+C)";
			this.tsbDBConnect.Click += new System.EventHandler(this.miAction_Click);
			// 
			// tsbDBDisconnect
			// 
			this.tsbDBDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbDBDisconnect.Image = global::MSSQLTest.Properties.Resources.disconnect;
			this.tsbDBDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDBDisconnect.Name = "tsbDBDisconnect";
			this.tsbDBDisconnect.Size = new System.Drawing.Size(23, 22);
			this.tsbDBDisconnect.Text = "Disconnect  (Ctrl+D)";
			this.tsbDBDisconnect.Click += new System.EventHandler(this.miAction_Click);
			// 
			// tsScript
			// 
			this.tsScript.Dock = System.Windows.Forms.DockStyle.None;
			this.tsScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel3,
            this.tsbScriptOpen,
            this.tsbScriptSave,
            this.tsbScriptExecute});
			this.tsScript.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.tsScript.Location = new System.Drawing.Point(124, 24);
			this.tsScript.Name = "tsScript";
			this.tsScript.Size = new System.Drawing.Size(184, 25);
			this.tsScript.TabIndex = 1;
			// 
			// tsbScriptOpen
			// 
			this.tsbScriptOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbScriptOpen.Image = global::MSSQLTest.Properties.Resources.open;
			this.tsbScriptOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbScriptOpen.Name = "tsbScriptOpen";
			this.tsbScriptOpen.Size = new System.Drawing.Size(23, 22);
			this.tsbScriptOpen.Text = "Open";
			this.tsbScriptOpen.ToolTipText = "Open file  (Ctrl+O)";
			this.tsbScriptOpen.Click += new System.EventHandler(this.scriptOpen_Click);
			// 
			// tsbScriptSave
			// 
			this.tsbScriptSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbScriptSave.Image = global::MSSQLTest.Properties.Resources.save;
			this.tsbScriptSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbScriptSave.Name = "tsbScriptSave";
			this.tsbScriptSave.Size = new System.Drawing.Size(23, 22);
			this.tsbScriptSave.Text = "Save";
			this.tsbScriptSave.ToolTipText = "Save SQL query (Ctrl+S)";
			this.tsbScriptSave.Click += new System.EventHandler(this.scriptSave_Click);
			// 
			// tsbScriptExecute
			// 
			this.tsbScriptExecute.Image = global::MSSQLTest.Properties.Resources.execute;
			this.tsbScriptExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbScriptExecute.Name = "tsbScriptExecute";
			this.tsbScriptExecute.Size = new System.Drawing.Size(68, 22);
			this.tsbScriptExecute.Text = "Execute";
			this.tsbScriptExecute.ToolTipText = "Execute (F5)";
			this.tsbScriptExecute.Click += new System.EventHandler(this.scriptExecute_Click);
			// 
			// tsTrn
			// 
			this.tsTrn.Dock = System.Windows.Forms.DockStyle.None;
			this.tsTrn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel2,
            this.tsbTrnBegin,
            this.tsbTrnCommit,
            this.tsbTrnRollback});
			this.tsTrn.Location = new System.Drawing.Point(309, 24);
			this.tsTrn.Name = "tsTrn";
			this.tsTrn.Size = new System.Drawing.Size(313, 25);
			this.tsTrn.TabIndex = 0;
			// 
			// tsbTrnBegin
			// 
			this.tsbTrnBegin.Image = global::MSSQLTest.Properties.Resources.begin;
			this.tsbTrnBegin.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTrnBegin.Name = "tsbTrnBegin";
			this.tsbTrnBegin.Size = new System.Drawing.Size(57, 22);
			this.tsbTrnBegin.Text = "Begin";
			this.tsbTrnBegin.ToolTipText = "Begin transaction";
			this.tsbTrnBegin.Click += new System.EventHandler(this.trnBegin_Click);
			// 
			// tsbTrnCommit
			// 
			this.tsbTrnCommit.Image = global::MSSQLTest.Properties.Resources.commit;
			this.tsbTrnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTrnCommit.Name = "tsbTrnCommit";
			this.tsbTrnCommit.Size = new System.Drawing.Size(71, 22);
			this.tsbTrnCommit.Text = "Commit";
			this.tsbTrnCommit.ToolTipText = "Commit transaction";
			this.tsbTrnCommit.Click += new System.EventHandler(this.trnEnd_Click);
			// 
			// tsbTrnRollback
			// 
			this.tsbTrnRollback.Image = global::MSSQLTest.Properties.Resources.rollback;
			this.tsbTrnRollback.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTrnRollback.Name = "tsbTrnRollback";
			this.tsbTrnRollback.Size = new System.Drawing.Size(72, 22);
			this.tsbTrnRollback.Text = "Rollback";
			this.tsbTrnRollback.ToolTipText = "Rollback transaction";
			this.tsbTrnRollback.Click += new System.EventHandler(this.trnEnd_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1036, 546);
			this.Controls.Add(this.toolStripContainer);
			this.Controls.Add(this.siOnTop);
			this.Controls.Add(this.statusMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(700, 400);
			this.Name = "FormMain";
			this.Text = "MSSQL test";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			tsbSaveScript.ResumeLayout(false);
			tsbSaveScript.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
			splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgScriptResult)).EndInit();
			this.statusMain.ResumeLayout(false);
			this.statusMain.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.tsDB.ResumeLayout(false);
			this.tsDB.PerformLayout();
			this.tsScript.ResumeLayout(false);
			this.tsScript.PerformLayout();
			this.tsTrn.ResumeLayout(false);
			this.tsTrn.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem miApp;
        private System.Windows.Forms.ToolStripMenuItem miDBConnect;
        private System.Windows.Forms.ToolStripMenuItem miAppExit;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
        private System.Windows.Forms.ToolStripStatusLabel siComputer;
        private System.Windows.Forms.ToolStripStatusLabel siUser;
        private System.Windows.Forms.ToolStripStatusLabel siSQLServer;
        private System.Windows.Forms.CheckBox siOnTop;
        private System.Windows.Forms.TextBox tbScript;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ComboBox cbSqlDepTable;
        private System.Windows.Forms.CheckBox chbSqlDepCaptureChange;
        private System.Windows.Forms.ListView lvSqlDepChanges;
        private System.Windows.Forms.ColumnHeader colDt;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSrc;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgScriptResult;
		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.ToolStrip tsTrn;
		private System.Windows.Forms.ToolStripButton tsbTrnBegin;
		private System.Windows.Forms.ToolStripButton tsbTrnCommit;
		private System.Windows.Forms.ToolStripButton tsbTrnRollback;
		private System.Windows.Forms.ToolStrip tsScript;
		private System.Windows.Forms.ToolStripButton tsbScriptOpen;
		private System.Windows.Forms.ToolStripButton tsbScriptSave;
		private System.Windows.Forms.ToolStripButton tsbScriptExecute;
		private System.Windows.Forms.ToolStrip tsDB;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton tsbDBConnect;
		private System.Windows.Forms.ToolStripButton tsbDBDisconnect;
		private System.Windows.Forms.ToolStripMenuItem miDBDisconnect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}

