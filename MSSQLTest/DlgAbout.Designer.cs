namespace MSSQLTest
{
    partial class DlgAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.lblMail = new System.Windows.Forms.LinkLabel();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.img = new System.Windows.Forms.PictureBox();
            this.tbDescr = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(68, 105);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(122, 13);
            this.lblMail.TabIndex = 33;
            this.lblMail.TabStop = true;
            this.lblMail.Text = "pavel.hermann@post.cz";
            this.lblMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMail_LinkClicked);
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Location = new System.Drawing.Point(68, 81);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(229, 17);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "Company Name";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.Location = new System.Drawing.Point(68, 59);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(173, 17);
            this.lblCopyright.TabIndex = 29;
            this.lblCopyright.Text = "Copyright";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Location = new System.Drawing.Point(68, 37);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(173, 17);
            this.lblVersion.TabIndex = 26;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProduct.Location = new System.Drawing.Point(68, 15);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(291, 17);
            this.lblProduct.TabIndex = 28;
            this.lblProduct.Text = "Product Name";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // img
            // 
            this.img.Image = global::MSSQLTest.Properties.Resources.PH;
            this.img.Location = new System.Drawing.Point(13, 49);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(32, 32);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.img.TabIndex = 27;
            this.img.TabStop = false;
            // 
            // tbDescr
            // 
            this.tbDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescr.Location = new System.Drawing.Point(13, 136);
            this.tbDescr.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.tbDescr.Multiline = true;
            this.tbDescr.Name = "tbDescr";
            this.tbDescr.ReadOnly = true;
            this.tbDescr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescr.Size = new System.Drawing.Size(345, 66);
            this.tbDescr.TabIndex = 31;
            this.tbDescr.TabStop = false;
            this.tbDescr.Text = "Description";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(258, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "OK";
            // 
            // DlgAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(372, 217);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.img);
            this.Controls.Add(this.tbDescr);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgAbout";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About...";
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblMail;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.TextBox tbDescr;
        private System.Windows.Forms.Button btnClose;

    }
}
