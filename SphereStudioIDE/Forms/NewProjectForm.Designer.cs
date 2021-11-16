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
            this.ProjectBox = new System.Windows.Forms.GroupBox();
            this.FolderBrowseButton = new System.Windows.Forms.Button();
            this.DirectoryBox = new System.Windows.Forms.TextBox();
            this.FolderBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.DirectoryLabel = new System.Windows.Forms.Label();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.FolderFinder = new System.Windows.Forms.FolderBrowserDialog();
            this.PropertiesBox = new System.Windows.Forms.GroupBox();
            this.CompilerComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DescLabel = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.ResoComboBox = new System.Windows.Forms.ComboBox();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.ResoLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.AuthorBox = new System.Windows.Forms.TextBox();
            this.RequiredLabel = new System.Windows.Forms.Label();
            this.NewProjectStatus = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.editorLabel1 = new SphereStudio.UI.DialogHeader();
            this.ProjectBox.SuspendLayout();
            this.PropertiesBox.SuspendLayout();
            this.NewProjectStatus.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
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
            this.ProjectBox.Location = new System.Drawing.Point(13, 33);
            this.ProjectBox.Name = "ProjectBox";
            this.ProjectBox.Size = new System.Drawing.Size(421, 112);
            this.ProjectBox.TabIndex = 1;
            this.ProjectBox.TabStop = false;
            this.ProjectBox.Text = "Project";
            // 
            // FolderBrowseButton
            // 
            this.FolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBrowseButton.Image = global::SphereStudio.Ide.Properties.Resources.folder;
            this.FolderBrowseButton.Location = new System.Drawing.Point(386, 48);
            this.FolderBrowseButton.Name = "FolderBrowseButton";
            this.FolderBrowseButton.Size = new System.Drawing.Size(27, 22);
            this.FolderBrowseButton.TabIndex = 4;
            this.FolderBrowseButton.UseVisualStyleBackColor = true;
            this.FolderBrowseButton.Click += new System.EventHandler(this.FolderBrowseButton_Click);
            // 
            // DirectoryBox
            // 
            this.DirectoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryBox.Location = new System.Drawing.Point(72, 76);
            this.DirectoryBox.Name = "DirectoryBox";
            this.DirectoryBox.ReadOnly = true;
            this.DirectoryBox.Size = new System.Drawing.Size(341, 22);
            this.DirectoryBox.TabIndex = 6;
            // 
            // FolderBox
            // 
            this.FolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBox.Location = new System.Drawing.Point(72, 48);
            this.FolderBox.Name = "FolderBox";
            this.FolderBox.Size = new System.Drawing.Size(308, 22);
            this.FolderBox.TabIndex = 3;
            this.FolderBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FillDirectory);
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.Location = new System.Drawing.Point(72, 20);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(341, 22);
            this.NameBox.TabIndex = 1;
            this.NameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FillDirectory);
            // 
            // DirectoryLabel
            // 
            this.DirectoryLabel.AutoSize = true;
            this.DirectoryLabel.Location = new System.Drawing.Point(14, 79);
            this.DirectoryLabel.Name = "DirectoryLabel";
            this.DirectoryLabel.Size = new System.Drawing.Size(52, 13);
            this.DirectoryLabel.TabIndex = 5;
            this.DirectoryLabel.Text = "Full Path";
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Location = new System.Drawing.Point(21, 51);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(45, 13);
            this.FolderLabel.TabIndex = 2;
            this.FolderLabel.Text = "*Folder";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(25, 23);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "*Name";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(354, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(80, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(268, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(80, 25);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "&Create!";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // PropertiesBox
            // 
            this.PropertiesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesBox.Controls.Add(this.CompilerComboBox);
            this.PropertiesBox.Controls.Add(this.label2);
            this.PropertiesBox.Controls.Add(this.DescLabel);
            this.PropertiesBox.Controls.Add(this.DescriptionBox);
            this.PropertiesBox.Controls.Add(this.ResoComboBox);
            this.PropertiesBox.Controls.Add(this.HeightBox);
            this.PropertiesBox.Controls.Add(this.WidthBox);
            this.PropertiesBox.Controls.Add(this.ResoLabel);
            this.PropertiesBox.Controls.Add(this.AuthorLabel);
            this.PropertiesBox.Controls.Add(this.AuthorBox);
            this.PropertiesBox.Location = new System.Drawing.Point(13, 166);
            this.PropertiesBox.Name = "PropertiesBox";
            this.PropertiesBox.Size = new System.Drawing.Size(421, 349);
            this.PropertiesBox.TabIndex = 3;
            this.PropertiesBox.TabStop = false;
            this.PropertiesBox.Text = "Properties";
            // 
            // CompilerComboBox
            // 
            this.CompilerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompilerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompilerComboBox.FormattingEnabled = true;
            this.CompilerComboBox.Location = new System.Drawing.Point(80, 74);
            this.CompilerComboBox.Name = "CompilerComboBox";
            this.CompilerComboBox.Size = new System.Drawing.Size(330, 21);
            this.CompilerComboBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Compiler";
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(11, 114);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(85, 13);
            this.DescLabel.TabIndex = 6;
            this.DescLabel.Text = "Game Summary";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBox.Location = new System.Drawing.Point(14, 130);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(396, 202);
            this.DescriptionBox.TabIndex = 7;
            // 
            // ResoComboBox
            // 
            this.ResoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResoComboBox.FormattingEnabled = true;
            this.ResoComboBox.Items.AddRange(new object[] {
            "Click to select a resolution",
            "320x240",
            "640x480",
            "800x600",
            "1024x768",
            "1280x720",
            "1920x1080"});
            this.ResoComboBox.Location = new System.Drawing.Point(80, 47);
            this.ResoComboBox.Name = "ResoComboBox";
            this.ResoComboBox.Size = new System.Drawing.Size(242, 21);
            this.ResoComboBox.TabIndex = 3;
            this.ResoComboBox.SelectedIndexChanged += new System.EventHandler(this.ResoComboBox_SelectedIndexChanged);
            // 
            // HeightBox
            // 
            this.HeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightBox.Location = new System.Drawing.Point(372, 47);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(38, 22);
            this.HeightBox.TabIndex = 5;
            this.HeightBox.Text = "240";
            this.HeightBox.TextChanged += new System.EventHandler(this.ResoText_Changed);
            this.HeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // WidthBox
            // 
            this.WidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthBox.Location = new System.Drawing.Point(328, 47);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(38, 22);
            this.WidthBox.TabIndex = 4;
            this.WidthBox.Text = "320";
            this.WidthBox.TextChanged += new System.EventHandler(this.ResoText_Changed);
            this.WidthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // ResoLabel
            // 
            this.ResoLabel.AutoSize = true;
            this.ResoLabel.Location = new System.Drawing.Point(11, 49);
            this.ResoLabel.Name = "ResoLabel";
            this.ResoLabel.Size = new System.Drawing.Size(63, 13);
            this.ResoLabel.TabIndex = 2;
            this.ResoLabel.Text = "Resolution";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(31, 22);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(43, 13);
            this.AuthorLabel.TabIndex = 0;
            this.AuthorLabel.Text = "Author";
            // 
            // AuthorBox
            // 
            this.AuthorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorBox.Location = new System.Drawing.Point(80, 19);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(330, 22);
            this.AuthorBox.TabIndex = 1;
            this.AuthorBox.Text = "Unknown";
            // 
            // RequiredLabel
            // 
            this.RequiredLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RequiredLabel.AutoSize = true;
            this.RequiredLabel.Location = new System.Drawing.Point(294, 148);
            this.RequiredLabel.Name = "RequiredLabel";
            this.RequiredLabel.Size = new System.Drawing.Size(140, 13);
            this.RequiredLabel.TabIndex = 2;
            this.RequiredLabel.Text = "* Denotes a required field";
            // 
            // NewProjectStatus
            // 
            this.NewProjectStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewProjectStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.NewProjectStatus.Location = new System.Drawing.Point(0, 560);
            this.NewProjectStatus.Name = "NewProjectStatus";
            this.NewProjectStatus.Size = new System.Drawing.Size(444, 22);
            this.NewProjectStatus.SizingGrip = false;
            this.NewProjectStatus.TabIndex = 5;
            this.NewProjectStatus.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(183, 17);
            this.StatusLabel.Text = "You\'ll need a name and directory.";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.OKButton);
            this.ButtonPanel.Controls.Add(this.CloseButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 530);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(444, 30);
            this.ButtonPanel.TabIndex = 4;
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(0, 0);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(444, 23);
            this.editorLabel1.TabIndex = 0;
            this.editorLabel1.Text = "Create a new Sphere Studio project";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewProjectForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(444, 582);
            this.Controls.Add(this.editorLabel1);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.NewProjectStatus);
            this.Controls.Add(this.RequiredLabel);
            this.Controls.Add(this.PropertiesBox);
            this.Controls.Add(this.ProjectBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.Load += new System.EventHandler(this.NewProjectForm_Load);
            this.ProjectBox.ResumeLayout(false);
            this.ProjectBox.PerformLayout();
            this.PropertiesBox.ResumeLayout(false);
            this.PropertiesBox.PerformLayout();
            this.NewProjectStatus.ResumeLayout(false);
            this.NewProjectStatus.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox ProjectBox;
        private System.Windows.Forms.Label DirectoryLabel;
        private System.Windows.Forms.Label FolderLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button CloseButton;
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
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.ComboBox ResoComboBox;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label RequiredLabel;
        private System.Windows.Forms.StatusStrip NewProjectStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Panel ButtonPanel;
        private SphereStudio.UI.DialogHeader editorLabel1;
        private System.Windows.Forms.ComboBox CompilerComboBox;
        private System.Windows.Forms.Label label2;
    }
}