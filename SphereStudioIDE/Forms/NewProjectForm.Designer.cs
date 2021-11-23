namespace SphereStudio.Ide.Forms
{
    partial class NewProjectForm
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
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.typeDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DescLabel = new System.Windows.Forms.Label();
            this.summaryTextBox = new System.Windows.Forms.TextBox();
            this.resoDropDown = new System.Windows.Forms.ComboBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.ResoLabel = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Label();
            this.projectPanel = new System.Windows.Forms.Panel();
            this.projectHeading = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gameHeading = new System.Windows.Forms.Label();
            this.footer.SuspendLayout();
            this.projectPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryTextBox.Location = new System.Drawing.Point(81, 60);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.ReadOnly = true;
            this.directoryTextBox.Size = new System.Drawing.Size(298, 22);
            this.directoryTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(81, 32);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(298, 22);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(22, 63);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(53, 13);
            this.DirectoryLabel.TabIndex = 2;
            this.DirectoryLabel.Text = "Directory";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(39, 35);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(36, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(320, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(234, 13);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 25);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // typeDropDown
            // 
            this.typeDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeDropDown.FormattingEnabled = true;
            this.typeDropDown.Location = new System.Drawing.Point(81, 88);
            this.typeDropDown.Name = "typeDropDown";
            this.typeDropDown.Size = new System.Drawing.Size(298, 21);
            this.typeDropDown.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type";
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(22, 91);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(53, 13);
            this.DescLabel.TabIndex = 4;
            this.DescLabel.Text = "Summary";
            // 
            // summaryTextBox
            // 
            this.summaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryTextBox.Location = new System.Drawing.Point(80, 88);
            this.summaryTextBox.Multiline = true;
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.Size = new System.Drawing.Size(298, 78);
            this.summaryTextBox.TabIndex = 5;
            // 
            // resolutionDropDown
            // 
            this.resoDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resoDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resoDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resoDropDown.FormattingEnabled = true;
            this.resoDropDown.Items.AddRange(new object[] {
            "(custom resolution)",
            "320x240",
            "640x480",
            "800x600",
            "1024x768",
            "1280x720",
            "1920x1080"});
            this.resoDropDown.Location = new System.Drawing.Point(80, 172);
            this.resoDropDown.Name = "resolutionDropDown";
            this.resoDropDown.Size = new System.Drawing.Size(210, 21);
            this.resoDropDown.TabIndex = 7;
            this.resoDropDown.SelectedIndexChanged += new System.EventHandler(this.resoDropDown_SelectedIndexChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.heightTextBox.Location = new System.Drawing.Point(340, 172);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(38, 22);
            this.heightTextBox.TabIndex = 9;
            this.heightTextBox.TextChanged += new System.EventHandler(this.resoTextBox_TextChanged);
            this.heightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resoTextBox_KeyPress);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.widthTextBox.Location = new System.Drawing.Point(296, 172);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(38, 22);
            this.widthTextBox.TabIndex = 8;
            this.widthTextBox.TextChanged += new System.EventHandler(this.resoTextBox_TextChanged);
            this.widthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resoTextBox_KeyPress);
            // 
            // ResoLabel
            // 
            this.ResoLabel.AutoSize = true;
            this.ResoLabel.Location = new System.Drawing.Point(12, 175);
            this.ResoLabel.Name = "ResoLabel";
            this.ResoLabel.Size = new System.Drawing.Size(63, 13);
            this.ResoLabel.TabIndex = 6;
            this.ResoLabel.Text = "Resolution";
            // 
            // footer
            // 
            this.footer.Controls.Add(this.okButton);
            this.footer.Controls.Add(this.cancelButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 384);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(410, 50);
            this.footer.TabIndex = 3;
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(410, 23);
            this.header.TabIndex = 0;
            this.header.Text = "start working on a new Sphere game project";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // projectPanel
            // 
            this.projectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectPanel.Controls.Add(this.typeDropDown);
            this.projectPanel.Controls.Add(this.label2);
            this.projectPanel.Controls.Add(this.projectHeading);
            this.projectPanel.Controls.Add(this.directoryTextBox);
            this.projectPanel.Controls.Add(this.nameTextBox);
            this.projectPanel.Controls.Add(this.NameLabel);
            this.projectPanel.Controls.Add(this.DirectoryLabel);
            this.projectPanel.Location = new System.Drawing.Point(9, 35);
            this.projectPanel.Name = "projectPanel";
            this.projectPanel.Size = new System.Drawing.Size(389, 122);
            this.projectPanel.TabIndex = 1;
            // 
            // projectHeading
            // 
            this.projectHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.projectHeading.Location = new System.Drawing.Point(0, 0);
            this.projectHeading.Name = "projectHeading";
            this.projectHeading.Size = new System.Drawing.Size(387, 23);
            this.projectHeading.TabIndex = 0;
            this.projectHeading.Text = "Your Project";
            this.projectHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel.Controls.Add(this.authorTextBox);
            this.gamePanel.Controls.Add(this.titleTextBox);
            this.gamePanel.Controls.Add(this.label6);
            this.gamePanel.Controls.Add(this.label4);
            this.gamePanel.Controls.Add(this.summaryTextBox);
            this.gamePanel.Controls.Add(this.DescLabel);
            this.gamePanel.Controls.Add(this.gameHeading);
            this.gamePanel.Controls.Add(this.resoDropDown);
            this.gamePanel.Controls.Add(this.ResoLabel);
            this.gamePanel.Controls.Add(this.heightTextBox);
            this.gamePanel.Controls.Add(this.widthTextBox);
            this.gamePanel.Location = new System.Drawing.Point(9, 163);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(389, 206);
            this.gamePanel.TabIndex = 2;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorTextBox.Location = new System.Drawing.Point(80, 60);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(298, 22);
            this.authorTextBox.TabIndex = 3;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(80, 32);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(298, 22);
            this.titleTextBox.TabIndex = 1;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Author";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Title";
            // 
            // gameHeading
            // 
            this.gameHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.gameHeading.Location = new System.Drawing.Point(0, 0);
            this.gameHeading.Name = "gameHeading";
            this.gameHeading.Size = new System.Drawing.Size(387, 23);
            this.gameHeading.TabIndex = 0;
            this.gameHeading.Text = "Game Information";
            this.gameHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewProjectForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(410, 434);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.projectPanel);
            this.Controls.Add(this.header);
            this.Controls.Add(this.footer);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start New Project";
            this.footer.ResumeLayout(false);
            this.projectPanel.ResumeLayout(false);
            this.projectPanel.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label ResoLabel;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.ComboBox resoDropDown;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.TextBox summaryTextBox;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.ComboBox typeDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel projectPanel;
        private System.Windows.Forms.Label projectHeading;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label gameHeading;
    }
}