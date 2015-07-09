namespace SphereStudio.Forms
{
    partial class ConfigManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigManagerForm));
            this.presetBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigPathLabel = new System.Windows.Forms.Label();
            this.configPathBox = new System.Windows.Forms.TextBox();
            this.enginePathBox = new System.Windows.Forms.TextBox();
            this.enginePath64Box = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pluginList = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.defEditorCombo = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.sphereIcon = new System.Windows.Forms.PictureBox();
            this.findEngineButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.editorLabel1 = new Sphere.Core.Editor.EditorLabel();
            this.pluginHeader = new Sphere.Core.Editor.EditorLabel();
            this.editorLabel6 = new Sphere.Core.Editor.EditorLabel();
            this.header = new Sphere.Core.Editor.EditorLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sphereIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // presetBox
            // 
            this.presetBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetBox.FormattingEnabled = true;
            this.presetBox.Location = new System.Drawing.Point(12, 36);
            this.presetBox.Name = "presetBox";
            this.presetBox.Size = new System.Drawing.Size(254, 21);
            this.presetBox.TabIndex = 1;
            this.presetBox.SelectedIndexChanged += new System.EventHandler(this.presetBox_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 334);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.editorLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sphere Engine";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sphereIcon);
            this.panel1.Controls.Add(this.ConfigPathLabel);
            this.panel1.Controls.Add(this.configPathBox);
            this.panel1.Controls.Add(this.enginePathBox);
            this.panel1.Controls.Add(this.enginePath64Box);
            this.panel1.Controls.Add(this.findEngineButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 124);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x64";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x86";
            // 
            // ConfigPathLabel
            // 
            this.ConfigPathLabel.AutoSize = true;
            this.ConfigPathLabel.Location = new System.Drawing.Point(36, 73);
            this.ConfigPathLabel.Name = "ConfigPathLabel";
            this.ConfigPathLabel.Size = new System.Drawing.Size(152, 13);
            this.ConfigPathLabel.TabIndex = 5;
            this.ConfigPathLabel.Text = "Sphere Configuration Utility";
            // 
            // configPathBox
            // 
            this.configPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configPathBox.Location = new System.Drawing.Point(39, 90);
            this.configPathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.configPathBox.Name = "configPathBox";
            this.configPathBox.Size = new System.Drawing.Size(438, 22);
            this.configPathBox.TabIndex = 6;
            this.configPathBox.Validated += new System.EventHandler(this.configPathBox_Validated);
            // 
            // enginePathBox
            // 
            this.enginePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enginePathBox.Location = new System.Drawing.Point(39, 10);
            this.enginePathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enginePathBox.Name = "enginePathBox";
            this.enginePathBox.Size = new System.Drawing.Size(438, 22);
            this.enginePathBox.TabIndex = 1;
            this.enginePathBox.Validated += new System.EventHandler(this.enginePathBox_Validated);
            // 
            // enginePath64Box
            // 
            this.enginePath64Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enginePath64Box.Location = new System.Drawing.Point(39, 38);
            this.enginePath64Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enginePath64Box.Name = "enginePath64Box";
            this.enginePath64Box.Size = new System.Drawing.Size(438, 22);
            this.enginePath64Box.TabIndex = 3;
            this.enginePath64Box.Validated += new System.EventHandler(this.enginePath64Box_Validated);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pluginHeader);
            this.tabPage2.Controls.Add(this.pluginList);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.editorLabel6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plugins";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pluginList
            // 
            this.pluginList.CheckBoxes = true;
            this.pluginList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCol,
            this.AuthorCol,
            this.VersionCol,
            this.DescriptionCol});
            this.pluginList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginList.GridLines = true;
            this.pluginList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.pluginList.Location = new System.Drawing.Point(3, 60);
            this.pluginList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pluginList.Name = "pluginList";
            this.pluginList.ShowItemToolTips = true;
            this.pluginList.Size = new System.Drawing.Size(607, 245);
            this.pluginList.TabIndex = 3;
            this.pluginList.UseCompatibleStateImageBehavior = false;
            this.pluginList.View = System.Windows.Forms.View.Details;
            this.pluginList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.pluginList_ItemChecked);
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 150;
            // 
            // AuthorCol
            // 
            this.AuthorCol.Text = "Author";
            this.AuthorCol.Width = 91;
            // 
            // VersionCol
            // 
            this.VersionCol.Text = "Version";
            this.VersionCol.Width = 62;
            // 
            // DescriptionCol
            // 
            this.DescriptionCol.Text = "Description";
            this.DescriptionCol.Width = 300;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.defEditorCombo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(607, 34);
            this.panel4.TabIndex = 1;
            // 
            // defEditorCombo
            // 
            this.defEditorCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defEditorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defEditorCombo.FormattingEnabled = true;
            this.defEditorCombo.Location = new System.Drawing.Point(5, 6);
            this.defEditorCombo.Name = "defEditorCombo";
            this.defEditorCombo.Size = new System.Drawing.Size(599, 21);
            this.defEditorCombo.Sorted = true;
            this.defEditorCombo.TabIndex = 0;
            this.defEditorCombo.SelectedIndexChanged += new System.EventHandler(this.defEditorCombo_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(553, 407);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 25);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::SphereStudio.Properties.Resources.cross;
            this.deleteButton.Location = new System.Drawing.Point(272, 35);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(36, 26);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // sphereIcon
            // 
            this.sphereIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sphereIcon.Image = global::SphereStudio.Properties.Resources.SphericalLogo;
            this.sphereIcon.Location = new System.Drawing.Point(547, 10);
            this.sphereIcon.Name = "sphereIcon";
            this.sphereIcon.Size = new System.Drawing.Size(48, 48);
            this.sphereIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.sphereIcon.TabIndex = 23;
            this.sphereIcon.TabStop = false;
            // 
            // findEngineButton
            // 
            this.findEngineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findEngineButton.Image = global::SphereStudio.Properties.Resources.folder;
            this.findEngineButton.Location = new System.Drawing.Point(484, 10);
            this.findEngineButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.findEngineButton.Name = "findEngineButton";
            this.findEngineButton.Size = new System.Drawing.Size(48, 48);
            this.findEngineButton.TabIndex = 4;
            this.findEngineButton.Text = "...";
            this.findEngineButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.findEngineButton.UseVisualStyleBackColor = true;
            this.findEngineButton.Click += new System.EventHandler(this.findEngineButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Image = global::SphereStudio.Properties.Resources.disk;
            this.saveButton.Location = new System.Drawing.Point(314, 35);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(36, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(3, 3);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(607, 23);
            this.editorLabel1.TabIndex = 0;
            this.editorLabel1.Text = "Where is the Sphere engine located?";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pluginHeader
            // 
            this.pluginHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pluginHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pluginHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pluginHeader.ForeColor = System.Drawing.Color.White;
            this.pluginHeader.Location = new System.Drawing.Point(3, 60);
            this.pluginHeader.Name = "pluginHeader";
            this.pluginHeader.Size = new System.Drawing.Size(607, 23);
            this.pluginHeader.TabIndex = 2;
            this.pluginHeader.Text = "Which plugins do you want to use?";
            this.pluginHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editorLabel6
            // 
            this.editorLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel6.ForeColor = System.Drawing.Color.White;
            this.editorLabel6.Location = new System.Drawing.Point(3, 3);
            this.editorLabel6.Name = "editorLabel6";
            this.editorLabel6.Size = new System.Drawing.Size(607, 23);
            this.editorLabel6.TabIndex = 0;
            this.editorLabel6.Text = "Which editor should be used to open unrecognized files?";
            this.editorLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.header.ForeColor = System.Drawing.Color.White;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(645, 23);
            this.header.TabIndex = 0;
            this.header.Text = "Manage your Sphere Studio developer configurations";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfigManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(645, 441);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.presetBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration Manager";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sphereIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sphere.Core.Editor.EditorLabel header;
        private System.Windows.Forms.ComboBox presetBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox sphereIcon;
        private System.Windows.Forms.TextBox enginePath64Box;
        private System.Windows.Forms.Label ConfigPathLabel;
        private System.Windows.Forms.TextBox configPathBox;
        private System.Windows.Forms.TextBox enginePathBox;
        private System.Windows.Forms.Button findEngineButton;
        private System.Windows.Forms.ListView pluginList;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader AuthorCol;
        private System.Windows.Forms.ColumnHeader VersionCol;
        private System.Windows.Forms.ColumnHeader DescriptionCol;
        private Sphere.Core.Editor.EditorLabel pluginHeader;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox defEditorCombo;
        private Sphere.Core.Editor.EditorLabel editorLabel6;
        private Sphere.Core.Editor.EditorLabel editorLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button deleteButton;
    }
}