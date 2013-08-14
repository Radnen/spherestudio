namespace SphereStudio.Forms
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
            this.ProjectBox.Location = new System.Drawing.Point(14, 45);
            this.ProjectBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProjectBox.Name = "ProjectBox";
            this.ProjectBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProjectBox.Size = new System.Drawing.Size(329, 132);
            this.ProjectBox.TabIndex = 1;
            this.ProjectBox.TabStop = false;
            this.ProjectBox.Text = "Project";
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBrowseButton.Image = global::SphereStudio.Properties.Resources.folder;
            this.FolderBrowseButton.Location = new System.Drawing.Point(284, 59);
            this.FolderBrowseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(36, 28);
            this.FolderBrowseButton.TabIndex = 6;
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // DirectoryBox
            // 
            this.DirectoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryBox.Enabled = false;
            this.DirectoryBox.Location = new System.Drawing.Point(99, 91);
            this.DirectoryBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DirectoryBox.Name = "DirectoryBox";
            this.DirectoryBox.Size = new System.Drawing.Size(220, 23);
            this.DirectoryBox.TabIndex = 5;
            // 
            // FolderBox
            // 
            this.FolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBox.Location = new System.Drawing.Point(99, 59);
            this.FolderBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FolderBox.Name = "FolderBox";
            this.FolderBox.Size = new System.Drawing.Size(176, 23);
            this.FolderBox.TabIndex = 4;
            this.FolderBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FillDirectory);
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.Location = new System.Drawing.Point(99, 23);
            this.NameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(176, 23);
            this.NameBox.TabIndex = 3;
            this.NameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FillDirectory);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(7, 95);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(64, 16);
            this.DirectoryLabel.TabIndex = 2;
            this.DirectoryLabel.Text = "Directory:";
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Location = new System.Drawing.Point(7, 63);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(57, 16);
            this.FolderLabel.TabIndex = 1;
            this.FolderLabel.Text = "*Folder:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(7, 27);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(54, 16);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "*Name:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(87, 559);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 28);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(181, 559);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 28);
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
            this.PropertiesBox.Location = new System.Drawing.Point(14, 201);
            this.PropertiesBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PropertiesBox.Name = "PropertiesBox";
            this.PropertiesBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PropertiesBox.Size = new System.Drawing.Size(329, 351);
            this.PropertiesBox.TabIndex = 4;
            this.PropertiesBox.TabStop = false;
            this.PropertiesBox.Text = "Properties";
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(7, 124);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(76, 16);
            this.DescLabel.TabIndex = 8;
            this.DescLabel.Text = "Description:";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBox.Location = new System.Drawing.Point(7, 144);
            this.DescriptionBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(308, 177);
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
            this.ResoComboBox.Location = new System.Drawing.Point(118, 63);
            this.ResoComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResoComboBox.Name = "ResoComboBox";
            this.ResoComboBox.Size = new System.Drawing.Size(197, 24);
            this.ResoComboBox.TabIndex = 6;
            this.ResoComboBox.Text = "Choose:";
            this.ResoComboBox.SelectedIndexChanged += new System.EventHandler(this.ResoComboBox_SelectedIndexChanged);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(194, 100);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 16);
            this.XLabel.TabIndex = 5;
            this.XLabel.Text = "x";
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(216, 96);
            this.HeightBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(68, 23);
            this.HeightBox.TabIndex = 4;
            this.HeightBox.Text = "240";
            this.HeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(118, 96);
            this.WidthBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(68, 23);
            this.WidthBox.TabIndex = 3;
            this.WidthBox.Text = "320";
            this.WidthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // ResoLabel
            // 
            this.ResoLabel.AutoSize = true;
            this.ResoLabel.Location = new System.Drawing.Point(7, 73);
            this.ResoLabel.Name = "ResoLabel";
            this.ResoLabel.Size = new System.Drawing.Size(72, 16);
            this.ResoLabel.TabIndex = 2;
            this.ResoLabel.Text = "Resolution:";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(7, 27);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(51, 16);
            this.AuthorLabel.TabIndex = 1;
            this.AuthorLabel.Text = "Author:";
            // 
            // AuthorBox
            // 
            this.AuthorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorBox.Location = new System.Drawing.Point(99, 23);
            this.AuthorBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(215, 23);
            this.AuthorBox.TabIndex = 0;
            this.AuthorBox.Text = "Unknown";
            // 
            // RequiredLabel
            // 
            this.RequiredLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RequiredLabel.AutoSize = true;
            this.RequiredLabel.Location = new System.Drawing.Point(186, 181);
            this.RequiredLabel.Name = "RequiredLabel";
            this.RequiredLabel.Size = new System.Drawing.Size(157, 16);
            this.RequiredLabel.TabIndex = 5;
            this.RequiredLabel.Text = "* Denotes a required field";
            // 
            // NewProjectStatus
            // 
            this.NewProjectStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewProjectStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.NewProjectStatus.Location = new System.Drawing.Point(0, 596);
            this.NewProjectStatus.Name = "NewProjectStatus";
            this.NewProjectStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.NewProjectStatus.Size = new System.Drawing.Size(355, 22);
            this.NewProjectStatus.SizingGrip = false;
            this.NewProjectStatus.TabIndex = 6;
            this.NewProjectStatus.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(184, 17);
            this.StatusLabel.Text = "You\'ll need a name and directory.";
            // 
            // NewProjectPic
            // 
            this.NewProjectPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewProjectPic.Image = global::SphereStudio.Properties.Resources.NewGame;
            this.NewProjectPic.InitialImage = global::SphereStudio.Properties.Resources.NewGame;
            this.NewProjectPic.Location = new System.Drawing.Point(0, 0);
            this.NewProjectPic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewProjectPic.Name = "NewProjectPic";
            this.NewProjectPic.Size = new System.Drawing.Size(355, 37);
            this.NewProjectPic.TabIndex = 0;
            this.NewProjectPic.TabStop = false;
            // 
            // NewProjectForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 618);
            this.Controls.Add(this.NewProjectStatus);
            this.Controls.Add(this.RequiredLabel);
            this.Controls.Add(this.PropertiesBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.ProjectBox);
            this.Controls.Add(this.NewProjectPic);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(744, 730);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(371, 656);
            this.Name = "NewProjectForm";
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