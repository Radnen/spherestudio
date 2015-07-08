namespace SphereStudio.Forms
{
    partial class EditorSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorSettings));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemCheckBox = new System.Windows.Forms.CheckedListBox();
            this.editorLabel1 = new Sphere.Core.Editor.EditorLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ScriptHeaderBox = new System.Windows.Forms.RichTextBox();
            this.PropLabel = new Sphere.Core.Editor.EditorLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StyleComboBox = new System.Windows.Forms.ComboBox();
            this.editorLabel2 = new Sphere.Core.Editor.EditorLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.PathListBox = new System.Windows.Forms.ListBox();
            this.editorLabel4 = new Sphere.Core.Editor.EditorLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sphereIcon = new System.Windows.Forms.PictureBox();
            this.ConfigPathLabel = new System.Windows.Forms.Label();
            this.configPathBox = new System.Windows.Forms.TextBox();
            this.enginePathBox = new System.Windows.Forms.TextBox();
            this.enginePath64Box = new System.Windows.Forms.TextBox();
            this.findEngineButton = new System.Windows.Forms.Button();
            this.editorLabel3 = new Sphere.Core.Editor.EditorLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PluginList = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pluginHeader = new Sphere.Core.Editor.EditorLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.defEditorCombo = new System.Windows.Forms.ComboBox();
            this.editorLabel6 = new Sphere.Core.Editor.EditorLabel();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.editorLabel5 = new Sphere.Core.Editor.EditorLabel();
            this.SettingsTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sphereIcon)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(462, 4);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(383, 4);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Controls.Add(this.tabPage1);
            this.SettingsTabs.Controls.Add(this.tabPage2);
            this.SettingsTabs.Controls.Add(this.tabPage3);
            this.SettingsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTabs.Location = new System.Drawing.Point(0, 23);
            this.SettingsTabs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(627, 388);
            this.SettingsTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.editorLabel1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.PropLabel);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.editorLabel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(619, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ItemCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 83);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 152);
            this.panel1.TabIndex = 9;
            // 
            // ItemCheckBox
            // 
            this.ItemCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemCheckBox.FormattingEnabled = true;
            this.ItemCheckBox.Items.AddRange(new object[] {
            "Use Automatic Script Headers",
            "Automatically Open Last Project",
            "Automatically Open Start Page"});
            this.ItemCheckBox.Location = new System.Drawing.Point(5, 5);
            this.ItemCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemCheckBox.Name = "ItemCheckBox";
            this.ItemCheckBox.Size = new System.Drawing.Size(603, 94);
            this.ItemCheckBox.TabIndex = 3;
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(3, 235);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(613, 23);
            this.editorLabel1.TabIndex = 2;
            this.editorLabel1.Text = "Script Header";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ScriptHeaderBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 258);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(613, 100);
            this.panel3.TabIndex = 10;
            // 
            // ScriptHeaderBox
            // 
            this.ScriptHeaderBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptHeaderBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScriptHeaderBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptHeaderBox.Location = new System.Drawing.Point(5, 5);
            this.ScriptHeaderBox.Name = "ScriptHeaderBox";
            this.ScriptHeaderBox.Size = new System.Drawing.Size(603, 92);
            this.ScriptHeaderBox.TabIndex = 6;
            this.ScriptHeaderBox.Text = "/**\n * File: [filename]\n * Author: [author]\n * Date: [MM/dd/yy]\n**/";
            // 
            // PropLabel
            // 
            this.PropLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PropLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PropLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PropLabel.ForeColor = System.Drawing.Color.White;
            this.PropLabel.Location = new System.Drawing.Point(3, 60);
            this.PropLabel.Name = "PropLabel";
            this.PropLabel.Size = new System.Drawing.Size(613, 23);
            this.PropLabel.TabIndex = 1;
            this.PropLabel.Text = "Properties";
            this.PropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StyleComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 33);
            this.panel2.TabIndex = 4;
            // 
            // StyleComboBox
            // 
            this.StyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleComboBox.FormattingEnabled = true;
            this.StyleComboBox.Location = new System.Drawing.Point(5, 5);
            this.StyleComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.StyleComboBox.MaxDropDownItems = 10;
            this.StyleComboBox.Name = "StyleComboBox";
            this.StyleComboBox.Size = new System.Drawing.Size(603, 21);
            this.StyleComboBox.TabIndex = 0;
            // 
            // editorLabel2
            // 
            this.editorLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel2.ForeColor = System.Drawing.Color.White;
            this.editorLabel2.Location = new System.Drawing.Point(3, 4);
            this.editorLabel2.Name = "editorLabel2";
            this.editorLabel2.Size = new System.Drawing.Size(613, 23);
            this.editorLabel2.TabIndex = 0;
            this.editorLabel2.Text = "UI Style";
            this.editorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.editorLabel4);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.editorLabel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(619, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Paths";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.RemoveButton);
            this.panel6.Controls.Add(this.AddButton);
            this.panel6.Controls.Add(this.DownButton);
            this.panel6.Controls.Add(this.UpButton);
            this.panel6.Controls.Add(this.PathListBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 174);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(613, 184);
            this.panel6.TabIndex = 17;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(544, 155);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(64, 22);
            this.RemoveButton.TabIndex = 19;
            this.RemoveButton.Text = "Remove";
            this.Tip.SetToolTip(this.RemoveButton, "Remove Selected Gamepath");
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(474, 155);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(64, 22);
            this.AddButton.TabIndex = 18;
            this.AddButton.Text = "Add...";
            this.Tip.SetToolTip(this.AddButton, "Add a Games Path");
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DownButton.Image = global::SphereStudio.Properties.Resources.resultset_down;
            this.DownButton.Location = new System.Drawing.Point(37, 155);
            this.DownButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(23, 22);
            this.DownButton.TabIndex = 17;
            this.Tip.SetToolTip(this.DownButton, "Move path down.");
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpButton.Image = global::SphereStudio.Properties.Resources.resultset_up;
            this.UpButton.Location = new System.Drawing.Point(9, 155);
            this.UpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(23, 22);
            this.UpButton.TabIndex = 16;
            this.Tip.SetToolTip(this.UpButton, "Move path up.");
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // PathListBox
            // 
            this.PathListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathListBox.FormattingEnabled = true;
            this.PathListBox.IntegralHeight = false;
            this.PathListBox.Location = new System.Drawing.Point(9, 11);
            this.PathListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathListBox.Name = "PathListBox";
            this.PathListBox.Size = new System.Drawing.Size(599, 136);
            this.PathListBox.TabIndex = 15;
            this.PathListBox.SelectedIndexChanged += new System.EventHandler(this.PathListBox_SelectedIndexChanged);
            // 
            // editorLabel4
            // 
            this.editorLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel4.ForeColor = System.Drawing.Color.White;
            this.editorLabel4.Location = new System.Drawing.Point(3, 151);
            this.editorLabel4.Name = "editorLabel4";
            this.editorLabel4.Size = new System.Drawing.Size(613, 23);
            this.editorLabel4.TabIndex = 18;
            this.editorLabel4.Text = "Additional Project Directories";
            this.editorLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.sphereIcon);
            this.panel5.Controls.Add(this.ConfigPathLabel);
            this.panel5.Controls.Add(this.configPathBox);
            this.panel5.Controls.Add(this.enginePathBox);
            this.panel5.Controls.Add(this.enginePath64Box);
            this.panel5.Controls.Add(this.findEngineButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(613, 124);
            this.panel5.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x64";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x86";
            // 
            // sphereIcon
            // 
            this.sphereIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sphereIcon.Image = global::SphereStudio.Properties.Resources.SphereIcon;
            this.sphereIcon.Location = new System.Drawing.Point(554, 10);
            this.sphereIcon.Name = "sphereIcon";
            this.sphereIcon.Size = new System.Drawing.Size(48, 48);
            this.sphereIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.sphereIcon.TabIndex = 23;
            this.sphereIcon.TabStop = false;
            // 
            // ConfigPathLabel
            // 
            this.ConfigPathLabel.AutoSize = true;
            this.ConfigPathLabel.Location = new System.Drawing.Point(9, 73);
            this.ConfigPathLabel.Name = "ConfigPathLabel";
            this.ConfigPathLabel.Size = new System.Drawing.Size(134, 13);
            this.ConfigPathLabel.TabIndex = 5;
            this.ConfigPathLabel.Text = "Sphere Configuration Utility";
            // 
            // configPathBox
            // 
            this.configPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configPathBox.Location = new System.Drawing.Point(12, 90);
            this.configPathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.configPathBox.Name = "configPathBox";
            this.configPathBox.Size = new System.Drawing.Size(472, 20);
            this.configPathBox.TabIndex = 6;
            // 
            // enginePathBox
            // 
            this.enginePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enginePathBox.Location = new System.Drawing.Point(39, 10);
            this.enginePathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enginePathBox.Name = "enginePathBox";
            this.enginePathBox.Size = new System.Drawing.Size(445, 20);
            this.enginePathBox.TabIndex = 1;
            // 
            // enginePath64Box
            // 
            this.enginePath64Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enginePath64Box.Location = new System.Drawing.Point(39, 38);
            this.enginePath64Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enginePath64Box.Name = "enginePath64Box";
            this.enginePath64Box.Size = new System.Drawing.Size(445, 20);
            this.enginePath64Box.TabIndex = 3;
            // 
            // findEngineButton
            // 
            this.findEngineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findEngineButton.Image = global::SphereStudio.Properties.Resources.folder;
            this.findEngineButton.Location = new System.Drawing.Point(490, 10);
            this.findEngineButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.findEngineButton.Name = "findEngineButton";
            this.findEngineButton.Size = new System.Drawing.Size(48, 48);
            this.findEngineButton.TabIndex = 4;
            this.findEngineButton.Text = "...";
            this.findEngineButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.findEngineButton.UseVisualStyleBackColor = true;
            this.findEngineButton.Click += new System.EventHandler(this.SpherePathButton_Click);
            // 
            // editorLabel3
            // 
            this.editorLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel3.ForeColor = System.Drawing.Color.White;
            this.editorLabel3.Location = new System.Drawing.Point(3, 4);
            this.editorLabel3.Name = "editorLabel3";
            this.editorLabel3.Size = new System.Drawing.Size(613, 23);
            this.editorLabel3.TabIndex = 0;
            this.editorLabel3.Text = "Sphere Engine";
            this.editorLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PluginList);
            this.tabPage3.Controls.Add(this.pluginHeader);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.editorLabel6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(619, 362);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Plugins";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // PluginList
            // 
            this.PluginList.CheckBoxes = true;
            this.PluginList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCol,
            this.AuthorCol,
            this.VersionCol,
            this.DescriptionCol});
            this.PluginList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginList.GridLines = true;
            this.PluginList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PluginList.Location = new System.Drawing.Point(3, 84);
            this.PluginList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PluginList.Name = "PluginList";
            this.PluginList.ShowItemToolTips = true;
            this.PluginList.Size = new System.Drawing.Size(613, 274);
            this.PluginList.TabIndex = 1;
            this.PluginList.UseCompatibleStateImageBehavior = false;
            this.PluginList.View = System.Windows.Forms.View.Details;
            this.PluginList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PluginList_ItemCheck);
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
            // pluginHeader
            // 
            this.pluginHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pluginHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pluginHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pluginHeader.ForeColor = System.Drawing.Color.White;
            this.pluginHeader.Location = new System.Drawing.Point(3, 61);
            this.pluginHeader.Name = "pluginHeader";
            this.pluginHeader.Size = new System.Drawing.Size(613, 23);
            this.pluginHeader.TabIndex = 2;
            this.pluginHeader.Text = "Activate or deactivate plugins";
            this.pluginHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.defEditorCombo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(613, 34);
            this.panel4.TabIndex = 4;
            // 
            // defEditorCombo
            // 
            this.defEditorCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defEditorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defEditorCombo.FormattingEnabled = true;
            this.defEditorCombo.Location = new System.Drawing.Point(5, 6);
            this.defEditorCombo.Name = "defEditorCombo";
            this.defEditorCombo.Size = new System.Drawing.Size(603, 21);
            this.defEditorCombo.Sorted = true;
            this.defEditorCombo.TabIndex = 4;
            // 
            // editorLabel6
            // 
            this.editorLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel6.ForeColor = System.Drawing.Color.White;
            this.editorLabel6.Location = new System.Drawing.Point(3, 4);
            this.editorLabel6.Name = "editorLabel6";
            this.editorLabel6.Size = new System.Drawing.Size(613, 23);
            this.editorLabel6.TabIndex = 3;
            this.editorLabel6.Text = "Default editor for unrecognized file types";
            this.editorLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonPanel.Controls.Add(this.ApplyButton);
            this.ButtonPanel.Controls.Add(this.cancelButton);
            this.ButtonPanel.Controls.Add(this.okButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 411);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(627, 30);
            this.ButtonPanel.TabIndex = 2;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(542, 4);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 22);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "&Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // editorLabel5
            // 
            this.editorLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel5.ForeColor = System.Drawing.Color.White;
            this.editorLabel5.Location = new System.Drawing.Point(0, 0);
            this.editorLabel5.Name = "editorLabel5";
            this.editorLabel5.Size = new System.Drawing.Size(627, 23);
            this.editorLabel5.TabIndex = 3;
            this.editorLabel5.Text = "Customize your Sphere Studio environment";
            this.editorLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditorSettings
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(627, 441);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.editorLabel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 325);
            this.Name = "EditorSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Settings";
            this.Load += new System.EventHandler(this.EditorSettings_Load);
            this.SettingsTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sphereIcon)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.TabControl SettingsTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox ItemCheckBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView PluginList;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader AuthorCol;
        private System.Windows.Forms.ColumnHeader VersionCol;
        private System.Windows.Forms.ColumnHeader DescriptionCol;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.ComboBox StyleComboBox;
        private System.Windows.Forms.Button ApplyButton;
        private Sphere.Core.Editor.EditorLabel PropLabel;
        private Sphere.Core.Editor.EditorLabel editorLabel1;
        private System.Windows.Forms.RichTextBox ScriptHeaderBox;
        private Sphere.Core.Editor.EditorLabel editorLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Sphere.Core.Editor.EditorLabel editorLabel3;
        private Sphere.Core.Editor.EditorLabel pluginHeader;
        private Sphere.Core.Editor.EditorLabel editorLabel5;
        private Sphere.Core.Editor.EditorLabel editorLabel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox defEditorCombo;
        private Sphere.Core.Editor.EditorLabel editorLabel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.ListBox PathListBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox sphereIcon;
        private System.Windows.Forms.Label ConfigPathLabel;
        private System.Windows.Forms.TextBox configPathBox;
        private System.Windows.Forms.TextBox enginePathBox;
        private System.Windows.Forms.TextBox enginePath64Box;
        private System.Windows.Forms.Button findEngineButton;
    }
}