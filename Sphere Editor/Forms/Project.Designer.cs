namespace Sphere_Editor.Forms
{
    partial class Project
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
            this.ProjectBox = new System.Windows.Forms.GroupBox();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.DirectoryBox = new System.Windows.Forms.TextBox();
            this.FolderBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.FolderFinder = new System.Windows.Forms.FolderBrowserDialog();
            this.PropertiesBox = new System.Windows.Forms.GroupBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.ResoComboBox = new System.Windows.Forms.ComboBox();
            this.XLabel = new System.Windows.Forms.Label();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.ResoLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.AuthorBox = new System.Windows.Forms.TextBox();
            this.RequiredLabel = new System.Windows.Forms.Label();
            this.NewProjectStatus = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.NewProjectPic = new System.Windows.Forms.PictureBox();
            this.ProjectBox.SuspendLayout();
            this.PropertiesBox.SuspendLayout();
            this.NewProjectStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewProjectPic)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectBox
            // 
            this.ProjectBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectBox.Controls.Add(this.FolderBrowseButton);
            this.ProjectBox.Controls.Add(this.DirectoryBox);
            this.ProjectBox.Controls.Add(this.FolderBox);
            this.ProjectBox.Controls.Add(this.NameBox);
            this.ProjectBox.Controls.Add(this.DirectoryLabel);
            this.ProjectBox.Controls.Add(this.FolderLabel);
            this.ProjectBox.Controls.Add(this.NameLabel);
            this.ProjectBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectBox.Location = new System.Drawing.Point(12, 46);
            this.ProjectBox.Name = "ProjectBox";
            this.ProjectBox.Size = new System.Drawing.Size(296, 107);
            this.ProjectBox.TabIndex = 1;
            this.ProjectBox.TabStop = false;
            this.ProjectBox.Text = "Project";
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBrowseButton.Image = global::Sphere_Editor.Properties.Resources.folder;
            this.FolderBrowseButton.Location = new System.Drawing.Point(257, 48);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(31, 23);
            this.FolderBrowseButton.TabIndex = 6;
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // DirectoryBox
            // 
            this.DirectoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryBox.Enabled = false;
            this.DirectoryBox.Location = new System.Drawing.Point(85, 74);
            this.DirectoryBox.Name = "DirectoryBox";
            this.DirectoryBox.Size = new System.Drawing.Size(203, 20);
            this.DirectoryBox.TabIndex = 5;
            // 
            // FolderBox
            // 
            this.FolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBox.Location = new System.Drawing.Point(85, 48);
            this.FolderBox.Name = "FolderBox";
            this.FolderBox.Size = new System.Drawing.Size(165, 20);
            this.FolderBox.TabIndex = 4;
            this.FolderBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FillDirectory);
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.Location = new System.Drawing.Point(85, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(165, 20);
            this.NameBox.TabIndex = 3;
            this.NameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FillDirectory);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(6, 77);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(62, 13);
            this.DirectoryLabel.TabIndex = 2;
            this.DirectoryLabel.Text = "Directory:";
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Location = new System.Drawing.Point(6, 51);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(51, 13);
            this.FolderLabel.TabIndex = 1;
            this.FolderLabel.Text = "*Folder:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(6, 22);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(48, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "*Name:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(82, 464);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(163, 464);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "Create!";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // PropertiesBox
            // 
            this.PropertiesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesBox.Controls.Add(this.DescLabel);
            this.PropertiesBox.Controls.Add(this.DescriptionBox);
            this.PropertiesBox.Controls.Add(this.ResoComboBox);
            this.PropertiesBox.Controls.Add(this.XLabel);
            this.PropertiesBox.Controls.Add(this.HeightBox);
            this.PropertiesBox.Controls.Add(this.WidthBox);
            this.PropertiesBox.Controls.Add(this.ResoLabel);
            this.PropertiesBox.Controls.Add(this.AuthorLabel);
            this.PropertiesBox.Controls.Add(this.AuthorBox);
            this.PropertiesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertiesBox.Location = new System.Drawing.Point(12, 172);
            this.PropertiesBox.Name = "PropertiesBox";
            this.PropertiesBox.Size = new System.Drawing.Size(296, 286);
            this.PropertiesBox.TabIndex = 4;
            this.PropertiesBox.TabStop = false;
            this.PropertiesBox.Text = "Properties";
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(6, 101);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(75, 13);
            this.DescLabel.TabIndex = 8;
            this.DescLabel.Text = "Description:";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBox.Location = new System.Drawing.Point(6, 117);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(278, 145);
            this.DescriptionBox.TabIndex = 7;
            // 
            // ResoComboBox
            // 
            this.ResoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResoComboBox.FormattingEnabled = true;
            this.ResoComboBox.Items.AddRange(new object[] {
            "320x240",
            "640x480",
            "800x600",
            "1024x768"});
            this.ResoComboBox.Location = new System.Drawing.Point(101, 51);
            this.ResoComboBox.Name = "ResoComboBox";
            this.ResoComboBox.Size = new System.Drawing.Size(183, 21);
            this.ResoComboBox.TabIndex = 6;
            this.ResoComboBox.Text = "Choose:";
            this.ResoComboBox.SelectedIndexChanged += new System.EventHandler(this.ResoComboBox_SelectedIndexChanged);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(166, 81);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(13, 13);
            this.XLabel.TabIndex = 5;
            this.XLabel.Text = "x";
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(185, 78);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(59, 20);
            this.HeightBox.TabIndex = 4;
            this.HeightBox.Text = "240";
            this.HeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(101, 78);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(59, 20);
            this.WidthBox.TabIndex = 3;
            this.WidthBox.Text = "320";
            this.WidthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // ResoLabel
            // 
            this.ResoLabel.AutoSize = true;
            this.ResoLabel.Location = new System.Drawing.Point(6, 59);
            this.ResoLabel.Name = "ResoLabel";
            this.ResoLabel.Size = new System.Drawing.Size(71, 13);
            this.ResoLabel.TabIndex = 2;
            this.ResoLabel.Text = "Resolution:";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(6, 22);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(48, 13);
            this.AuthorLabel.TabIndex = 1;
            this.AuthorLabel.Text = "Author:";
            // 
            // AuthorBox
            // 
            this.AuthorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorBox.Location = new System.Drawing.Point(85, 19);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(199, 20);
            this.AuthorBox.TabIndex = 0;
            this.AuthorBox.Text = "Unknown";
            // 
            // RequiredLabel
            // 
            this.RequiredLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RequiredLabel.AutoSize = true;
            this.RequiredLabel.Location = new System.Drawing.Point(182, 156);
            this.RequiredLabel.Name = "RequiredLabel";
            this.RequiredLabel.Size = new System.Drawing.Size(126, 13);
            this.RequiredLabel.TabIndex = 5;
            this.RequiredLabel.Text = "* Denotes a required field";
            // 
            // NewProjectStatus
            // 
            this.NewProjectStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.NewProjectStatus.Location = new System.Drawing.Point(0, 490);
            this.NewProjectStatus.Name = "NewProjectStatus";
            this.NewProjectStatus.Size = new System.Drawing.Size(320, 22);
            this.NewProjectStatus.SizingGrip = false;
            this.NewProjectStatus.TabIndex = 6;
            this.NewProjectStatus.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.ForeColor = System.Drawing.Color.Black;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(184, 17);
            this.StatusLabel.Text = "You\'ll need a name and directory.";
            // 
            // NewProjectPic
            // 
            this.NewProjectPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewProjectPic.Image = global::Sphere_Editor.Properties.Resources.NewGame;
            this.NewProjectPic.InitialImage = global::Sphere_Editor.Properties.Resources.NewGame;
            this.NewProjectPic.Location = new System.Drawing.Point(0, 0);
            this.NewProjectPic.Name = "NewProjectPic";
            this.NewProjectPic.Size = new System.Drawing.Size(320, 40);
            this.NewProjectPic.TabIndex = 0;
            this.NewProjectPic.TabStop = false;
            // 
            // Project
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 512);
            this.Controls.Add(this.NewProjectStatus);
            this.Controls.Add(this.RequiredLabel);
            this.Controls.Add(this.PropertiesBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.ProjectBox);
            this.Controls.Add(this.NewProjectPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 540);
            this.Name = "Project";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.ProjectBox.ResumeLayout(false);
            this.ProjectBox.PerformLayout();
            this.PropertiesBox.ResumeLayout(false);
            this.PropertiesBox.PerformLayout();
            this.NewProjectStatus.ResumeLayout(false);
            this.NewProjectStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewProjectPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox NewProjectPic;
        private System.Windows.Forms.GroupBox ProjectBox;
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.Label FolderLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox DirectoryBox;
        private System.Windows.Forms.TextBox FolderBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button FolderBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog FolderFinder;
        private System.Windows.Forms.GroupBox PropertiesBox;
        private System.Windows.Forms.Label ResoLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.TextBox AuthorBox;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.ComboBox ResoComboBox;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label RequiredLabel;
        private System.Windows.Forms.StatusStrip NewProjectStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    }
}