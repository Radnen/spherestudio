namespace SphereStudio.Ide.Forms
{
    partial class AboutBoxForm
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
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.creditsTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.websiteUrlLink = new System.Windows.Forms.LinkLabel();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelPlatform = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.versionPanel = new System.Windows.Forms.Panel();
            this.versionHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.header = new System.Windows.Forms.Label();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.versionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.Location = new System.Drawing.Point(54, 34);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(178, 20);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Program name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Location = new System.Drawing.Point(54, 74);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(178, 20);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright notice";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // creditsTextBox
            // 
            this.creditsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creditsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creditsTextBox.Location = new System.Drawing.Point(12, 151);
            this.creditsTextBox.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.creditsTextBox.Multiline = true;
            this.creditsTextBox.Name = "creditsTextBox";
            this.creditsTextBox.ReadOnly = true;
            this.creditsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.creditsTextBox.Size = new System.Drawing.Size(415, 130);
            this.creditsTextBox.TabIndex = 23;
            this.creditsTextBox.TabStop = false;
            this.creditsTextBox.Text = "Description";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(347, 13);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 25);
            this.closeButton.TabIndex = 24;
            this.closeButton.Text = "Close";
            // 
            // websiteUrlLink
            // 
            this.websiteUrlLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.websiteUrlLink.AutoSize = true;
            this.websiteUrlLink.LinkArea = new System.Windows.Forms.LinkArea(12, 25);
            this.websiteUrlLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.websiteUrlLink.Location = new System.Drawing.Point(56, 18);
            this.websiteUrlLink.Name = "websiteUrlLink";
            this.websiteUrlLink.Size = new System.Drawing.Size(206, 21);
            this.websiteUrlLink.TabIndex = 25;
            this.websiteUrlLink.TabStop = true;
            this.websiteUrlLink.Text = "visit us at http://www.spheredev.org/";
            this.websiteUrlLink.UseCompatibleTextRendering = true;
            this.websiteUrlLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteUrlLink_LinkClicked);
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Location = new System.Drawing.Point(54, 54);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(178, 20);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "Company name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPlatform
            // 
            this.labelPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlatform.Location = new System.Drawing.Point(273, 37);
            this.labelPlatform.Name = "labelPlatform";
            this.labelPlatform.Size = new System.Drawing.Size(128, 57);
            this.labelPlatform.TabIndex = 29;
            this.labelPlatform.Text = "OS version";
            this.labelPlatform.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.pictureBox2);
            this.footerPanel.Controls.Add(this.closeButton);
            this.footerPanel.Controls.Add(this.websiteUrlLink);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 294);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(439, 50);
            this.footerPanel.TabIndex = 30;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SphereStudio.Ide.Properties.Resources.SphericalLogo;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // versionPanel
            // 
            this.versionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.versionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.versionPanel.Controls.Add(this.versionHeader);
            this.versionPanel.Controls.Add(this.pictureBox1);
            this.versionPanel.Controls.Add(this.labelPlatform);
            this.versionPanel.Controls.Add(this.labelProductName);
            this.versionPanel.Controls.Add(this.labelCopyright);
            this.versionPanel.Controls.Add(this.labelCompanyName);
            this.versionPanel.Location = new System.Drawing.Point(12, 35);
            this.versionPanel.Name = "versionPanel";
            this.versionPanel.Size = new System.Drawing.Size(415, 110);
            this.versionPanel.TabIndex = 31;
            // 
            // versionHeader
            // 
            this.versionHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.versionHeader.Location = new System.Drawing.Point(0, 0);
            this.versionHeader.Name = "versionHeader";
            this.versionHeader.Size = new System.Drawing.Size(413, 23);
            this.versionHeader.TabIndex = 0;
            this.versionHeader.Text = "Version Information";
            this.versionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SphereStudio.Ide.Properties.Resources.SphereEditor;
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(439, 23);
            this.header.TabIndex = 32;
            this.header.Text = "information about this version of Sphere Studio";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(439, 344);
            this.Controls.Add(this.header);
            this.Controls.Add(this.versionPanel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.creditsTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.versionPanel.ResumeLayout(false);
            this.versionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.TextBox creditsTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.LinkLabel websiteUrlLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label labelPlatform;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Panel versionPanel;
        private System.Windows.Forms.Label versionHeader;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
