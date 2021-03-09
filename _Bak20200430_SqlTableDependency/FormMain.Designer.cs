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
            System.Windows.Forms.MenuStrip menuMain;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.miApp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAppSetupDB = new System.Windows.Forms.ToolStripMenuItem();
            this.miAppExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.siSQLServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.siComputer = new System.Windows.Forms.ToolStripStatusLabel();
            this.siUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.siOnTop = new System.Windows.Forms.CheckBox();
            this.btnTrnBegin = new System.Windows.Forms.Button();
            this.btnTrnCommit = new System.Windows.Forms.Button();
            this.btnTrnRollback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScriptOpen = new System.Windows.Forms.Button();
            this.btnScriptSave = new System.Windows.Forms.Button();
            this.btnScriptExecute = new System.Windows.Forms.Button();
            this.tbScript = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.chbCaptureDataChange = new System.Windows.Forms.CheckBox();
            this.dgCaptureChange = new System.Windows.Forms.DataGridView();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            menuMain = new System.Windows.Forms.MenuStrip();
            menuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCaptureChange)).BeginInit();
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
            // menuMain
            // 
            menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miApp,
            this.miHelp});
            menuMain.Location = new System.Drawing.Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new System.Drawing.Size(800, 24);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuMain";
            // 
            // miApp
            // 
            this.miApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAppSetupDB,
            this.miAppExit});
            this.miApp.Name = "miApp";
            this.miApp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.miApp.Size = new System.Drawing.Size(73, 20);
            this.miApp.Text = "Aplication";
            // 
            // miAppSetupDB
            // 
            this.miAppSetupDB.Name = "miAppSetupDB";
            this.miAppSetupDB.Size = new System.Drawing.Size(170, 22);
            this.miAppSetupDB.Text = "SQL server setup...";
            this.miAppSetupDB.Click += new System.EventHandler(this.miAction_Click);
            // 
            // miAppExit
            // 
            this.miAppExit.Name = "miAppExit";
            this.miAppExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.miAppExit.Size = new System.Drawing.Size(170, 22);
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
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel2,
            this.siSQLServer,
            toolStripStatusLabel1,
            this.siComputer,
            toolStripStatusLabel3,
            this.siUser});
            this.statusMain.Location = new System.Drawing.Point(0, 426);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(800, 24);
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
            this.siSQLServer.Size = new System.Drawing.Size(10, 19);
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
            this.siComputer.Size = new System.Drawing.Size(128, 19);
            this.siComputer.Text = "toolStripStatusLabel2";
            // 
            // siUser
            // 
            this.siUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.siUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.siUser.Name = "siUser";
            this.siUser.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.siUser.Size = new System.Drawing.Size(128, 19);
            this.siUser.Text = "toolStripStatusLabel4";
            // 
            // siOnTop
            // 
            this.siOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.siOnTop.AutoSize = true;
            this.siOnTop.Location = new System.Drawing.Point(651, 433);
            this.siOnTop.Name = "siOnTop";
            this.siOnTop.Size = new System.Drawing.Size(91, 17);
            this.siOnTop.TabIndex = 6;
            this.siOnTop.Text = "always on top";
            this.siOnTop.UseVisualStyleBackColor = true;
            this.siOnTop.CheckedChanged += new System.EventHandler(this.siOnTop_CheckedChanged);
            // 
            // btnTrnBegin
            // 
            this.btnTrnBegin.Location = new System.Drawing.Point(90, 31);
            this.btnTrnBegin.Name = "btnTrnBegin";
            this.btnTrnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnTrnBegin.TabIndex = 7;
            this.btnTrnBegin.Text = "Begin";
            this.btnTrnBegin.UseVisualStyleBackColor = true;
            this.btnTrnBegin.Click += new System.EventHandler(this.btnTrnBegin_Click);
            // 
            // btnTrnCommit
            // 
            this.btnTrnCommit.Location = new System.Drawing.Point(171, 31);
            this.btnTrnCommit.Name = "btnTrnCommit";
            this.btnTrnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnTrnCommit.TabIndex = 8;
            this.btnTrnCommit.Text = "Commit";
            this.btnTrnCommit.UseVisualStyleBackColor = true;
            this.btnTrnCommit.Click += new System.EventHandler(this.btnTrnEnd_Click);
            // 
            // btnTrnRollback
            // 
            this.btnTrnRollback.Location = new System.Drawing.Point(252, 31);
            this.btnTrnRollback.Name = "btnTrnRollback";
            this.btnTrnRollback.Size = new System.Drawing.Size(75, 23);
            this.btnTrnRollback.TabIndex = 9;
            this.btnTrnRollback.Text = "Rollback";
            this.btnTrnRollback.UseVisualStyleBackColor = true;
            this.btnTrnRollback.Click += new System.EventHandler(this.btnTrnEnd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Transaction: ";
            // 
            // btnScriptOpen
            // 
            this.btnScriptOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptOpen.Image")));
            this.btnScriptOpen.Location = new System.Drawing.Point(89, 65);
            this.btnScriptOpen.Name = "btnScriptOpen";
            this.btnScriptOpen.Size = new System.Drawing.Size(24, 23);
            this.btnScriptOpen.TabIndex = 3;
            this.btnScriptOpen.Click += new System.EventHandler(this.btnScriptOpen_Click);
            // 
            // btnScriptSave
            // 
            this.btnScriptSave.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptSave.Image")));
            this.btnScriptSave.Location = new System.Drawing.Point(113, 65);
            this.btnScriptSave.Name = "btnScriptSave";
            this.btnScriptSave.Size = new System.Drawing.Size(24, 23);
            this.btnScriptSave.TabIndex = 4;
            this.btnScriptSave.Click += new System.EventHandler(this.btnScriptSave_Click);
            // 
            // btnScriptExecute
            // 
            this.btnScriptExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptExecute.Image")));
            this.btnScriptExecute.Location = new System.Drawing.Point(145, 65);
            this.btnScriptExecute.Name = "btnScriptExecute";
            this.btnScriptExecute.Size = new System.Drawing.Size(79, 23);
            this.btnScriptExecute.TabIndex = 5;
            this.btnScriptExecute.Text = "Execute";
            this.btnScriptExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScriptExecute.Click += new System.EventHandler(this.btnScriptExecute_Click);
            // 
            // tbScript
            // 
            this.tbScript.AcceptsReturn = true;
            this.tbScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScript.HideSelection = false;
            this.tbScript.Location = new System.Drawing.Point(15, 94);
            this.tbScript.Multiline = true;
            this.tbScript.Name = "tbScript";
            this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScript.Size = new System.Drawing.Size(312, 316);
            this.tbScript.TabIndex = 6;
            this.tbScript.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "SQL script: ";
            // 
            // cbTable
            // 
            this.cbTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(522, 36);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(266, 21);
            this.cbTable.TabIndex = 13;
            this.cbTable.DropDown += new System.EventHandler(this.cbTable_DropDown);
            // 
            // chbCaptureDataChange
            // 
            this.chbCaptureDataChange.AllowDrop = true;
            this.chbCaptureDataChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbCaptureDataChange.AutoSize = true;
            this.chbCaptureDataChange.Location = new System.Drawing.Point(354, 36);
            this.chbCaptureDataChange.Name = "chbCaptureDataChange";
            this.chbCaptureDataChange.Size = new System.Drawing.Size(162, 17);
            this.chbCaptureDataChange.TabIndex = 14;
            this.chbCaptureDataChange.Text = "capture data change in table";
            this.chbCaptureDataChange.UseVisualStyleBackColor = true;
            this.chbCaptureDataChange.CheckedChanged += new System.EventHandler(this.chbCaptureDataChange_CheckedChanged);
            // 
            // dgCaptureChange
            // 
            this.dgCaptureChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCaptureChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCaptureChange.Location = new System.Drawing.Point(354, 70);
            this.dgCaptureChange.Name = "dgCaptureChange";
            this.dgCaptureChange.Size = new System.Drawing.Size(434, 340);
            this.dgCaptureChange.TabIndex = 15;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgCaptureChange);
            this.Controls.Add(this.chbCaptureDataChange);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnScriptOpen);
            this.Controls.Add(this.btnScriptSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnScriptExecute);
            this.Controls.Add(this.btnTrnRollback);
            this.Controls.Add(this.tbScript);
            this.Controls.Add(this.btnTrnCommit);
            this.Controls.Add(this.btnTrnBegin);
            this.Controls.Add(this.siOnTop);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "MSSQL test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCaptureChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem miApp;
        private System.Windows.Forms.ToolStripMenuItem miAppSetupDB;
        private System.Windows.Forms.ToolStripMenuItem miAppExit;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
        private System.Windows.Forms.ToolStripStatusLabel siComputer;
        private System.Windows.Forms.ToolStripStatusLabel siUser;
        private System.Windows.Forms.ToolStripStatusLabel siSQLServer;
        private System.Windows.Forms.CheckBox siOnTop;
        private System.Windows.Forms.Button btnTrnBegin;
        private System.Windows.Forms.Button btnTrnCommit;
        private System.Windows.Forms.Button btnTrnRollback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScriptOpen;
        private System.Windows.Forms.Button btnScriptSave;
        private System.Windows.Forms.Button btnScriptExecute;
        private System.Windows.Forms.TextBox tbScript;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.CheckBox chbCaptureDataChange;
        private System.Windows.Forms.DataGridView dgCaptureChange;
    }
}

