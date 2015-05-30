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
            this.SpherePathLabel = new System.Windows.Forms.Label();
            this.SpherePathBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ConfigPathLabel = new System.Windows.Forms.Label();
            this.ConfigPathBox = new System.Windows.Forms.TextBox();
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
            this.editorLabel4 = new Sphere.Core.Editor.EditorLabel();
            this.Sphere64PathLabel = new System.Windows.Forms.Label();
            this.Sphere64PathBox = new System.Windows.Forms.TextBox();
            this.editorLabel3 = new Sphere.Core.Editor.EditorLabel();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.PathListBox = new System.Windows.Forms.ListBox();
            this.SpherePathButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PluginList = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.UsePresetButton = new System.Windows.Forms.Button();
            this.RemovePresetButton = new System.Windows.Forms.Button();
            this.SavePresetButton = new System.Windows.Forms.Button();
            this.PresetListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.PresetsPanel = new System.Windows.Forms.Panel();
            this.PresetLabel = new Sphere.Core.Editor.EditorLabel();
            this.SettingsTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.PresetsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(501, 4);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 22);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(422, 4);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&Save";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // SpherePathLabel
            // 
            this.SpherePathLabel.AutoSize = true;
            this.SpherePathLabel.Location = new System.Drawing.Point(6, 36);
            this.SpherePathLabel.Name = "SpherePathLabel";
            this.SpherePathLabel.Size = new System.Drawing.Size(102, 13);
            this.SpherePathLabel.TabIndex = 1;
            this.SpherePathLabel.Text = "Sphere Engine Path";
            // 
            // SpherePathBox
            // 
            this.SpherePathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathBox.Location = new System.Drawing.Point(9, 53);
            this.SpherePathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpherePathBox.Name = "SpherePathBox";
            this.SpherePathBox.Size = new System.Drawing.Size(360, 20);
            this.SpherePathBox.TabIndex = 2;
            // 
            // ConfigPathLabel
            // 
            this.ConfigPathLabel.AutoSize = true;
            this.ConfigPathLabel.Location = new System.Drawing.Point(6, 118);
            this.ConfigPathLabel.Name = "ConfigPathLabel";
            this.ConfigPathLabel.Size = new System.Drawing.Size(99, 13);
            this.ConfigPathLabel.TabIndex = 6;
            this.ConfigPathLabel.Text = "Sphere Config Path";
            // 
            // ConfigPathBox
            // 
            this.ConfigPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigPathBox.Location = new System.Drawing.Point(9, 135);
            this.ConfigPathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfigPathBox.Name = "ConfigPathBox";
            this.ConfigPathBox.Size = new System.Drawing.Size(400, 20);
            this.ConfigPathBox.TabIndex = 7;
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsTabs.Controls.Add(this.tabPage1);
            this.SettingsTabs.Controls.Add(this.tabPage2);
            this.SettingsTabs.Controls.Add(this.tabPage3);
            this.SettingsTabs.Location = new System.Drawing.Point(10, 11);
            this.SettingsTabs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(438, 427);
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
            this.tabPage1.Size = new System.Drawing.Size(430, 401);
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
            this.panel1.Size = new System.Drawing.Size(424, 191);
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
            this.ItemCheckBox.Size = new System.Drawing.Size(414, 154);
            this.ItemCheckBox.TabIndex = 3;
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(3, 274);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(424, 23);
            this.editorLabel1.TabIndex = 2;
            this.editorLabel1.Text = "Script Header";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ScriptHeaderBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 297);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 100);
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
            this.ScriptHeaderBox.Size = new System.Drawing.Size(414, 92);
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
            this.PropLabel.Size = new System.Drawing.Size(424, 23);
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
            this.panel2.Size = new System.Drawing.Size(424, 33);
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
            this.StyleComboBox.Size = new System.Drawing.Size(414, 21);
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
            this.editorLabel2.Size = new System.Drawing.Size(424, 23);
            this.editorLabel2.TabIndex = 0;
            this.editorLabel2.Text = "UI Style";
            this.editorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.editorLabel4);
            this.tabPage2.Controls.Add(this.Sphere64PathLabel);
            this.tabPage2.Controls.Add(this.Sphere64PathBox);
            this.tabPage2.Controls.Add(this.editorLabel3);
            this.tabPage2.Controls.Add(this.DownButton);
            this.tabPage2.Controls.Add(this.UpButton);
            this.tabPage2.Controls.Add(this.RemoveButton);
            this.tabPage2.Controls.Add(this.AddButton);
            this.tabPage2.Controls.Add(this.PathListBox);
            this.tabPage2.Controls.Add(this.SpherePathLabel);
            this.tabPage2.Controls.Add(this.ConfigPathLabel);
            this.tabPage2.Controls.Add(this.ConfigPathBox);
            this.tabPage2.Controls.Add(this.SpherePathButton);
            this.tabPage2.Controls.Add(this.SpherePathBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(412, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Paths";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // editorLabel4
            // 
            this.editorLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel4.ForeColor = System.Drawing.Color.White;
            this.editorLabel4.Location = new System.Drawing.Point(6, 168);
            this.editorLabel4.Name = "editorLabel4";
            this.editorLabel4.Size = new System.Drawing.Size(400, 23);
            this.editorLabel4.TabIndex = 8;
            this.editorLabel4.Text = "Game Paths";
            this.editorLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Sphere64PathLabel
            // 
            this.Sphere64PathLabel.AutoSize = true;
            this.Sphere64PathLabel.Location = new System.Drawing.Point(6, 77);
            this.Sphere64PathLabel.Name = "Sphere64PathLabel";
            this.Sphere64PathLabel.Size = new System.Drawing.Size(131, 13);
            this.Sphere64PathLabel.TabIndex = 4;
            this.Sphere64PathLabel.Text = "Sphere 64-bit Engine Path";
            // 
            // Sphere64PathBox
            // 
            this.Sphere64PathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sphere64PathBox.Location = new System.Drawing.Point(9, 94);
            this.Sphere64PathBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Sphere64PathBox.Name = "Sphere64PathBox";
            this.Sphere64PathBox.Size = new System.Drawing.Size(400, 20);
            this.Sphere64PathBox.TabIndex = 5;
            // 
            // editorLabel3
            // 
            this.editorLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel3.ForeColor = System.Drawing.Color.White;
            this.editorLabel3.Location = new System.Drawing.Point(6, 4);
            this.editorLabel3.Name = "editorLabel3";
            this.editorLabel3.Size = new System.Drawing.Size(400, 23);
            this.editorLabel3.TabIndex = 0;
            this.editorLabel3.Text = "Sphere Paths";
            this.editorLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DownButton.Image = global::SphereStudio.Properties.Resources.resultset_down;
            this.DownButton.Location = new System.Drawing.Point(37, 375);
            this.DownButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(23, 22);
            this.DownButton.TabIndex = 11;
            this.Tip.SetToolTip(this.DownButton, "Move path down.");
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpButton.Image = global::SphereStudio.Properties.Resources.resultset_up;
            this.UpButton.Location = new System.Drawing.Point(9, 375);
            this.UpButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(23, 22);
            this.UpButton.TabIndex = 10;
            this.Tip.SetToolTip(this.UpButton, "Move path up.");
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(342, 375);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(64, 22);
            this.RemoveButton.TabIndex = 13;
            this.RemoveButton.Text = "Remove";
            this.Tip.SetToolTip(this.RemoveButton, "Remove Selected Gamepath");
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(272, 375);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(64, 22);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "Add...";
            this.Tip.SetToolTip(this.AddButton, "Add a Games Path");
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PathListBox
            // 
            this.PathListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathListBox.FormattingEnabled = true;
            this.PathListBox.IntegralHeight = false;
            this.PathListBox.Location = new System.Drawing.Point(6, 195);
            this.PathListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathListBox.Name = "PathListBox";
            this.PathListBox.Size = new System.Drawing.Size(400, 172);
            this.PathListBox.TabIndex = 9;
            this.PathListBox.SelectedIndexChanged += new System.EventHandler(this.PathListBox_SelectedIndexChanged);
            // 
            // SpherePathButton
            // 
            this.SpherePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SpherePathButton.Image = global::SphereStudio.Properties.Resources.folder;
            this.SpherePathButton.Location = new System.Drawing.Point(375, 53);
            this.SpherePathButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpherePathButton.Name = "SpherePathButton";
            this.SpherePathButton.Size = new System.Drawing.Size(31, 22);
            this.SpherePathButton.TabIndex = 3;
            this.Tip.SetToolTip(this.SpherePathButton, "Choose Sphere Folder");
            this.SpherePathButton.UseVisualStyleBackColor = true;
            this.SpherePathButton.Click += new System.EventHandler(this.SpherePathButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PluginList);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(412, 401);
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
            this.PluginList.Location = new System.Drawing.Point(3, 32);
            this.PluginList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PluginList.Name = "PluginList";
            this.PluginList.ShowItemToolTips = true;
            this.PluginList.Size = new System.Drawing.Size(406, 365);
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
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is a list of plugins that are present in the /plugins directory. Click on th" +
    "e check boxes to add or remove features from the editor.";
            // 
            // UsePresetButton
            // 
            this.UsePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsePresetButton.Enabled = false;
            this.UsePresetButton.Location = new System.Drawing.Point(3, 375);
            this.UsePresetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UsePresetButton.Name = "UsePresetButton";
            this.UsePresetButton.Size = new System.Drawing.Size(195, 22);
            this.UsePresetButton.TabIndex = 3;
            this.UsePresetButton.Text = "&Use";
            this.Tip.SetToolTip(this.UsePresetButton, "Use Preset Settings File");
            this.UsePresetButton.UseVisualStyleBackColor = true;
            this.UsePresetButton.Click += new System.EventHandler(this.UsePresetButton_Click);
            // 
            // RemovePresetButton
            // 
            this.RemovePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemovePresetButton.Enabled = false;
            this.RemovePresetButton.Location = new System.Drawing.Point(134, 399);
            this.RemovePresetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemovePresetButton.Name = "RemovePresetButton";
            this.RemovePresetButton.Size = new System.Drawing.Size(64, 22);
            this.RemovePresetButton.TabIndex = 5;
            this.RemovePresetButton.Text = "&Remove";
            this.Tip.SetToolTip(this.RemovePresetButton, "Remove the preset settings file.");
            this.RemovePresetButton.UseVisualStyleBackColor = true;
            this.RemovePresetButton.Click += new System.EventHandler(this.RemovePresetButton_Click);
            // 
            // SavePresetButton
            // 
            this.SavePresetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePresetButton.Location = new System.Drawing.Point(64, 399);
            this.SavePresetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SavePresetButton.Name = "SavePresetButton";
            this.SavePresetButton.Size = new System.Drawing.Size(64, 22);
            this.SavePresetButton.TabIndex = 4;
            this.SavePresetButton.Text = "A&dd...";
            this.Tip.SetToolTip(this.SavePresetButton, "Save current settings to disk.");
            this.SavePresetButton.UseVisualStyleBackColor = true;
            this.SavePresetButton.Click += new System.EventHandler(this.SavePresetButton_Click);
            // 
            // PresetListBox
            // 
            this.PresetListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetListBox.FormattingEnabled = true;
            this.PresetListBox.IntegralHeight = false;
            this.PresetListBox.Location = new System.Drawing.Point(3, 81);
            this.PresetListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PresetListBox.Name = "PresetListBox";
            this.PresetListBox.Size = new System.Drawing.Size(196, 286);
            this.PresetListBox.TabIndex = 2;
            this.PresetListBox.SelectedIndexChanged += new System.EventHandler(this.PresetListBox_SelectedIndexChanged);
            this.PresetListBox.DoubleClick += new System.EventHandler(this.PresetListBox_DoubleClick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 58);
            this.label2.TabIndex = 1;
            this.label2.Text = "Presets allow you to target different Sphere versions, game paths and plugin list" +
    "s to suit your development needs.";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonPanel.Controls.Add(this.ApplyButton);
            this.ButtonPanel.Controls.Add(this.cancelButton);
            this.ButtonPanel.Controls.Add(this.okButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 444);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(666, 30);
            this.ButtonPanel.TabIndex = 2;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(581, 4);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 22);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "&Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // PresetsPanel
            // 
            this.PresetsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PresetsPanel.Controls.Add(this.RemovePresetButton);
            this.PresetsPanel.Controls.Add(this.SavePresetButton);
            this.PresetsPanel.Controls.Add(this.UsePresetButton);
            this.PresetsPanel.Controls.Add(this.PresetListBox);
            this.PresetsPanel.Controls.Add(this.label2);
            this.PresetsPanel.Controls.Add(this.PresetLabel);
            this.PresetsPanel.Location = new System.Drawing.Point(453, 11);
            this.PresetsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PresetsPanel.Name = "PresetsPanel";
            this.PresetsPanel.Size = new System.Drawing.Size(203, 427);
            this.PresetsPanel.TabIndex = 1;
            // 
            // PresetLabel
            // 
            this.PresetLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PresetLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PresetLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PresetLabel.ForeColor = System.Drawing.Color.White;
            this.PresetLabel.Location = new System.Drawing.Point(0, 0);
            this.PresetLabel.Name = "PresetLabel";
            this.PresetLabel.Size = new System.Drawing.Size(201, 23);
            this.PresetLabel.TabIndex = 0;
            this.PresetLabel.Text = "Presets";
            this.PresetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditorSettings
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(666, 474);
            this.Controls.Add(this.PresetsPanel);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.ButtonPanel);
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
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.PresetsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label SpherePathLabel;
        private System.Windows.Forms.TextBox SpherePathBox;
        private System.Windows.Forms.Button SpherePathButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Label ConfigPathLabel;
        private System.Windows.Forms.TextBox ConfigPathBox;
        private System.Windows.Forms.TabControl SettingsTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox ItemCheckBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox PathListBox;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView PluginList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader AuthorCol;
        private System.Windows.Forms.ColumnHeader VersionCol;
        private System.Windows.Forms.ColumnHeader DescriptionCol;
        private System.Windows.Forms.ListBox PresetListBox;
        private System.Windows.Forms.Button UsePresetButton;
        private System.Windows.Forms.Button RemovePresetButton;
        private System.Windows.Forms.Button SavePresetButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.ComboBox StyleComboBox;
        private System.Windows.Forms.Panel PresetsPanel;
        private Sphere.Core.Editor.EditorLabel PresetLabel;
        private System.Windows.Forms.Button ApplyButton;
        private Sphere.Core.Editor.EditorLabel PropLabel;
        private Sphere.Core.Editor.EditorLabel editorLabel1;
        private System.Windows.Forms.RichTextBox ScriptHeaderBox;
        private Sphere.Core.Editor.EditorLabel editorLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Sphere64PathLabel;
        private System.Windows.Forms.TextBox Sphere64PathBox;
        private Sphere.Core.Editor.EditorLabel editorLabel3;
        private Sphere.Core.Editor.EditorLabel editorLabel4;
    }
}