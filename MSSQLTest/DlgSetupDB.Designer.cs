namespace MSSQLTest
{
    partial class DlgSetupDB
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
            System.Windows.Forms.Label lblDB;
            System.Windows.Forms.Label lblServer;
            System.Windows.Forms.Label lblPwd;
            System.Windows.Forms.Label lblAuth;
            System.Windows.Forms.Label lblUser;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbSqlDB = new System.Windows.Forms.ComboBox();
            this.cbSqlServer = new System.Windows.Forms.ComboBox();
            this.btnSqlTestConn = new System.Windows.Forms.Button();
            this.tbSqlPwd = new System.Windows.Forms.TextBox();
            this.tbSqlUser = new System.Windows.Forms.TextBox();
            this.radioAuthSQL = new System.Windows.Forms.RadioButton();
            this.radioAuthWin = new System.Windows.Forms.RadioButton();
            lblDB = new System.Windows.Forms.Label();
            lblServer = new System.Windows.Forms.Label();
            lblPwd = new System.Windows.Forms.Label();
            lblAuth = new System.Windows.Forms.Label();
            lblUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDB
            // 
            lblDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            lblDB.ForeColor = System.Drawing.SystemColors.ControlText;
            lblDB.Location = new System.Drawing.Point(2, 131);
            lblDB.Margin = new System.Windows.Forms.Padding(1);
            lblDB.Name = "lblDB";
            lblDB.Size = new System.Drawing.Size(83, 20);
            lblDB.TabIndex = 10;
            lblDB.Text = "Database name";
            lblDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServer
            // 
            lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            lblServer.ForeColor = System.Drawing.SystemColors.ControlText;
            lblServer.Location = new System.Drawing.Point(5, 12);
            lblServer.Name = "lblServer";
            lblServer.Size = new System.Drawing.Size(80, 20);
            lblServer.TabIndex = 0;
            lblServer.Text = "Server name";
            lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPwd
            // 
            lblPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            lblPwd.ForeColor = System.Drawing.SystemColors.ControlText;
            lblPwd.Location = new System.Drawing.Point(5, 96);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new System.Drawing.Size(80, 20);
            lblPwd.TabIndex = 7;
            lblPwd.Text = "Password";
            lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAuth
            // 
            lblAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            lblAuth.ForeColor = System.Drawing.SystemColors.ControlText;
            lblAuth.Location = new System.Drawing.Point(5, 40);
            lblAuth.Name = "lblAuth";
            lblAuth.Size = new System.Drawing.Size(80, 20);
            lblAuth.TabIndex = 2;
            lblAuth.Text = "Authentication";
            lblAuth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            lblUser.ForeColor = System.Drawing.SystemColors.ControlText;
            lblUser.Location = new System.Drawing.Point(5, 69);
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(80, 20);
            lblUser.TabIndex = 5;
            lblUser.Text = "User";
            lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(295, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 27);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Storno";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(177, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 27);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cbSqlDB
            // 
            this.cbSqlDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSqlDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSqlDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSqlDB.Location = new System.Drawing.Point(89, 131);
            this.cbSqlDB.Name = "cbSqlDB";
            this.cbSqlDB.Size = new System.Drawing.Size(313, 21);
            this.cbSqlDB.TabIndex = 11;
            this.cbSqlDB.DropDown += new System.EventHandler(this.cbSqlDB_DropDown);
            // 
            // cbSqlServer
            // 
            this.cbSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSqlServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSqlServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSqlServer.Location = new System.Drawing.Point(89, 12);
            this.cbSqlServer.Name = "cbSqlServer";
            this.cbSqlServer.Size = new System.Drawing.Size(313, 21);
            this.cbSqlServer.TabIndex = 1;
            this.cbSqlServer.DropDown += new System.EventHandler(this.cbSqlServer_DropDown);
            // 
            // btnSqlTestConn
            // 
            this.btnSqlTestConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSqlTestConn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSqlTestConn.Location = new System.Drawing.Point(222, 78);
            this.btnSqlTestConn.Name = "btnSqlTestConn";
            this.btnSqlTestConn.Size = new System.Drawing.Size(107, 30);
            this.btnSqlTestConn.TabIndex = 9;
            this.btnSqlTestConn.Text = "Test connection...";
            this.btnSqlTestConn.Click += new System.EventHandler(this.btnSqlTestConn_Click);
            // 
            // tbSqlPwd
            // 
            this.tbSqlPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSqlPwd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbSqlPwd.Location = new System.Drawing.Point(89, 96);
            this.tbSqlPwd.Name = "tbSqlPwd";
            this.tbSqlPwd.PasswordChar = '*';
            this.tbSqlPwd.Size = new System.Drawing.Size(120, 20);
            this.tbSqlPwd.TabIndex = 8;
            // 
            // tbSqlUser
            // 
            this.tbSqlUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSqlUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbSqlUser.Location = new System.Drawing.Point(89, 68);
            this.tbSqlUser.Name = "tbSqlUser";
            this.tbSqlUser.Size = new System.Drawing.Size(120, 20);
            this.tbSqlUser.TabIndex = 6;
            // 
            // radioAuthSQL
            // 
            this.radioAuthSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioAuthSQL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioAuthSQL.Location = new System.Drawing.Point(89, 40);
            this.radioAuthSQL.Name = "radioAuthSQL";
            this.radioAuthSQL.Size = new System.Drawing.Size(109, 21);
            this.radioAuthSQL.TabIndex = 3;
            this.radioAuthSQL.Text = "SQL server";
            this.radioAuthSQL.CheckedChanged += new System.EventHandler(this.radioAuthSQL_CheckedChanged);
            // 
            // radioAuthWin
            // 
            this.radioAuthWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioAuthWin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioAuthWin.Location = new System.Drawing.Point(217, 40);
            this.radioAuthWin.Name = "radioAuthWin";
            this.radioAuthWin.Size = new System.Drawing.Size(107, 21);
            this.radioAuthWin.TabIndex = 4;
            this.radioAuthWin.Text = "Windows";
            // 
            // DlgSetupDB
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 211);
            this.Controls.Add(lblDB);
            this.Controls.Add(this.cbSqlDB);
            this.Controls.Add(this.cbSqlServer);
            this.Controls.Add(lblServer);
            this.Controls.Add(this.btnSqlTestConn);
            this.Controls.Add(this.tbSqlPwd);
            this.Controls.Add(lblPwd);
            this.Controls.Add(lblAuth);
            this.Controls.Add(this.tbSqlUser);
            this.Controls.Add(this.radioAuthSQL);
            this.Controls.Add(lblUser);
            this.Controls.Add(this.radioAuthWin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "DlgSetupDB";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection to database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgSetupDB_FormClosing);
            this.Load += new System.EventHandler(this.DlgSetupDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbSqlDB;
        private System.Windows.Forms.ComboBox cbSqlServer;
        private System.Windows.Forms.Button btnSqlTestConn;
        private System.Windows.Forms.TextBox tbSqlPwd;
        private System.Windows.Forms.TextBox tbSqlUser;
        private System.Windows.Forms.RadioButton radioAuthSQL;
        private System.Windows.Forms.RadioButton radioAuthWin;
    }
}